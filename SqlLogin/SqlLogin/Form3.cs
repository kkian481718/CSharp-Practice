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

namespace SqlLogin
{
    public partial class Form3 : Form
    {
        SqlConnection DBConnection;
        SqlCommand DBCommand;
        SqlDataAdapter DBAdapter;   // 可以一次載入資料並丟入 Data table
        DataTable DBTable = new DataTable();
        bool IsFill = false;    
        int RNo = 0;    // 紀錄現在的 Record Number

        public Form3()
        {
            InitializeComponent();
        }

        private void update_textBox(int _RNo)
        {
            textBox1.Text = DBTable.Rows[_RNo]["ProductID"].ToString();
            textBox2.Text = DBTable.Rows[_RNo]["Name"].ToString();
            textBox3.Text = DBTable.Rows[_RNo]["ProductNumber"].ToString();
            textBox4.Text = DBTable.Rows[_RNo]["ListPrice"].ToString();
        }

        private void read_data()
        {
            DBConnection = new SqlConnection(@"Data Source=MIFFY-LAPTOP; Initial Catalog=AdventureWorks2022; Integrated Security=false; user id=sqluser; password=123456");
            DBConnection.Open();    // 連線SQL

            // 查詢產品價格
            DBCommand = new SqlCommand("SELECT[ProductID], [Name], [ProductNumber], [ListPrice] FROM[AdventureWorks2022].[Production].[Product] WHERE[FinishedGoodsFlag] = 1", DBConnection);

            // 使用 DataAdapter 操作資料
            DBAdapter = new SqlDataAdapter();
            DBAdapter.SelectCommand = DBCommand;
            DBAdapter.Fill(DBTable);
        }

        private void button_read_Click(object sender, EventArgs e)
        {
            // 連線並讀入資料
            read_data();
            RNo = 0;

            // 更新產品顯示資料
            update_textBox(RNo);

            // 指標移到下一筆
            RNo++;
        }

        private void button_id_Click(object sender, EventArgs e)
        {
            // 連線並讀入資料
            read_data();

            // 抓使用者輸入的 id
            RNo = Convert.ToInt32(textBox_id.Text) - 1;

            // 確保 0 <= id <= (DBTable.Rows.Count - 1)
            if (RNo < 0)
            {
                RNo = 0;
                textBox_id.Text = (RNo + 1).ToString();
            }
            else if (RNo > DBTable.Rows.Count - 1)
            {
                RNo = DBTable.Rows.Count - 1;
                textBox_id.Text = (RNo + 1).ToString();
            }

            // 更新產品顯示資料
            update_textBox(RNo);
        }

        private void button_first_Click(object sender, EventArgs e)
        {
            RNo = 0;
            update_textBox(RNo);
        }

        private void button_final_Click(object sender, EventArgs e)
        {
            RNo = DBTable.Rows.Count - 1;
            update_textBox(RNo);
        }

        private void button_last_Click(object sender, EventArgs e)
        {
            RNo--;
            if (RNo < 0)
            {
                RNo = 0;
                textBox_id.Text = (RNo + 1).ToString();
            }

            update_textBox(RNo);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            RNo++;
            if (RNo > DBTable.Rows.Count - 1)
            {
                RNo = DBTable.Rows.Count - 1;
                textBox_id.Text = (RNo + 1).ToString();
            }

            update_textBox(RNo);
        }
    }
}
