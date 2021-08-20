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
    public partial class BaoCao : Form
    {
        DONGPXUAT_BLL dongPXuat_BLL = new DONGPXUAT_BLL();
        DONGPNHAP_BLL dongPNhap_BLL = new DONGPNHAP_BLL();
        public BaoCao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbl_tongHDX.Text = "";
            lbl_giaTriTB.Text = "";
            lbl_slHangTB.Text = "";
            lbl_gtTBHDNhap.Text = "";
            lbl_slHangTBNhap.Text = "";
            lbl_tongHDNhap.Text = "";
            lbl_tongGTXuat.Text = "";
            if (dtp1.Value > dtp2.Value)
            {
                MessageBox.Show("Ngày sau phải lớn hơn hoặc bằng ngày trước!!!");
            }
            else
            {
                dgvxuat.DataSource = dongPXuat_BLL.BaoCaoDS(dtp1.Value, dtp2.Value);
                dgvnhap.DataSource = dongPNhap_BLL.BaoCaoDS(dtp1.Value, dtp2.Value);
            }
            if (dgvxuat.RowCount != 0)
            {
                int tongGTXuat = 0;
                int tongSLHang = 0;
                for(int i = 0; i < dgvxuat.RowCount; i++)
                {
                    tongGTXuat += Convert.ToInt32(dgvxuat.Rows[i].Cells[4].Value.ToString());
                    tongSLHang += Convert.ToInt32(dgvxuat.Rows[i].Cells[2].Value.ToString());
                }
                lbl_tongGTXuat.Text = tongGTXuat.ToString() + " VND";
                lbl_tongHDX.Text = dgvxuat.RowCount.ToString();
                lbl_giaTriTB.Text = (tongGTXuat / Convert.ToInt32(lbl_tongHDX.Text)).ToString() + " VND";
                lbl_slHangTB.Text = (tongSLHang / Convert.ToInt32(lbl_tongHDX.Text)).ToString();
            }
            if (dgvnhap.RowCount != 0)
            {
                int tongGTNhap = 0;
                int tongSLHangNhap = 0;
                for (int i = 0; i < dgvnhap.RowCount; i++)
                {
                    tongGTNhap += Convert.ToInt32(dgvnhap.Rows[i].Cells[4].Value.ToString());
                    tongSLHangNhap += Convert.ToInt32(dgvnhap.Rows[i].Cells[2].Value.ToString());
                }
                lbl_tongGTNhap.Text = tongGTNhap.ToString() + " VND";
                lbl_tongHDNhap.Text = dgvnhap.RowCount.ToString();
                lbl_gtTBHDNhap.Text = (tongGTNhap / Convert.ToInt32(lbl_tongHDNhap.Text)).ToString() + " VND";
                lbl_slHangTBNhap.Text = (tongSLHangNhap / Convert.ToInt32(lbl_tongHDNhap.Text)).ToString();
            }
        }
    }
}
