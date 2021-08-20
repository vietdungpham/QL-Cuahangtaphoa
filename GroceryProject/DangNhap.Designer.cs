
namespace GroceryProject
{
    partial class DangNhap
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.txt_passWord = new System.Windows.Forms.TextBox();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.ptb_iconava = new System.Windows.Forms.PictureBox();
            this.lbl_login = new System.Windows.Forms.Label();
            this.ptb_title = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_iconava)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_title)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.btn_login);
            this.panel1.Controls.Add(this.lbl_pass);
            this.panel1.Controls.Add(this.lbl_user);
            this.panel1.Controls.Add(this.txt_passWord);
            this.panel1.Controls.Add(this.txt_userName);
            this.panel1.Controls.Add(this.ptb_iconava);
            this.panel1.Controls.Add(this.lbl_login);
            this.panel1.Location = new System.Drawing.Point(0, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 275);
            this.panel1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Century", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(250, 186);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 24);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Hiện mật khẩu";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // btn_login
            // 
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_login.Font = new System.Drawing.Font("Bahnschrift Condensed", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Location = new System.Drawing.Point(409, 171);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(128, 49);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Đăng nhập";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pass.Location = new System.Drawing.Point(245, 129);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(103, 23);
            this.lbl_pass.TabIndex = 5;
            this.lbl_pass.Text = "Mật khẩu:";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_user.Location = new System.Drawing.Point(241, 88);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(107, 23);
            this.lbl_user.TabIndex = 4;
            this.lbl_user.Text = "Tài khoản:";
            // 
            // txt_passWord
            // 
            this.txt_passWord.Font = new System.Drawing.Font("Bahnschrift Condensed", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_passWord.Location = new System.Drawing.Point(354, 129);
            this.txt_passWord.Name = "txt_passWord";
            this.txt_passWord.PasswordChar = '*';
            this.txt_passWord.Size = new System.Drawing.Size(183, 27);
            this.txt_passWord.TabIndex = 1;
            // 
            // txt_userName
            // 
            this.txt_userName.Font = new System.Drawing.Font("Century", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userName.Location = new System.Drawing.Point(354, 88);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(183, 27);
            this.txt_userName.TabIndex = 0;
            this.txt_userName.Text = "Mã nhân viên";
            // 
            // ptb_iconava
            // 
            this.ptb_iconava.Image = global::GroceryProject.Properties.Resources.user;
            this.ptb_iconava.Location = new System.Drawing.Point(72, 71);
            this.ptb_iconava.Name = "ptb_iconava";
            this.ptb_iconava.Size = new System.Drawing.Size(150, 149);
            this.ptb_iconava.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_iconava.TabIndex = 1;
            this.ptb_iconava.TabStop = false;
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_login.Location = new System.Drawing.Point(335, 19);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(133, 36);
            this.lbl_login.TabIndex = 0;
            this.lbl_login.Text = "ĐĂNG NHẬP";
            // 
            // ptb_title
            // 
            this.ptb_title.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ptb_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptb_title.Image = global::GroceryProject.Properties.Resources.titleresize;
            this.ptb_title.Location = new System.Drawing.Point(0, 0);
            this.ptb_title.Name = "ptb_title";
            this.ptb_title.Size = new System.Drawing.Size(588, 102);
            this.ptb_title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_title.TabIndex = 1;
            this.ptb_title.TabStop = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(588, 386);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptb_title);
            this.MaximizeBox = false;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_iconava)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_title)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox ptb_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ptb_iconava;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.TextBox txt_passWord;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}