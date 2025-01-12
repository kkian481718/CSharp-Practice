using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace punchSystem
{
    public partial class Form2 : Form
    {
        SqlConnection conn;
        SqlCommand command;
        private string signUpConnStr = @"Data Source=MIFFY-LAPTOP; Initial Catalog=Punch_System; Integrated Security=false; user id=sqldba; password=123456";

        public Form2()
        {
            InitializeComponent();
        }

        private byte[] GenerateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[5]);
            return salt;
        }

        private byte[] GeneratePasswordHash(byte[] _salt)
        {
            byte[] psw_hash;
            byte[] input = Encoding.Default.GetBytes(textBox2.Text);
            byte[] inputAndSalt = input.Concat(_salt).ToArray();

            SHA256 HASH = SHA256.Create();
            psw_hash = HASH.ComputeHash(inputAndSalt);

            return psw_hash;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 初始化下拉選單和現有資料
            LoadExistingData();
        }

        private void LoadExistingData()
        {
            using (conn = new SqlConnection("Data Source=MIFFY-LAPTOP; Initial Catalog=Punch_System; Integrated Security=false; user id=sqldba; password=123456"))
            {
                conn.Open();

                // 加載現有個人資料
                string personSql = "SELECT person_id, person_name FROM [Person]";
                using (command = new SqlCommand(personSql, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox_person.Items.Add(new ComboBoxItem { Text = reader["person_name"].ToString(), Value = reader["person_id"] });
                    }
                }

                // 加載現有公司資料
                string companySql = "SELECT company_id, company_name FROM [Company]";
                using (command = new SqlCommand(companySql, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox_company.Items.Add(new ComboBoxItem { Text = reader["company_name"].ToString(), Value = reader["company_id"] });
                    }
                }

                comboBox_person.DisplayMember = "Text";
                comboBox_person.ValueMember = "Value";

                comboBox_company.DisplayMember = "Text";
                comboBox_company.ValueMember = "Value";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 建立 SQL 連線
            using (conn = new SqlConnection("Data Source=MIFFY-LAPTOP; Initial Catalog=Punch_System; Integrated Security=false; user id=sqldba; password=123456"))
            {
                conn.Open();

                int personId;
                int companyId;

                // 判斷是否選擇使用現有個人資料
                if (checkBox_person.Checked)
                {
                    if (comboBox_person.SelectedItem == null)
                    {
                        MessageBox.Show("請選擇現有的個人資料！");
                        return;
                    }
                    personId = (int)((ComboBoxItem)comboBox_person.SelectedItem).Value;
                }
                else
                {
                    // 插入新的個人資料
                    string insertPersonSql = "INSERT INTO [Person] (person_name) OUTPUT INSERTED.person_id VALUES (@person_name)";
                    using (command = new SqlCommand(insertPersonSql, conn))
                    {
                        command.Parameters.AddWithValue("@person_name", textBox_personName.Text);
                        personId = (int)command.ExecuteScalar();
                    }
                }

                // 判斷是否選擇使用現有公司資料
                if (checkBox_company.Checked)
                {
                    if (comboBox_company.SelectedItem == null)
                    {
                        MessageBox.Show("請選擇現有的公司資料！");
                        return;
                    }
                    companyId = (int)((ComboBoxItem)comboBox_company.SelectedItem).Value;
                }
                else
                {
                    // 插入新的公司資料
                    string insertCompanySql = @"INSERT INTO [Company] (company_name, Address, tel) OUTPUT INSERTED.company_id 
                                                VALUES (@company_name, @Address, @tel)";
                    using (command = new SqlCommand(insertCompanySql, conn))
                    {
                        command.Parameters.AddWithValue("@company_name", textBox_companyName.Text);
                        command.Parameters.AddWithValue("@Address", textBox_companyAddress.Text);
                        command.Parameters.AddWithValue("@tel", textBox_companyTel.Text);
                        companyId = (int)command.ExecuteScalar();
                    }
                }

                // 插入 User 資料
                string insertUserSql = @"INSERT INTO [User] (company_id, person_id, name, password, passwordSalt, status, type) 
                                        VALUES (@company_id, @person_id, @username, @psw_hash, @salt, 'active', @type);";

                using (command = new SqlCommand(insertUserSql, conn))
                {
                    // 添加參數
                    command.Parameters.AddWithValue("@username", textBox1.Text);
                    command.Parameters.AddWithValue("@person_id", personId);
                    command.Parameters.AddWithValue("@company_id", companyId);
                    command.Parameters.AddWithValue("@type", comboBox1.Text);

                    // 產生salt、密碼hash
                    byte[] salt = GenerateSalt();
                    byte[] psw_hash = GeneratePasswordHash(salt);
                    command.Parameters.AddWithValue("@salt", Convert.ToBase64String(salt));
                    command.Parameters.AddWithValue("@psw_hash", Convert.ToBase64String(psw_hash));

                    // 執行命令
                    command.ExecuteNonQuery();
                }

                // 註冊成功，提示使用者並關閉 Form2
                MessageBox.Show("註冊成功！請重新登入！");

                // 開啟Form1（登入頁面）
                Form1 f1 = new Form1();
                f1.Show();
                this.Close(); // 關閉當前的 Form2
            }
        }

        private void checkBox_person_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_person.Enabled = checkBox_person.Checked;
            textBox_personName.Enabled = !checkBox_person.Checked;
        }

        private void checkBox_company_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_company.Enabled = checkBox_company.Checked;
            textBox_companyName.Enabled = !checkBox_company.Checked;
            textBox_companyAddress.Enabled = !checkBox_company.Checked;
            textBox_companyTel.Enabled = !checkBox_company.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close(); // 關閉當前的 Form2
        }

        private class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
