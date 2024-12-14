namespace punchSystem
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SignInTime = new System.Windows.Forms.Label();
            this.SignOutTime = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentTime = new System.Windows.Forms.Label();
            this.label_personName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SignInTime
            // 
            this.SignInTime.AutoSize = true;
            this.SignInTime.Location = new System.Drawing.Point(167, 200);
            this.SignInTime.Name = "SignInTime";
            this.SignInTime.Size = new System.Drawing.Size(82, 15);
            this.SignInTime.TabIndex = 0;
            this.SignInTime.Text = "本日未簽到";
            // 
            // SignOutTime
            // 
            this.SignOutTime.AutoSize = true;
            this.SignOutTime.Location = new System.Drawing.Point(167, 270);
            this.SignOutTime.Name = "SignOutTime";
            this.SignOutTime.Size = new System.Drawing.Size(82, 15);
            this.SignOutTime.TabIndex = 1;
            this.SignOutTime.Text = "本日未簽退";
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSignIn.Font = new System.Drawing.Font("源雲明體 SB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSignIn.Location = new System.Drawing.Point(36, 178);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(106, 55);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "簽到";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.LightCoral;
            this.btnSignOut.Font = new System.Drawing.Font("源雲明體 SB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSignOut.Location = new System.Drawing.Point(36, 248);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(106, 55);
            this.btnSignOut.TabIndex = 3;
            this.btnSignOut.Text = "簽退";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("源雲明體 SB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(28, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "打卡系統";
            // 
            // CurrentTime
            // 
            this.CurrentTime.AutoSize = true;
            this.CurrentTime.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTime.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.CurrentTime.Location = new System.Drawing.Point(34, 90);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(156, 27);
            this.CurrentTime.TabIndex = 5;
            this.CurrentTime.Text = "00 : 00 : 00";
            // 
            // label_personName
            // 
            this.label_personName.AutoSize = true;
            this.label_personName.Location = new System.Drawing.Point(36, 148);
            this.label_personName.Name = "label_personName";
            this.label_personName.Size = new System.Drawing.Size(52, 15);
            this.label_personName.TabIndex = 6;
            this.label_personName.Text = "員工｜";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "登出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 354);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_personName);
            this.Controls.Add(this.CurrentTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.SignOutTime);
            this.Controls.Add(this.SignInTime);
            this.Name = "Form3";
            this.Text = "打卡系統（身分：員工）";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label SignInTime;
        private System.Windows.Forms.Label SignOutTime;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CurrentTime;
        private System.Windows.Forms.Label label_personName;
        private System.Windows.Forms.Button button1;
    }
}