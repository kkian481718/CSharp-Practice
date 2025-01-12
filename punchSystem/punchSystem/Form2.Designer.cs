namespace punchSystem
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox_person = new System.Windows.Forms.ComboBox();
            this.checkBox_person = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_company = new System.Windows.Forms.CheckBox();
            this.comboBox_company = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_personName = new System.Windows.Forms.TextBox();
            this.textBox_companyName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_companyAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_companyTel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("源雲明體 SB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(40, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. 帳號資料";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "帳號";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "密碼";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "帳號類型";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "員工",
            "公司管理者",
            "總管理者"});
            this.comboBox1.Location = new System.Drawing.Point(169, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 23);
            this.comboBox1.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(169, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 25);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(169, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(176, 25);
            this.textBox2.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 552);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 41);
            this.button1.TabIndex = 10;
            this.button1.Text = "註冊";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 552);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 41);
            this.button2.TabIndex = 11;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox_person
            // 
            this.comboBox_person.Enabled = false;
            this.comboBox_person.ForeColor = System.Drawing.Color.IndianRed;
            this.comboBox_person.FormattingEnabled = true;
            this.comboBox_person.Location = new System.Drawing.Point(169, 252);
            this.comboBox_person.Name = "comboBox_person";
            this.comboBox_person.Size = new System.Drawing.Size(176, 23);
            this.comboBox_person.TabIndex = 12;
            // 
            // checkBox_person
            // 
            this.checkBox_person.AutoSize = true;
            this.checkBox_person.ForeColor = System.Drawing.Color.IndianRed;
            this.checkBox_person.Location = new System.Drawing.Point(44, 256);
            this.checkBox_person.Name = "checkBox_person";
            this.checkBox_person.Size = new System.Drawing.Size(119, 19);
            this.checkBox_person.TabIndex = 13;
            this.checkBox_person.Text = "使用現有資料";
            this.checkBox_person.UseVisualStyleBackColor = true;
            this.checkBox_person.CheckedChanged += new System.EventHandler(this.checkBox_person_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("源雲明體 SB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(40, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "2. 個人資料";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("源雲明體 SB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(40, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "3. 任職公司資料";
            // 
            // checkBox_company
            // 
            this.checkBox_company.AutoSize = true;
            this.checkBox_company.ForeColor = System.Drawing.Color.IndianRed;
            this.checkBox_company.Location = new System.Drawing.Point(44, 395);
            this.checkBox_company.Name = "checkBox_company";
            this.checkBox_company.Size = new System.Drawing.Size(119, 19);
            this.checkBox_company.TabIndex = 17;
            this.checkBox_company.Text = "使用現有資料";
            this.checkBox_company.UseVisualStyleBackColor = true;
            this.checkBox_company.CheckedChanged += new System.EventHandler(this.checkBox_company_CheckedChanged);
            // 
            // comboBox_company
            // 
            this.comboBox_company.Enabled = false;
            this.comboBox_company.FormattingEnabled = true;
            this.comboBox_company.Location = new System.Drawing.Point(169, 391);
            this.comboBox_company.Name = "comboBox_company";
            this.comboBox_company.Size = new System.Drawing.Size(176, 23);
            this.comboBox_company.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "姓名";
            // 
            // textBox_personName
            // 
            this.textBox_personName.Location = new System.Drawing.Point(169, 284);
            this.textBox_personName.Name = "textBox_personName";
            this.textBox_personName.Size = new System.Drawing.Size(176, 25);
            this.textBox_personName.TabIndex = 19;
            // 
            // textBox_companyName
            // 
            this.textBox_companyName.Location = new System.Drawing.Point(169, 420);
            this.textBox_companyName.Name = "textBox_companyName";
            this.textBox_companyName.Size = new System.Drawing.Size(176, 25);
            this.textBox_companyName.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "公司名稱";
            // 
            // textBox_companyAddress
            // 
            this.textBox_companyAddress.Location = new System.Drawing.Point(169, 451);
            this.textBox_companyAddress.Name = "textBox_companyAddress";
            this.textBox_companyAddress.Size = new System.Drawing.Size(176, 25);
            this.textBox_companyAddress.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 461);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "公司電話";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 492);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "公司地址";
            // 
            // textBox_companyTel
            // 
            this.textBox_companyTel.Location = new System.Drawing.Point(169, 482);
            this.textBox_companyTel.Name = "textBox_companyTel";
            this.textBox_companyTel.Size = new System.Drawing.Size(176, 25);
            this.textBox_companyTel.TabIndex = 25;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 618);
            this.Controls.Add(this.textBox_companyTel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_companyAddress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_companyName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_personName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBox_company);
            this.Controls.Add(this.comboBox_company);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox_person);
            this.Controls.Add(this.comboBox_person);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox_person;
        private System.Windows.Forms.CheckBox checkBox_person;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_company;
        private System.Windows.Forms.ComboBox comboBox_company;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_personName;
        private System.Windows.Forms.TextBox textBox_companyName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_companyAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_companyTel;
    }
}