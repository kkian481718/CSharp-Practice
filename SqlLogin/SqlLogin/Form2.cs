using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlLogin
{
    public partial class Form2 : Form
    {
        SqlConnection conn;
        SqlCommand command;
        SqlDataReader dataReader;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 連接SQL Server
            conn = new SqlConnection("Data Source=MIFFY-LAPTOP; Initial Catalog=AdventureWorks2022; Integrated Security=false; user id=sqluser; password=123456");
            conn.Open();

            // 查詢產品價格
            command = new SqlCommand("SELECT [ProductID], [Name], [ProductNumber], [ListPrice] FROM [AdventureWorks2022].[Production].[Product] WHERE [FinishedGoodsFlag] = 1", conn);

            //command.ExecuteNonQuery();    // 只會回傳該動作修改了幾筆資料
            dataReader = command.ExecuteReader();    // 會回傳SELECT的資料
            if (dataReader.HasRows)
            {
                dataReader.Read();
                textBox1.Text = dataReader["ProductID"].ToString();
                textBox2.Text = dataReader["Name"].ToString();
                textBox3.Text = dataReader["ProductNumber"].ToString();
                textBox4.Text = dataReader["ListPrice"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataReader.Read();
            textBox1.Text = dataReader["ProductID"].ToString();
            textBox2.Text = dataReader["Name"].ToString();
            textBox3.Text = dataReader["ProductNumber"].ToString();
            textBox4.Text = dataReader["ListPrice"].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.Show();
        }
    }
}
