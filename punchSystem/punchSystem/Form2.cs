using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace punchSystem
{
    public partial class Form2 : Form
    {
        SqlConnection conn;
        SqlCommand command;

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
        
        private void button1_Click(object sender, EventArgs e)
        {
            // 建立 SQL 連線
            using (conn = new SqlConnection("Data Source=MIFFY-LAPTOP; Initial Catalog=Punch_System; Integrated Security=false; user id=sqldba; password=123456"))
            {
                conn.Open();

                // 插入 user
                string insertUserSql = @"INSERT INTO [User] (company_id, person_id, name, password, passwordSalt, status, type) 
                                    VALUES (@company_id, @person_id, @username, @psw_hash, @salt, 'active', @type);";

                using (command = new SqlCommand(insertUserSql, conn))
                {
                    // 添加參數
                    command.Parameters.Add("@username", SqlDbType.NVarChar).Value = textBox1.Text;
                    command.Parameters.Add("@person_id", SqlDbType.Int).Value = int.Parse(textBox3.Text);
                    command.Parameters.Add("@company_id", SqlDbType.Int).Value = int.Parse(textBox4.Text);
                    command.Parameters.Add("@type", SqlDbType.NVarChar).Value = comboBox1.Text;

                    // 產生salt、密碼hash
                    byte[] salt = GenerateSalt();
                    byte[] psw_hash = GeneratePasswordHash(salt);
                    command.Parameters.Add("@salt", SqlDbType.NVarChar).Value = Convert.ToBase64String(salt);
                    command.Parameters.Add("@psw_hash", SqlDbType.NVarChar).Value = Convert.ToBase64String(psw_hash);

                    // 執行命令
                    command.ExecuteNonQuery();
                }

                // 註冊成功，提示使用者並關閉 Form2
                MessageBox.Show("註冊成功！請重新登入！");

                // 開啟Form1（登入頁面）
                // TODO: 傳回帳號
                Form1 f1 = new Form1();
                f1.Show();
                this.Close(); // 關閉當前的 Form2

            } // 自動關閉 conn
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close(); // 關閉當前的 Form2
        }
    }
}
