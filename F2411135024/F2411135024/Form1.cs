using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;
using System.Security.Cryptography;

namespace F2411135024
{
    public partial class Form1 : Form
    {
        SHA256 HASH = SHA256.Create();
        byte[] source;  // 存放密碼
        byte[] crypto;  // 存放 Hash 編碼的結果
        byte[] salt;    // 存放 salt 的二進制值
        byte[] sourceAndSalt; // Hash + salt
        SqlConnection conn;
        SqlCommand command;
        SqlDataReader dataReader;

        public Form1()
        {
            InitializeComponent();
            String initialConnStr = "Data Source=MIFFY-LAPTOP; Initial Catalog=Media411135024; Integrated Security=false; user id=sqldba; password=123456";
            using (SqlConnection conn = new SqlConnection(initialConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.ChDateTime(GetDate()) time", conn))
                {
                    dataReader = cmd.ExecuteReader();    // 會回傳SELECT的資料

                    if (dataReader.HasRows == false)
                    {
                        // 如果沒收到值
                        MessageBox.Show("找time錯誤");
                    }
                    else
                    {
                        // 如果有收到值：判斷密碼是否正確
                        dataReader.Read();
                        label1.Text = dataReader["time"].ToString();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String initialConnStr = "Data Source=MIFFY-LAPTOP; Initial Catalog=Media411135024; Integrated Security=false; user id=sqldba; password=123456";
            using (SqlConnection conn = new SqlConnection(initialConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE Email = @Email", conn))
                {
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = textBox1.Text;
 

                    dataReader = cmd.ExecuteReader();    // 會回傳SELECT的資料

                    if (dataReader.HasRows == false)
                    {
                        // 如果沒收到值
                        MessageBox.Show("帳號或密碼錯誤");
                    }
                    else
                    {
                        // 如果有收到值：判斷密碼是否正確
                        dataReader.Read();
                        source = Encoding.Default.GetBytes(textBox2.Text);  // 把 "輸入密碼" 轉成二進制
                        salt = Convert.FromBase64String(dataReader["PassSalt"].ToString());     // 把 "資料庫抓到的salt" 轉換 Base64 => ASCII => 二進制
                        sourceAndSalt = source.Concat(salt).ToArray();      // 密碼 + salt
                        crypto = HASH.ComputeHash(sourceAndSalt);

                        // DEBUG
                        MessageBox.Show(dataReader["PassHash"].ToString() + "\n" + Convert.ToBase64String(crypto));

                        if (Convert.ToBase64String(crypto) == dataReader["PassHash"].ToString())
                        {
                            MessageBox.Show("登入成功！");
                        
                        }
                        else
                        {
                            MessageBox.Show("帳號或密碼錯誤");
                        }
                    }
                }
            }

        
            
        }
    }
}
