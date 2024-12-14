using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace punchSystem
{
    public partial class Form1 : Form
    {
        // 預設的驗證用連線字串
        private string initialConnStr =
            @"Data Source=MIFFY-LAPTOP; Initial Catalog=Punch_System;
              Integrated Security=false; user id=sqluser; password=123456";

        // 三種角色（員工、公司管理者、總管理者）對應的連線字串
        private string employeeConnStr =
            @"Data Source=MIFFY-LAPTOP; Initial Catalog = Punch_System; 
              Integrated Security = false; user id=employee; password=123456";

        private string companyAdminConnStr =
            @"Data Source=MIFFY-LAPTOP; Initial Catalog=Punch_System;
              Integrated Security=false; user id=companyAdmin; password=123456";

        private string superAdminConnStr =
            @"Data Source=MIFFY-LAPTOP; Initial Catalog=Punch_System;
              Integrated Security=false; user id=superAdmin; password=123456";

        public class userObj
        {
            public int userId;
            public int companyId;
            public string personName;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox_username.Text.Trim();
            string password = textBox_pw.Text.Trim();

            // 確認使用者輸入是否完整
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("請輸入帳號及密碼！");
                return;
            }

            // 驗證使用者身分
            string userRole = ValidateUserRole(userName, password);

            if (string.IsNullOrEmpty(userRole))
            {
                MessageBox.Show("登入失敗，請確認帳號密碼是否正確！");
                return;
            }

            
            userObj userObj = GetUserObj(userName); // 抓使用者資訊
            RecordLoginTime(userObj.userId); // 紀錄登入時間

            // 根據使用者身分開啟不同的 Form 並使用對應的 SQL 帳號連線
            switch (userRole)
            {
                case "員工":
                    // 開啟Form3（簽到頁面），並傳入employeeConnStr
                    Form3 f3 = new Form3(employeeConnStr, userObj.userId, userObj.personName, userObj.companyId);
                    f3.Show();
                    this.Hide();
                    break;

                case "公司管理者":
                    // 開啟Form4（顯示該公司本月簽到清單），並傳入companyAdminConnStr
                    Form4 f4 = new Form4(companyAdminConnStr, userObj);
                    f4.Show();
                    this.Hide();
                    break;

                case "總管理者":
                    // 開啟Form5（公司及管理者管理頁面），並傳入superAdminConnStr
                    Form5 f5 = new Form5(superAdminConnStr, userObj);
                    f5.Show();
                    this.Hide();
                    break;

                default:
                    MessageBox.Show("無效的使用者角色！");
                    break;
            }
        }

        private string ValidateUserRole(string userName, string password)
        {
            // 使用 initialConnStr 連線至資料庫
            string sql = "SELECT type, password, passwordSalt FROM [User] WHERE name=@name";

            using (SqlConnection conn = new SqlConnection(initialConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", userName);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            // 從資料庫取出雜湊後的密碼、salt值
                            string dbHashedPassword = dataReader["password"].ToString();  // 資料庫中的雜湊密碼 (Base64)
                            string dbPasswordSalt = dataReader["passwordSalt"].ToString(); // 資料庫中的salt (Base64)

                            // 將salt從Base64轉回Byte[]
                            byte[] saltBytes = Convert.FromBase64String(dbPasswordSalt);

                            // 將使用者輸入的平文字密碼轉成Bytes
                            byte[] inputPwBytes = Encoding.Default.GetBytes(password);

                            // 密碼 + salt
                            byte[] pwWithSalt = inputPwBytes.Concat(saltBytes).ToArray();

                            // 使用 SHA256 產生雜湊
                            using (SHA256 sha256 = SHA256.Create())
                            {
                                byte[] hashBytes = sha256.ComputeHash(pwWithSalt);
                                string hashedInputPw = Convert.ToBase64String(hashBytes);

                                // 與資料庫中的密碼雜湊比對
                                if (hashedInputPw == dbHashedPassword)
                                {
                                    // 密碼正確，回傳角色
                                    string userType = dataReader["type"].ToString();
                                    return userType;
                                }
                                else
                                {
                                    // 密碼不符，回傳null
                                    return null;
                                }
                            }
                        }
                        else
                        {
                            // 沒有讀到任何資料，表示user不存在
                            MessageBox.Show("帳號不存在");
                            return null;
                        }
                    }
                }
            }
        }

        private userObj GetUserObj(string userName)
        {
            string sql = "SELECT * FROM [User] U inner join Person P ON U.person_id = P.person_id WHERE name=@name";
            using (SqlConnection conn = new SqlConnection(initialConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", userName);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            userObj userObj = new userObj();
                            userObj.userId = int.Parse(dataReader["user_id"].ToString());
                            userObj.companyId = int.Parse(dataReader["company_id"].ToString());
                            userObj.personName = dataReader["person_name"].ToString();

                            return userObj;
                        }
                        else
                        {
                            // 沒有讀到任何資料，表示user不存在
                            MessageBox.Show("帳號不存在");
                            return null;
                        }
                    }
                }
            }
        }

        private void RecordLoginTime(int userId)
        {
            // 使用 employeeConnStr 連線至資料庫
            string sql = "INSERT INTO [Login_record] (user_id, login_time) VALUES (@userId, @now);";

            using (SqlConnection conn = new SqlConnection(employeeConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DateTime now = DateTime.Now;
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@now", now);

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        MessageBox.Show("登入成功！" + now);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 註冊帳號
            Form2 fm2 = new Form2();
            fm2.Show();
            this.Hide();
        }
    }
}
