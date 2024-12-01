using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data;              // 比較：只引入 System.Data 不會有SQL的功能
using System.Data.SqlClient;    // 給資料庫連線用

namespace Hash01
{
    public partial class Form1 : Form
    {
        //MD5 HASH = MD5.Create();
        //SHA1 HASH = SHA1.Create();
        SHA256 HASH = SHA256.Create();
        byte[] source;  // 存放密碼
        byte[] crypto;  // 存放 Hash 編碼的結果
        byte[] salt;    // 存放 salt 的二進制值
        byte[] sourceAndSalt; // Hash + salt
        SqlConnection conn;
        SqlCommand command;

        public Form1()
        {
            InitializeComponent();
        }

        // 產生 Hash (利用 "密碼 + salt")
        private void button1_Click(object sender, EventArgs e)
        {
            source = Encoding.Default.GetBytes(textBox1.Text);  // 把 "輸入密碼" 轉成二進制
            salt = Convert.FromBase64String(textBox2.Text);     // 把 "亂數產生的salt" 轉換 Base64 => ASCII => 二進制
            //salt = Encoding.Default.GetBytes(textBox2.Text);  // 錯誤：把 "亂數產生的salt" 轉成二進制
            
            sourceAndSalt = source.Concat(salt).ToArray();      // 密碼 + salt
            crypto = HASH.ComputeHash(sourceAndSalt);

            textBox3.Text = Convert.ToBase64String(crypto);
            label4.Text = textBox3.Text.Length.ToString();
        }

        // 清除資料
        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label4.Text = "0";
            label5.Text = "0";
        }

        // 產生salt (用 RNGCryptoServiceProvider() 產生亂數)
        private void button3_Click(object sender, EventArgs e)
        {
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[5]);
            textBox2.Text = Convert.ToBase64String(salt);
            label5.Text = textBox2.Text.Length.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            source = Encoding.Default.GetBytes(textBox1.Text);  // 把 "輸入密碼" 轉成二進制
            salt = Convert.FromBase64String(textBox2.Text);     // 把 "亂數產生的salt" 轉換 Base64 => ASCII => 二進制
            sourceAndSalt = source.Concat(salt).ToArray();      // 密碼 + salt
            crypto = HASH.ComputeHash(sourceAndSalt);

            textBox3.Text = Convert.ToBase64String(crypto);
            label4.Text = textBox3.Text.Length.ToString();

            // 連結 SQL Server
            conn = new SqlConnection("Data Source=MIFFY-LAPTOP; Initial Catalog=AdventureWorks2022; Integrated Security=false; user id=sqluser; password=123456");
            conn.Open();

            // 更新 BusinessEntityID=1 的人的密碼 hash
            command = new SqlCommand("UPDATE Person.password SET PasswordHash=@PassHash, PasswordSalt=@PassSalt WHERE BusinessEntityID=@ID", conn);
            
            command.Parameters.Add("@PassHash", SqlDbType.NVarChar);
            command.Parameters.Add("@PassSalt", SqlDbType.NVarChar);
            command.Parameters.Add("@ID", SqlDbType.NVarChar);

            command.Parameters["@PassHash"].Value = Convert.ToBase64String(crypto);
            command.Parameters["@PassSalt"].Value = Convert.ToBase64String(salt);
            command.Parameters["@ID"].Value = 1;

            command.ExecuteNonQuery();  // 執行沒有傳回資料的SQL指令 (Insert, Update, Delete)
        }
    }
}
