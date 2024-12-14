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
using static punchSystem.Form1;

namespace punchSystem
{
    public partial class Form5 : Form
    {
        private string _connStr;
        private userObj _userObj;

        public Form5(string connStr, userObj userObj)
        {
            InitializeComponent();
            _connStr = connStr;
            _userObj = userObj;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            LoadCompanies();
            dgvCompanies.SelectionChanged += DgvCompanies_SelectionChanged;
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
        }

        private void LoadCompanies()
        {
            string sql = @"
            SELECT company_id, company_name, Address, tel 
            FROM Company
            ORDER BY company_name
        ";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCompanies.DataSource = dt;
                }
            }

            if (dgvCompanies.Columns["company_id"] != null)
                dgvCompanies.Columns["company_id"].Visible = false;
        }

        private void DgvCompanies_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompanies.CurrentRow != null)
            {
                int selectedCompanyId = Convert.ToInt32(dgvCompanies.CurrentRow.Cells["company_id"].Value);
                LoadUsersByCompany(selectedCompanyId);
            }
        }

        private void LoadUsersByCompany(int companyId)
        {
            string sql = @"
            SELECT user_id, name AS '使用者名稱', type AS '角色', status
            FROM [User]
            WHERE company_id=@company_id
            ORDER BY type, name
        ";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@company_id", companyId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvUsers.DataSource = dt;
                    }
                }
            }

            if (dgvUsers.Columns["user_id"] != null)
                dgvUsers.Columns["user_id"].Visible = false;

            UpdateButtonStates(); // 載入使用者清單後更新按鈕狀態
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            // 若無選擇任何使用者，預設全部按鈕先禁用
            if (dgvUsers.CurrentRow == null)
            {
                btnSetManager.Enabled = false;
                btnSetSuperAdmin.Enabled = false;
                btnSetEmployee.Enabled = false;
                return;
            }

            string currentRole = dgvUsers.CurrentRow.Cells["角色"].Value.ToString().Trim();

            // 預設全部啟用，根據情況停用
            btnSetManager.Enabled = true;
            btnSetSuperAdmin.Enabled = true;
            btnSetEmployee.Enabled = true;

            if (currentRole == "公司管理者")
            {
                btnSetManager.Enabled = false; // 已是公司管理者，不能再設定為公司管理者
            }
            else if (currentRole == "總管理者")
            {
                btnSetSuperAdmin.Enabled = false; // 已是總管理者，不能再設定為總管理者
            }
            else if (currentRole == "員工")
            {
                btnSetEmployee.Enabled = false; // 已是員工，不能再設定為員工
            }
        }

        private void btnSetManager_Click(object sender, EventArgs e)
        {
            if (!CheckSelection()) return;
            int selectedCompanyId = Convert.ToInt32(dgvCompanies.CurrentRow.Cells["company_id"].Value);
            int selectedUserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["user_id"].Value);

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    // 尋找該公司現任管理者
                    string findCurrentManagerSql = @"
                    SELECT user_id FROM [User]
                    WHERE company_id=@company_id AND type='公司管理者'
                ";

                    int? currentManagerId = null;
                    using (SqlCommand cmdFind = new SqlCommand(findCurrentManagerSql, conn, tran))
                    {
                        cmdFind.Parameters.AddWithValue("@company_id", selectedCompanyId);
                        object result = cmdFind.ExecuteScalar();
                        if (result != null)
                        {
                            currentManagerId = Convert.ToInt32(result);
                        }
                    }

                    // 將現任管理者(若有)改為員工
                    if (currentManagerId.HasValue && currentManagerId.Value != selectedUserId)
                    {
                        string demoteSql = @"
                        UPDATE [User]
                        SET type='員工'
                        WHERE user_id=@user_id
                    ";
                        using (SqlCommand cmdDemote = new SqlCommand(demoteSql, conn, tran))
                        {
                            cmdDemote.Parameters.AddWithValue("@user_id", currentManagerId.Value);
                            cmdDemote.ExecuteNonQuery();
                        }
                    }

                    // 將選擇的使用者設為公司管理者
                    string promoteSql = @"
                    UPDATE [User]
                    SET type='公司管理者'
                    WHERE user_id=@user_id
                ";
                    using (SqlCommand cmdPromote = new SqlCommand(promoteSql, conn, tran))
                    {
                        cmdPromote.Parameters.AddWithValue("@user_id", selectedUserId);
                        cmdPromote.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show("已成功設為公司管理者！");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("更新公司管理者時發生錯誤：" + ex.Message);
                }
            }

            LoadUsersByCompany(selectedCompanyId);
        }

        private void btnSetSuperAdmin_Click(object sender, EventArgs e)
        {
            if (!CheckSelection()) return;
            int selectedCompanyId = Convert.ToInt32(dgvCompanies.CurrentRow.Cells["company_id"].Value);
            int selectedUserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["user_id"].Value);

            // 設定使用者為總管理者
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                string sql = @"
                UPDATE [User]
                SET type='總管理者'
                WHERE user_id=@user_id
            ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", selectedUserId);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("已成功設為總管理者！");
                    }
                    else
                    {
                        MessageBox.Show("更新失敗，請確認使用者資訊。");
                    }
                }
            }

            LoadUsersByCompany(selectedCompanyId);
        }

        private void btnSetEmployee_Click(object sender, EventArgs e)
        {
            if (!CheckSelection()) return;
            int selectedCompanyId = Convert.ToInt32(dgvCompanies.CurrentRow.Cells["company_id"].Value);
            int selectedUserId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["user_id"].Value);

            // 設定使用者為員工
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();
                string sql = @"
                UPDATE [User]
                SET type='員工'
                WHERE user_id=@user_id
            ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", selectedUserId);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("已成功設為員工！");
                    }
                    else
                    {
                        MessageBox.Show("更新失敗，請確認使用者資訊。");
                    }
                }
            }

            LoadUsersByCompany(selectedCompanyId);
        }

        private bool CheckSelection()
        {
            if (dgvCompanies.CurrentRow == null)
            {
                MessageBox.Show("請先選擇一個公司。");
                return false;
            }

            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("請先選擇使用者。");
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.Show();
            this.Dispose();
        }
    }
}
