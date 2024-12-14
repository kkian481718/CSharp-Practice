using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace punchSystem
{
    public partial class Form3 : Form
    {
        private string _connStr;
        private string _personName;
        private int _userId;
        private int _companyId;

        public Form3(string connStr, int userId, string userName, int companyId)
        {
            InitializeComponent();
            _connStr = connStr;
            _userId = userId;
            _personName = userName;
            _companyId = companyId;

            // 設定Timer
            timer1.Interval = 1000; // 每1秒更新時間
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            // 初始化UI
            SignInTime.Text = "本日未簽到";
            SignOutTime.Text = "本日未簽退";
            label_personName.Text = "員工｜" + _personName;

            // 載入當日狀態
            LoadTodayStatus();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            // 即時顯示目前時間
            CurrentTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void LoadTodayStatus()
        {
            // 查詢當日簽到、簽退紀錄
            // 假設同一個人一天只會有兩筆 sign-in-and-out 資料（可透過日期判斷）
            string sql = @"
            SELECT TOP 2 time, punch_type
            FROM [Sign-in-and-out]
            WHERE user_id=@user_id
              AND CONVERT(date, time) = @today
            ORDER BY time ASC";

            DateTime today = DateTime.Now.Date;
            DateTime? signInTime = null;
            DateTime? signOutTime = null;

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.Parameters.AddWithValue("@today", today);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string punchType = dr["punch_type"].ToString().Trim();
                            DateTime punchTime = (DateTime)dr["time"];

                            if (punchType == "sign-in" && signInTime == null)
                            {
                                signInTime = punchTime;
                            }
                            else if (punchType == "sign-out" && signOutTime == null)
                            {
                                signOutTime = punchTime;
                            }
                        }
                    }
                }
            }

            if (signInTime == null)
            {
                // 今日尚未簽到
                btnSignIn.Enabled = true;
                btnSignOut.Enabled = false;
            }
            else
            {
                // 今日已簽到
                SignInTime.Text = "簽到時間：" + signInTime.Value.ToString("HH:mm:ss");
                btnSignIn.Enabled = false;

                if (signOutTime == null)
                {
                    // 尚未簽退
                    btnSignOut.Enabled = true;
                }
                else
                {
                    // 已簽退
                    SignOutTime.Text = "簽退時間：" + signOutTime.Value.ToString("HH:mm:ss");
                    btnSignOut.Enabled = false;
                }
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string sql = @"
            INSERT INTO [sign-in-and-out](company_id, user_id, time, punch_type)
            VALUES(@company_id, @user_id, @time, @punch_type)";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@company_id", _companyId);
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@punch_type", "sign-in");

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("簽到成功！");
            LoadTodayStatus();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            string sql = @"
        INSERT INTO [sign-in-and-out](company_id, user_id, time, punch_type)
        VALUES(@company_id, @user_id, @time, @punch_type)
    ";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@company_id", _companyId);
                    cmd.Parameters.AddWithValue("@user_id", _userId);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@punch_type", "sign-out");

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("簽退成功！");
            LoadTodayStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Show();
            this.Close();
        }
    }
}
