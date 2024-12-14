using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static punchSystem.Form1;

namespace punchSystem
{
    public partial class Form4 : Form
    {
        private string _connStr;
        private userObj _userObj; // 包含 userId, companyId, personName
        private DataTable _currentTable; // 存放目前查詢結果，用於列印

        public Form4(string connStr, userObj user)
        {
            InitializeComponent();
            _connStr = connStr;
            _userObj = user;

            // 使用 _connStr 從資料庫載入該公司之本月簽到紀錄
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // 初始化年份、月份下拉
            int currentYear = DateTime.Now.Year;
            for (int y = currentYear - 5; y <= currentYear + 5; y++)
            {
                cboYear.Items.Add(y.ToString());
            }
            cboYear.SelectedItem = currentYear.ToString();

            for (int m = 1; m <= 12; m++)
            {
                cboMonth.Items.Add(m.ToString());
            }
            cboMonth.SelectedItem = DateTime.Now.Month.ToString();

            // 設定 DataGridView
            dgvRecords.AutoGenerateColumns = true;
            dgvRecords.ReadOnly = true;
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.AllowUserToDeleteRows = false;

            // 初始化 PrintDocument 事件
            printDocument1.PrintPage += PrintDocument1_PrintPage;

            // 初始化公司基本資訊
            LoadCompanyInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboYear.SelectedItem == null || cboMonth.SelectedItem == null)
            {
                MessageBox.Show("請選擇年份與月份");
                return;
            }

            int year = int.Parse(cboYear.SelectedItem.ToString());
            int month = int.Parse(cboMonth.SelectedItem.ToString());

            LoadMonthlyRecords(year, month);
        }

        private void LoadCompanyInfo()
        {
            // 根據 company_id 從資料庫取得公司資訊
            string sql = "SELECT company_name, Address, tel FROM [Company] WHERE company_id = @company_id";
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@company_id", _userObj.companyId);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read()) // 先讀取一筆資料
                        {
                            textBox_name.Text = dr["company_name"].ToString();
                            textBox_address.Text = dr["Address"].ToString();
                            textBox_tel.Text = dr["tel"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("找不到對應的公司資料。");
                        }
                    }
                }
            }
        }

        private void LoadMonthlyRecords(int year, int month)
        {
            string sql = @"
            SELECT u.name AS '員工帳號', s.time AS '打卡時間', s.punch_type AS '類型'
            FROM [sign-in-and-out] s
            JOIN [user] u ON s.user_id = u.user_id
            WHERE s.company_id = @company_id
              AND YEAR(s.time) = @year
              AND MONTH(s.time) = @month
            ORDER BY u.name, s.time";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@company_id", _userObj.companyId);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@month", month);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvRecords.DataSource = dt;
                        _currentTable = dt;
                    }
                }
            }

            if (_currentTable == null || _currentTable.Rows.Count == 0)
            {
                MessageBox.Show("本月份無員工簽到簽退紀錄。");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_currentTable == null || _currentTable.Rows.Count == 0)
            {
                MessageBox.Show("目前無資料可列印。");
                return;
            }

            // 顯示 PrintPreviewDialog
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        // 列印相關變數
        private int _printRowIndex = 0;
        private float _yPos = 0;
        private float _leftMargin;
        private float _topMargin;
        private float _lineHeight;
        private Font _printFont = new Font("Arial", 10);
        private int _colCount = 0;

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_currentTable == null) return;

            _leftMargin = e.MarginBounds.Left;
            _topMargin = e.MarginBounds.Top;
            _lineHeight = _printFont.GetHeight(e.Graphics);

            float currentY = _topMargin;

            // 列印標題
            string title = $"{cboYear.SelectedItem}年{cboMonth.SelectedItem}月 員工簽到簽退清單";
            e.Graphics.DrawString(title, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, _leftMargin, currentY);
            currentY += _lineHeight * 2;

            // 列印欄位標題
            _colCount = _currentTable.Columns.Count;
            float colWidth = (e.MarginBounds.Width) / _colCount;
            for (int i = 0; i < _colCount; i++)
            {
                e.Graphics.DrawString(_currentTable.Columns[i].ColumnName, _printFont, Brushes.Black, _leftMargin + i * colWidth, currentY);
            }

            currentY += _lineHeight;

            // 列印資料列
            while (_printRowIndex < _currentTable.Rows.Count)
            {
                DataRow row = _currentTable.Rows[_printRowIndex];
                float rowY = currentY;

                for (int i = 0; i < _colCount; i++)
                {
                    string cellValue = row[i].ToString();
                    e.Graphics.DrawString(cellValue, _printFont, Brushes.Black, _leftMargin + i * colWidth, rowY);
                }

                currentY += _lineHeight;
                _printRowIndex++;

                // 檢查頁面是否滿
                if (currentY + _lineHeight > e.MarginBounds.Bottom)
                {
                    // 還有資料未印完，設定HasMorePages為true
                    e.HasMorePages = true;
                    return;
                }
            }

            // 資料列印結束
            e.HasMorePages = false;
            _printRowIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 儲存公司資訊
            string sql = @"
                UPDATE [Company]
                SET company_name = @name, 
                    Address = @address, 
                    tel = @tel
                WHERE company_id = @company_id
            ";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // 從 textBox 取得使用者輸入的公司資料
                    cmd.Parameters.AddWithValue("@name", textBox_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", textBox_address.Text.Trim());
                    cmd.Parameters.AddWithValue("@tel", textBox_tel.Text.Trim());

                    // 使用 userObj 中的 companyId 作為條件
                    cmd.Parameters.AddWithValue("@company_id", _userObj.companyId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("公司資料更新成功。");
                    }
                    else
                    {
                        MessageBox.Show("更新失敗，請確認公司ID是否正確或資料內容是否無誤。");
                    }
                }
            }
        }
    }
}
