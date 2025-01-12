using System.Data;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Common;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace F1411135024
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataReader dataReader;

        public Form1()
        {
            InitializeComponent();

            GetFirstname_GeneratePasswordHash();
        }

        private byte[] GenerateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[5]);

            return salt;
        }

        private byte[] GeneratePasswordHash(byte[] _salt, String pass)
        {
            byte[] psw_hash;
            byte[] input = Encoding.Default.GetBytes(pass);
            byte[] inputAndSalt = input.Concat(_salt).ToArray();

            SHA256 HASH = SHA256.Create();
            psw_hash = HASH.ComputeHash(inputAndSalt);

            return psw_hash;
        }

        private void GetFirstname_GeneratePasswordHash()
        {

            for (int i = 0; i < 59; i++)
            {
                String FirstName = "";
                String initialConnStr = "Data Source=MIFFY-LAPTOP; Initial Catalog=Media411135024; Integrated Security=false; user id=sqldba; password=123456";
                using (SqlConnection conn = new SqlConnection(initialConnStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT FirstName FROM Customer Where CustomerId = @CustomerId", conn))
                    {
                        cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = i + 1; ;
                        dataReader = cmd.ExecuteReader();    // 會回傳SELECT的資料

                        if (dataReader.HasRows == false)
                        {
                            // 如果沒收到值
                            MessageBox.Show("找FirstName錯誤");
                        }
                        else
                        {
                            // 如果有收到值：判斷密碼是否正確
                            dataReader.Read();
                            FirstName = dataReader["FirstName"].ToString();
                        }
                    }
                }

                using (SqlConnection conn = new SqlConnection(initialConnStr))
                {
                    conn.Open();
                    string insertUserSql = "UPDATE Customer SET PassHash = @PassHash, PassSalt = @PassSalt WHERE CustomerId = @CustomerId";
                    using (SqlCommand cmd = new SqlCommand(insertUserSql, conn))
                    {
                        // 產生salt、密碼hash
                        byte[] salt = GenerateSalt();
                        byte[] psw_hash = GeneratePasswordHash(salt, FirstName);
                        cmd.Parameters.Add("@PassSalt", SqlDbType.NVarChar).Value = Convert.ToBase64String(salt);
                        cmd.Parameters.Add("@PassHash", SqlDbType.NVarChar).Value = Convert.ToBase64String(psw_hash);
                        cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = i + 1;

                        // 執行命令
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            //string sql = "SELECT * FROM [User] U inner join Person P ON U.person_id = P.person_id WHERE name=@name";
            //using (SqlConnection conn = new SqlConnection(initialConnStr))
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = new SqlCommand(sql, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@name", userName);

            //        using (SqlDataReader dataReader = cmd.ExecuteReader())
            //        {
            //            if (dataReader.Read())
            //            {
            //                userObj userObj = new userObj();
            //                userObj.userId = int.Parse(dataReader["user_id"].ToString());
            //                userObj.companyId = int.Parse(dataReader["company_id"].ToString());
            //                userObj.personName = dataReader["person_name"].ToString();

            //                return userObj;
            //            }
            //            else
            //            {
            //                // 沒有讀到任何資料，表示user不存在
            //                MessageBox.Show("帳號不存在");
            //                return null;
            //            }
            //        }
            //    }
            //}

            // 註冊成功
            MessageBox.Show("全部註冊成功！");

            } // 自動關閉 conn
        }
    }
