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
using DTO;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace GroceryProject
{
    public partial class POSBH : Form
    {
        int indexOfDGV;
        string ngayLap = DateTime.Now.Date.ToString("MM-dd-yyyy");
        SANPHAM_BLL sanPham_BLL = new SANPHAM_BLL();
        KHACHHANG_BLL khachHang_BLL = new KHACHHANG_BLL();
        NHANVIEN_BLL nhanVien_BLL = new NHANVIEN_BLL();
        PHIEUXUAT_BLL phieuXuat_BLL = new PHIEUXUAT_BLL();
        DONGPXUAT_BLL dongPXuat_BLL = new DONGPXUAT_BLL();
        string maNV_current;
        string sdtKH;
        public POSBH()
        {
            InitializeComponent();
        }

        private void POSBH_Load(object sender, EventArgs e)
        {
            lbl_maNV.Text = maNV_current;
            lbl_hoTen.Text = nhanVien_BLL.TimNhanVien("MANV", maNV_current).Rows[0]["TENNV"].ToString();
            cbb_hanghoa.DataSource = sanPham_BLL.ChonSanPham();
            cbb_hanghoa.ValueMember = "MASP";
            cbb_hanghoa.DisplayMember = "TENSP";
            txt_tongTien.Enabled = false;
            cbb_hanghoa.SelectedIndex=0;
            txt_SDTKH.MaxLength = 10;
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            try
            {
                cbb_hanghoa.DataSource = sanPham_BLL.TimSanPham("TENSP", cbb_hanghoa.Text);
                cbb_hanghoa.DisplayMember = "TENSP";
                cbb_hanghoa.ValueMember = "MASP";
                cbb_hanghoa.DroppedDown = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoadonghd_Click(object sender, EventArgs e)
        {
            try
            {
                string tensp = cbb_hanghoa.Text;
                DataGridViewRow dgvRow = dgv_hoaDon.Rows[indexOfDGV];
                dgv_hoaDon.Rows.Remove(dgvRow);
                int tongtien = 0;
                for (int i = 0; i < dgv_hoaDon.Rows.Count; i++)
                {
                    tongtien = tongtien + Convert.ToInt32(dgv_hoaDon.Rows[i].Cells[3].Value.ToString());
                }
                txt_tongTien.Text = tongtien + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btn_themvaohoadon_Click(object sender, EventArgs e)
        {
            if (txt_soLuong.Text.Equals("0"))
            {
                MessageBox.Show("Không nhập SL bằng 0");
            }
            else
            { 
                if (string.IsNullOrWhiteSpace(txt_soLuong.Text) || string.IsNullOrWhiteSpace(cbb_hanghoa.Text))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ");
                }
                else if (Convert.ToInt32(txt_slCon.Text) < Convert.ToInt32(txt_soLuong.Text))
                {
                    MessageBox.Show("Không còn đủ hàng !!!");
                }
                else
                {
                    int kiemtratrunghang = 0;
                    string sanpham = cbb_hanghoa.Text;
                    if (dgv_hoaDon.Rows.Count >= 1)
                    {
                        for (int i = 0; i < dgv_hoaDon.Rows.Count; i++)
                        {
                            if (sanpham.Equals(dgv_hoaDon.Rows[i].Cells[0].Value.ToString()))
                            {
                                kiemtratrunghang = 1;
                                break;
                            }

                        }
                    }

                    if (kiemtratrunghang == 1)
                    {
                        MessageBox.Show("Đã có mặt hàng này !!!");
                    }
                    else
                    {
                        //CHƯA CÓ MẶT HÀNG TRONG HÓA ĐƠN
                        string tenSP = sanPham_BLL.ThemDSMua(cbb_hanghoa.SelectedValue.ToString()).Rows[0][0].ToString();
                        string donGiaXuat = sanPham_BLL.ThemDSMua(cbb_hanghoa.SelectedValue.ToString()).Rows[0][1].ToString();
                        int thanhTien = Convert.ToInt32(donGiaXuat) * Convert.ToInt32(txt_soLuong.Text);
                        this.dgv_hoaDon.Rows.Add(tenSP, donGiaXuat, txt_soLuong.Text, thanhTien.ToString());
                        kiemtratrunghang = 0;
                    }
                    int tongtien = 0;
                    for (int i = 0; i < dgv_hoaDon.Rows.Count; i++)
                    {
                        tongtien = tongtien + Convert.ToInt32(dgv_hoaDon.Rows[i].Cells[3].Value.ToString());
                    }
                    txt_tongTien.Text = tongtien + " VND";
                }
            }
                                    
        }

        private void dgv_hoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexOfDGV = e.RowIndex;
            MessageBox.Show(e.RowIndex.ToString());
        }

        private void txt_soLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbb_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //private void cbb_sdt_TextUpdate(object sender, EventArgs e)
        //{
        //    sdtmoi = cbb_tenKH.Text;
        //}
        public void funData(string maNV)
        {
            maNV_current = maNV;
        }

        private void btn_thanhToan_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrWhiteSpace(txt_SDTKH.Text) || string.IsNullOrWhiteSpace(txt_tenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu khách hàng!!!");
            }    
            else if (khachHang_BLL.KTTonTaiKH(txt_SDTKH.Text, txt_SDTKH.Text) == true)
            {
                //ĐÃ TỒN TẠI KHÁCH HÀNG
                //TẠO HÓA ĐƠN
                try
                {
                    DataTable temp = new DataTable();
                    temp = phieuXuat_BLL.ToanBoPhieuXuat();
                    string maPX = "PX0" + temp.Rows.Count.ToString();
                    PHIEUXUAT phieuXuat = new PHIEUXUAT(maPX, txt_SDTKH.Text, maNV_current, DateTime.Parse(ngayLap));
                    phieuXuat_BLL.ThemPhieuXuat(phieuXuat);
                    for (int i = 0; i < dgv_hoaDon.RowCount ; i++)
                    {
                        string maSP = sanPham_BLL.LayMASP(dgv_hoaDon.Rows[i].Cells[0].Value.ToString()).Rows[0][0].ToString();
                        string sl = dgv_hoaDon.Rows[i].Cells[2].Value.ToString();
                        string dongia = dgv_hoaDon.Rows[i].Cells[1].Value.ToString();
                        DONGPX temp_dongPX = new DONGPX(maPX, maSP, sl, dongia);
                        dongPXuat_BLL.ThemDongPXuat(temp_dongPX);
                    }
                    MessageBox.Show("Thành công!");
                    DialogResult dlr = MessageBox.Show("In hóa đơn", "Thông báo", MessageBoxButtons.YesNo);
                    if (dlr == DialogResult.Yes)
                    {
                        this.InHoaDon(maPX);
                    }
                    refreshForm();
                }
                catch (Exception)
                {
                    MessageBox.Show("Thất bại!");

                }
            }
            else
            {
                //CHƯA TỒN TẠI KHÁCH HÀNG
                //THÊM MỚI KHÁCH HÀNG
                try
                {                    
                    khachHang_BLL.ThemKhachHang(txt_SDTKH.Text,txt_tenKH.Text,txt_SDTKH.Text);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                //TẠO HÓA ĐƠN
                try
                {
                    DataTable temp = new DataTable();
                    temp = phieuXuat_BLL.ToanBoPhieuXuat();
                    string maPX = "PX0" + temp.Rows.Count.ToString();
                    PHIEUXUAT phieuXuat = new PHIEUXUAT(maPX, txt_SDTKH.Text, maNV_current, DateTime.Parse(ngayLap));
                    phieuXuat_BLL.ThemPhieuXuat(phieuXuat);
                    for (int i = 0; i < dgv_hoaDon.RowCount ; i++)
                    {
                        string maSP = sanPham_BLL.LayMASP(dgv_hoaDon.Rows[i].Cells[0].Value.ToString()).Rows[0][0].ToString();
                        string sl = dgv_hoaDon.Rows[i].Cells[2].Value.ToString();
                        string dongia = dgv_hoaDon.Rows[i].Cells[1].Value.ToString();
                        DONGPX temp_dongPX = new DONGPX(maPX, maSP, sl, dongia);
                        dongPXuat_BLL.ThemDongPXuat(temp_dongPX);
                    }
                    MessageBox.Show("Thành công!");
                    DialogResult dlr = MessageBox.Show("In hóa đơn", "Thông báo", MessageBoxButtons.YesNo);
                    if (dlr == DialogResult.Yes)
                    {
                        this.InHoaDon(maPX);
                    }
                    refreshForm();
                }
                catch (Exception)
                {
                    MessageBox.Show("Thất bại!");

                }
            }
            
        }

        private void btn_huyPhieu_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void cbb_hanghoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sanPham_BLL.LaySLTonKho(cbb_hanghoa.SelectedValue.ToString()).Rows.Count==0)
            {

            }    
            else
            {
                txt_slCon.Text = sanPham_BLL.LaySLTonKho(cbb_hanghoa.SelectedValue.ToString()).Rows[0][0].ToString();
            }    
        }
        public int lengthsdt;
        private void txt_SDTKH_TextChanged(object sender, EventArgs e)
        {
            lengthsdt = txt_SDTKH.Text.Length;
            if(lengthsdt==0)
            {

            }
            else if(khachHang_BLL.KTTonTaiKH(txt_SDTKH.Text,"") ==true)
            {
                txt_tenKH.Text = khachHang_BLL.TimKhachHang("MAKH", txt_SDTKH.Text).Rows[0][1].ToString();
                lengthsdt = txt_SDTKH.Text.Length;
            } 
        }

        private void txt_SDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_tenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void refreshForm()
        {
            txt_soLuong.Text = "";
            cbb_hanghoa.SelectedIndex = 0;
            txt_SDTKH.Text = "";
            txt_tenKH.Text = "";
            dgv_hoaDon.Rows.Clear();
            dgv_hoaDon.Refresh();
            txt_tongTien.Text = "";
        }
        private void InHoaDon(string maPX)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;

            int hang = 0, cot = 0;
            DataTable thongTinHD, dongHD;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 8;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "MINISTOP";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Khu đô thị Xa La - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (09)85725206";
            exRange.Range["C2:E2"].Font.Size = 20;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            thongTinHD = phieuXuat_BLL.InHoaDon(maPX);
            exRange.Range["A6:B9"].Font.Size = 12;
            exRange.Range["A6:A6"].Value = "Mã hóa đơn:";
            exRange.Range["B6:C6"].MergeCells = true;
            exRange.Range["B6:C6"].Value = thongTinHD.Rows[0][0].ToString();
            exRange.Range["A7:A7"].Value = "Khách hàng:";
            exRange.Range["B7:C7"].MergeCells = true;
            exRange.Range["B7:C7"].Value = thongTinHD.Rows[0][2].ToString();
            exRange.Range["A8:A8"].Value = "Nhân viên:";
            exRange.Range["B8:C8"].MergeCells = true;
            exRange.Range["B8:C8"].Value = thongTinHD.Rows[0][3].ToString();
            exRange.Range["A9:A9"].Value = "Ngày xuất:";
            exRange.Range["B9:C9"].MergeCells = true;
            exRange.Range["B9:C9"].Value = thongTinHD.Rows[0][1].ToString();
            dongHD = dongPXuat_BLL.ToanBoSanPham(maPX);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 20;
            exRange.Range["A11:A11"].Value = "Mã hàng";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Thành tiền";
            for (hang = 0; hang < dongHD.Rows.Count; hang++)
            {
                for (cot = 0; cot < dongHD.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 1][hang + 12] = dongHD.Rows[hang][cot].ToString();
                }
            }
            exRange = exSheet.Cells[cot - 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "=SUM(E12:E" + (dongHD.Rows.Count + 11).ToString() + ")";
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }
    }
}
