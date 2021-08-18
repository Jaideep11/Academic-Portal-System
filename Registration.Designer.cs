namespace flex_system_last
{
    partial class Registration
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Namet = new System.Windows.Forms.TextBox();
            this.CNICt = new System.Windows.Forms.TextBox();
            this.Signup = new System.Windows.Forms.Button();
            this.passwordt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Departmentt = new System.Windows.Forms.ComboBox();
            this.DOBt = new System.Windows.Forms.DateTimePicker();
            this.Gendert = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gender";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DOB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(88, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Department";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "CNIC";
            // 
            // Namet
            // 
            this.Namet.Location = new System.Drawing.Point(245, 49);
            this.Namet.Name = "Namet";
            this.Namet.Size = new System.Drawing.Size(200, 20);
            this.Namet.TabIndex = 5;
            this.Namet.TextChanged += new System.EventHandler(this.Namet_TextChanged);
            // 
            // CNICt
            // 
            this.CNICt.Location = new System.Drawing.Point(245, 254);
            this.CNICt.Name = "CNICt";
            this.CNICt.Size = new System.Drawing.Size(200, 20);
            this.CNICt.TabIndex = 9;
            // 
            // Signup
            // 
            this.Signup.Location = new System.Drawing.Point(288, 344);
            this.Signup.Name = "Signup";
            this.Signup.Size = new System.Drawing.Size(75, 23);
            this.Signup.TabIndex = 10;
            this.Signup.Text = "Signup";
            this.Signup.UseVisualStyleBackColor = true;
            this.Signup.Click += new System.EventHandler(this.Signup_Click);
            // 
            // passwordt
            // 
            this.passwordt.Location = new System.Drawing.Point(245, 282);
            this.passwordt.Name = "passwordt";
            this.passwordt.Size = new System.Drawing.Size(200, 20);
            this.passwordt.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password";
            // 
            // Departmentt
            // 
            this.Departmentt.FormattingEnabled = true;
            this.Departmentt.Location = new System.Drawing.Point(245, 202);
            this.Departmentt.Name = "Departmentt";
            this.Departmentt.Size = new System.Drawing.Size(200, 21);
            this.Departmentt.TabIndex = 13;
            // 
            // DOBt
            // 
            this.DOBt.Location = new System.Drawing.Point(245, 151);
            this.DOBt.Name = "DOBt";
            this.DOBt.Size = new System.Drawing.Size(200, 20);
            this.DOBt.TabIndex = 15;
            // 
            // Gendert
            // 
            this.Gendert.FormattingEnabled = true;
            this.Gendert.Location = new System.Drawing.Point(245, 103);
            this.Gendert.Name = "Gendert";
            this.Gendert.Size = new System.Drawing.Size(200, 21);
            this.Gendert.TabIndex = 13;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DOBt);
            this.Controls.Add(this.Gendert);
            this.Controls.Add(this.Departmentt);
            this.Controls.Add(this.passwordt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Signup);
            this.Controls.Add(this.CNICt);
            this.Controls.Add(this.Namet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Registration";
            this.Text = "v";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Namet;
        private System.Windows.Forms.TextBox CNICt;
        private System.Windows.Forms.Button Signup;
        private System.Windows.Forms.TextBox passwordt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Departmentt;
        private System.Windows.Forms.DateTimePicker DOBt;
        private System.Windows.Forms.ComboBox Gendert;
    }
}