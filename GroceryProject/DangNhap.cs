using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GroceryProject
{
    public partial class DangNhap : Form
    {

        NHANVIEN_BLL nhanVien_BLL = new NHANVIEN_BLL();
        public DangNhap()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

        }


        private void btn_login_Click(object sender, EventArgs e)
        {
            {
                nhanVien_BLL.DangNhap(txt_userName.Text, txt_passWord.Text);
                {
                    if (nhanVien_BLL.ktDangNhap == 1)
                    {
                        if(nhanVien_BLL.LayLoaiTaiKhoan(txt_userName.Text).Equals("ADMIN"))
                        {
                            CuaSoChinh cuaSoChinh = new CuaSoChinh();
                            this.Hide();
                            cuaSoChinh.TKMK(txt_userName.Text, txt_passWord.Text);
                            MessageBox.Show("Bạn đã đăng nhập với tư cách ADMIN");
                            cuaSoChinh.ShowDialog();                                                        
                            this.Show();
                        }    
                        else if(nhanVien_BLL.LayLoaiTaiKhoan(txt_userName.Text).Equals("NV"))
                        {
                            CuaSoChinhNhanVien cuaSoChinhNhanVien = new CuaSoChinhNhanVien();
                            this.Hide();
                            cuaSoChinhNhanVien.TKMK(txt_userName.Text, txt_passWord.Text);
                            MessageBox.Show("Bạn đã đăng nhập với tư cách nhân viên");
                            cuaSoChinhNhanVien.ShowDialog();
                            this.Show();
                        }
                        else if (nhanVien_BLL.LayLoaiTaiKhoan(txt_userName.Text).Equals("VHH"))
                        {
                           
                            MessageBox.Show("Tài khoản này bị vô hiệu hóa vui lòng liên hệ ADMIN !!!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập không thành công!");
                    }
                }
            }

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_passWord.PasswordChar = '\0';
            }
            else
                txt_passWord.PasswordChar = '*';
        }
    }
}
