namespace SqlLogin
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
            this.button_next = new System.Windows.Forms.Button();
            this.button_read = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_first = new System.Windows.Forms.Button();
            this.button_last = new System.Windows.Forms.Button();
            this.button_final = new System.Windows.Forms.Button();
            this.button_id = new System.Windows.Forms.Button();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(410, 246);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(105, 58);
            this.button_next.TabIndex = 11;
            this.button_next.Text = "下一筆";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_read
            // 
            this.button_read.Location = new System.Drawing.Point(77, 246);
            this.button_read.Name = "button_read";
            this.button_read.Size = new System.Drawing.Size(105, 58);
            this.button_read.TabIndex = 12;
            this.button_read.Text = "讀取";
            this.button_read.UseVisualStyleBackColor = true;
            this.button_read.Click += new System.EventHandler(this.button_read_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(177, 169);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(223, 25);
            this.textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(177, 127);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(223, 25);
            this.textBox3.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(177, 89);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(223, 25);
            this.textBox2.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(177, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 25);
            this.textBox1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "ListPrice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "ProductNumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "ProductID";
            // 
            // button_first
            // 
            this.button_first.Location = new System.Drawing.Point(188, 246);
            this.button_first.Name = "button_first";
            this.button_first.Size = new System.Drawing.Size(105, 58);
            this.button_first.TabIndex = 13;
            this.button_first.Text = "第一筆";
            this.button_first.UseVisualStyleBackColor = true;
            this.button_first.Click += new System.EventHandler(this.button_first_Click);
            // 
            // button_last
            // 
            this.button_last.Location = new System.Drawing.Point(299, 246);
            this.button_last.Name = "button_last";
            this.button_last.Size = new System.Drawing.Size(105, 58);
            this.button_last.TabIndex = 14;
            this.button_last.Text = "上一筆";
            this.button_last.UseVisualStyleBackColor = true;
            this.button_last.Click += new System.EventHandler(this.button_last_Click);
            // 
            // button_final
            // 
            this.button_final.Location = new System.Drawing.Point(521, 246);
            this.button_final.Name = "button_final";
            this.button_final.Size = new System.Drawing.Size(105, 58);
            this.button_final.TabIndex = 15;
            this.button_final.Text = "最後一筆";
            this.button_final.UseVisualStyleBackColor = true;
            this.button_final.Click += new System.EventHandler(this.button_final_Click);
            // 
            // button_id
            // 
            this.button_id.Location = new System.Drawing.Point(521, 326);
            this.button_id.Name = "button_id";
            this.button_id.Size = new System.Drawing.Size(105, 40);
            this.button_id.TabIndex = 16;
            this.button_id.Text = "找指定筆數";
            this.button_id.UseVisualStyleBackColor = true;
            this.button_id.Click += new System.EventHandler(this.button_id_Click);
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(77, 336);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(433, 25);
            this.textBox_id.TabIndex = 17;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.button_id);
            this.Controls.Add(this.button_final);
            this.Controls.Add(this.button_last);
            this.Controls.Add(this.button_first);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_read);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_read;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_first;
        private System.Windows.Forms.Button button_last;
        private System.Windows.Forms.Button button_final;
        private System.Windows.Forms.Button button_id;
        private System.Windows.Forms.TextBox textBox_id;
    }
}