namespace QiangHaoQi
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Departments = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DepartmentOk = new System.Windows.Forms.Button();
            this.DocOk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Doctor = new System.Windows.Forms.ComboBox();
            this.TimeOk = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeCh = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(366, 399);
            this.textBox1.TabIndex = 0;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(661, 40);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 1;
            this.login.Text = "login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.button1_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(455, 12);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(200, 21);
            this.username.TabIndex = 2;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(455, 42);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(200, 21);
            this.password.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "username : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "password : ";
            // 
            // Departments
            // 
            this.Departments.FormattingEnabled = true;
            this.Departments.Location = new System.Drawing.Point(455, 78);
            this.Departments.Name = "Departments";
            this.Departments.Size = new System.Drawing.Size(200, 20);
            this.Departments.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "选择科室：";
            // 
            // DepartmentOk
            // 
            this.DepartmentOk.Location = new System.Drawing.Point(661, 78);
            this.DepartmentOk.Name = "DepartmentOk";
            this.DepartmentOk.Size = new System.Drawing.Size(75, 23);
            this.DepartmentOk.TabIndex = 8;
            this.DepartmentOk.Text = "Ok";
            this.DepartmentOk.UseVisualStyleBackColor = true;
            this.DepartmentOk.Click += new System.EventHandler(this.DepartmentOk_Click);
            // 
            // DocOk
            // 
            this.DocOk.Location = new System.Drawing.Point(661, 112);
            this.DocOk.Name = "DocOk";
            this.DocOk.Size = new System.Drawing.Size(75, 23);
            this.DocOk.TabIndex = 11;
            this.DocOk.Text = "Ok";
            this.DocOk.UseVisualStyleBackColor = true;
            this.DocOk.Click += new System.EventHandler(this.DocOk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "选择医生：";
            // 
            // Doctor
            // 
            this.Doctor.FormattingEnabled = true;
            this.Doctor.Location = new System.Drawing.Point(455, 112);
            this.Doctor.Name = "Doctor";
            this.Doctor.Size = new System.Drawing.Size(200, 20);
            this.Doctor.TabIndex = 9;
            // 
            // TimeOk
            // 
            this.TimeOk.Location = new System.Drawing.Point(661, 147);
            this.TimeOk.Name = "TimeOk";
            this.TimeOk.Size = new System.Drawing.Size(75, 23);
            this.TimeOk.TabIndex = 14;
            this.TimeOk.Text = "Start";
            this.TimeOk.UseVisualStyleBackColor = true;
            this.TimeOk.Click += new System.EventHandler(this.TimeOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "选择时间：";
            // 
            // TimeCh
            // 
            this.TimeCh.FormattingEnabled = true;
            this.TimeCh.Location = new System.Drawing.Point(455, 147);
            this.TimeCh.Name = "TimeCh";
            this.TimeCh.Size = new System.Drawing.Size(200, 20);
            this.TimeCh.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(661, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "选择挂号人：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(467, 183);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 20);
            this.comboBox1.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 423);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TimeOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TimeCh);
            this.Controls.Add(this.DocOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Doctor);
            this.Controls.Add(this.DepartmentOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Departments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.login);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Departments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DepartmentOk;
        private System.Windows.Forms.Button DocOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Doctor;
        private System.Windows.Forms.Button TimeOk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox TimeCh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

