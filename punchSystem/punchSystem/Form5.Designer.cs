namespace punchSystem
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCompanies = new System.Windows.Forms.DataGridView();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnSetManager = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSetSuperAdmin = new System.Windows.Forms.Button();
            this.btnSetEmployee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompanies
            // 
            this.dgvCompanies.AllowUserToAddRows = false;
            this.dgvCompanies.AllowUserToDeleteRows = false;
            this.dgvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanies.Location = new System.Drawing.Point(47, 12);
            this.dgvCompanies.Name = "dgvCompanies";
            this.dgvCompanies.ReadOnly = true;
            this.dgvCompanies.RowHeadersWidth = 51;
            this.dgvCompanies.RowTemplate.Height = 27;
            this.dgvCompanies.Size = new System.Drawing.Size(557, 240);
            this.dgvCompanies.TabIndex = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(47, 269);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 27;
            this.dgvUsers.Size = new System.Drawing.Size(557, 240);
            this.dgvUsers.TabIndex = 1;
            // 
            // btnSetManager
            // 
            this.btnSetManager.Location = new System.Drawing.Point(198, 515);
            this.btnSetManager.Name = "btnSetManager";
            this.btnSetManager.Size = new System.Drawing.Size(166, 52);
            this.btnSetManager.TabIndex = 2;
            this.btnSetManager.Text = "設為公司管理者";
            this.btnSetManager.UseVisualStyleBackColor = true;
            this.btnSetManager.Click += new System.EventHandler(this.btnSetManager_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(541, 515);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 52);
            this.button2.TabIndex = 3;
            this.button2.Text = "登出";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSetSuperAdmin
            // 
            this.btnSetSuperAdmin.Location = new System.Drawing.Point(47, 515);
            this.btnSetSuperAdmin.Name = "btnSetSuperAdmin";
            this.btnSetSuperAdmin.Size = new System.Drawing.Size(145, 52);
            this.btnSetSuperAdmin.TabIndex = 4;
            this.btnSetSuperAdmin.Text = "設為總管理者";
            this.btnSetSuperAdmin.UseVisualStyleBackColor = true;
            this.btnSetSuperAdmin.Click += new System.EventHandler(this.btnSetSuperAdmin_Click);
            // 
            // btnSetEmployee
            // 
            this.btnSetEmployee.Location = new System.Drawing.Point(370, 515);
            this.btnSetEmployee.Name = "btnSetEmployee";
            this.btnSetEmployee.Size = new System.Drawing.Size(153, 52);
            this.btnSetEmployee.TabIndex = 5;
            this.btnSetEmployee.Text = "設為員工";
            this.btnSetEmployee.UseVisualStyleBackColor = true;
            this.btnSetEmployee.Click += new System.EventHandler(this.btnSetEmployee_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("源雲明體 SB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 95);
            this.label1.TabIndex = 6;
            this.label1.Text = "1.\r\n選\r\n擇\r\n公\r\n司";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("源雲明體 SB", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 95);
            this.label2.TabIndex = 7;
            this.label2.Text = "2.\r\n選\r\n擇\r\n員\r\n工";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 603);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetEmployee);
            this.Controls.Add(this.btnSetSuperAdmin);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSetManager);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.dgvCompanies);
            this.Name = "Form5";
            this.Text = "編輯公司管理者（身分：總管理者）";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCompanies;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnSetManager;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSetSuperAdmin;
        private System.Windows.Forms.Button btnSetEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}