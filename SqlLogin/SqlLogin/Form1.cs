using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlLogin
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 連結 SQL Server
            label_status.Text = "正在嘗試連接SQL...";
            conn = new SqlConnection("Data Source=MIFFY-LAPTOP; Initial Catalog=AdventureWorks2022; Integrated Security=false; user id=sqluser; password=123456");
            conn.Open();

            // 1. 合併 Person.Person 和 Person.Password
            // 2. 找 @FirstName 和 @LastName 符合輸入結果的值
            command = new SqlCommand("SELECT P.BusinessEntityID, P.FirstName, P.LastName, P.MiddleName, P.Suffix, PW.PasswordHash, PW.PasswordSalt FROM Person.Person P INNER JOIN Person.Password PW ON P.BusinessEntityID=PW.BusinessEntityID WHERE P.FirstName=@FirstName AND P.LastName=@LastName", conn);

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar);
            command.Parameters.Add("@LastName", SqlDbType.NVarChar);
            command.Parameters["@FirstName"].Value = textBox1.Text;
            command.Parameters["@LastName"].Value = textBox2.Text;

            //command.ExecuteNonQuery();    // 只會回傳該動作修改了幾筆資料
            dataReader = command.ExecuteReader();    // 會回傳SELECT的資料
            if (dataReader.HasRows == false)
            {
                // 如果沒收到值
                MessageBox.Show("帳號或密碼錯誤");
                label_status.Text = "就緒";
            }
            else
            {
                // 如果有收到值：判斷密碼是否正確
                dataReader.Read();

                source = Encoding.Default.GetBytes(textBox3.Text);  // 把 "輸入密碼" 轉成二進制
                salt = Convert.FromBase64String(dataReader["PasswordSalt"].ToString());     // 把 "資料庫抓到的salt" 轉換 Base64 => ASCII => 二進制
                sourceAndSalt = source.Concat(salt).ToArray();      // 密碼 + salt
                crypto = HASH.ComputeHash(sourceAndSalt);

                // DEBUG
                MessageBox.Show(dataReader["PasswordHash"].ToString() + "\n" + Convert.ToBase64String(crypto));

                if (Convert.ToBase64String(crypto) == dataReader["PasswordHash"].ToString())
                {
                    MessageBox.Show("登入成功！");
                    Form2 fm2 = new Form2();
                    // fm2.Show(); // 會可以和原本的 form1 互動
                    fm2.ShowDialog();   // 禁用其他視窗
                }
                else
                {
                    MessageBox.Show("帳號或密碼錯誤");
                }
            }
        }
    }
}
