using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QuanLySV
{
    public partial class MenuSinhVien : Form
    {
        /*PROPERTY*/
        // @LoginStatus: Trạng thái đăng nhập, nhận 1 trong 3 giá trị được MACRO ở trên
        // @NameUser: Tên tài khoản của user đăng nhập thành công.
        // @Date: Thời gian hiện tại của hệ thống
        // @SinhVien: OBJ đối tượng tương tác với form
        public int LoginStatus;
        public string NameUser;
        public string Date;
        private CSinhVien SinhVien;
        /**/
        public MenuSinhVien(string name)
        {
            LoginStatus = DangNhap.EXIT;
            NameUser = name;
            Date = DateTime.Now.ToString("dd-MM-yyyy");
            InitializeComponent();
        }


        /* ------------- Các sự kiện hệ thống ------------- */

        private void MenuSinhVien_Load(object sender, EventArgs e)
        {
            //lbName.Text = this.NameUser;
            //lbDate.Text = this.Date;
            getDataSinhVienFromDB();
            getDataSVToForm();
            getPicture();
        }

        /* Sự kiện click nút thoát */
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đóng chương trình?", "Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                LoginStatus = DangNhap.EXIT; // Ghi nhận trạng thái thoát khỏi chương trình
                this.Close();
            }
        }

        /* Sự kiện click nút đăng xuất */
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                LoginStatus = DangNhap.LOGOUT; // Ghi nhận trạng thái thoát khỏi chương trình
                this.Close();
            }
        }

        /*  Sự kiện click label_link tương tự sự kiện click nút Logout(đăng xuất) */
        private void llbLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất?", "Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                LoginStatus = DangNhap.LOGOUT; // Ghi nhận trạng thái thoát khỏi chương trình
                this.Close();
            }
        }

        /* Sự kiện click button đổi mật khẩu */
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau(NameUser, DangNhap.LOGIN_WITH_SINHVIEN);
            dmk.ShowDialog();
            dmk.Close();
        }

        /* click chức năng thông tin phần mềm */
        private void thôngTinPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_DangPhatTrien();
        }

        /* click chức năng trợ giúp */
        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open_DangPhatTrien();
        }

        /* ------------- Các hàm sử lý sự kiện ------------- */

        /* Load data từ DB vào một OBJ */
        void getDataSinhVienFromDB()
        {
            string query = @"SELECT * FROM SINH_VIEN
                            WHERE ma_sv = '"+ NameUser + "'";
            DB.conn.Open();
            SqlCommand cmd = new SqlCommand(query, DB.conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                SinhVien = new CSinhVien(rd[0].ToString(), rd[1].ToString(), rd[2].ToString(), rd[3].ToString(), rd[4].ToString(), rd[5].ToString(), rd[6].ToString(), rd[7].ToString(), rd[8].ToString(), rd[9].ToString(), rd[10].ToString(), rd[11].ToString(), rd[12].ToString(), rd[13].ToString(), rd[14].ToString(), rd[15].ToString(), rd[16].ToString(), rd[17].ToString(), rd[18].ToString(), rd[19].ToString(), rd[20].ToString(), rd[21].ToString(), rd[22].ToString(), rd[23].ToString(), rd[24].ToString(), rd[25].ToString(), rd[26].ToString(), rd[27].ToString(), rd[28].ToString(), rd[29].ToString(), rd[30].ToString(), rd[32].ToString(), rd[33].ToString(), rd[34].ToString(), rd[35].ToString(), rd[36].ToString(), rd[37].ToString(), rd[38].ToString(), rd[39].ToString(), rd[40].ToString(), rd[41].ToString());
            }
            DB.conn.Close();
        }
        /* Load ảnh từ DB lên Form*/
        void getPicture()
        {
            string query = "SELECT link_img_sv FROM SINH_VIEN WHERE ma_sv='" + NameUser + "'";
            DB.conn.Open();
            SqlCommand cmd = new SqlCommand(query, DB.conn);
            byte[] link = (byte[] )cmd.ExecuteScalar() ;
            DB.conn.Close(); 
            MemoryStream stream = new MemoryStream(link.ToArray());
            try
            {
                Image image = Image.FromStream(stream);
                if (image == null)
                    return;
                pbImgSV.Image = image;
            }catch(Exception e)
            {
                return;
            }
        }
        /* Load data sinh viên lên panel */
        void getDataSVToForm()
        {
            lbTenSV.Text = SinhVien.Ten_sv.ToUpper();
            lbTenSV1.Text = SinhVien.Ten_sv.ToUpper();
            lbMaSV.Text = SinhVien.Ma_sv;
            lbTrangThai.Text = SinhVien.Trang_thai_hoc;
            lbNgayVaoTruong.Text = SinhVien.Ngay_vao_truong_sv;
            lbKhoaHoc.Text = SinhVien.Khoa_hoc_sv;
            lbBacDaoTao.Text = SinhVien.getTenBacDaoTao();
            lbNganh.Text = SinhVien.getTenKhoa();
            lbKhoa.Text = SinhVien.getTenKhoa();
            lbChucVu.Text = SinhVien.Chuc_vu_sv;
            lbGioiTinh.Text = SinhVien.Gioitinh_sv;
            lbChuyenNganh.Text = SinhVien.getTenChuyenNganh();
            lbLoaiHinhDaoTao.Text = SinhVien.getLoaiHinhDaoTao();
            lbLop.Text = SinhVien.getTenLop();
            lbCongTacDoan.Text = SinhVien.Cong_tac_doan;
            lbCoSo.Text = SinhVien.Co_so;

            /*---------------------------------------------------*/

            lbNgaySinh.Text = SinhVien.Ngay_sinh_sv;
            lbNoiSinh.Text = SinhVien.Noi_sinh_sv;
            lbDanToc.Text = SinhVien.Dan_toc_sv;
            lbHoKhau.Text = SinhVien.Ho_khau_sv;
            lbDiaChiLienHe.Text = SinhVien.Dia_chi_sv;
            lbCMND.Text = SinhVien.Cmnd_sv;
            lbNgayCapCMND.Text = SinhVien.Ngay_cap_cmnd_sv;
            lbNoiCapCMND.Text = SinhVien.Noi_cap_cmnd_sv;
            lbTonGiao.Text = SinhVien.Ton_giao_sv;
            lbKhuVuc.Text = SinhVien.Khu_vuc_sv;
            lbDoiTuong.Text = SinhVien.Doi_tuong_sv;
            lbDienChinhSach.Text = SinhVien.Dien_chinh_sach;
            lbNgayVaoDoan.Text = SinhVien.Ngay_vao_doan_sv;
            lbNgayVaoDang.Text = SinhVien.Ngay_vao_dang_sv;
            lbSDT.Text = SinhVien.Sdt_sv;
            lbEmail.Text = SinhVien.Email_sv;

            /*---------------------------------------------------*/
            lb_tencha.Text = SinhVien.Ten_cha;
            lb_ngaysinhcha.Text = SinhVien.Ngay_sinh_cha;
            lb_nghenghiepcha.Text = SinhVien.Nghe_nghiep_cha;
            lb_sdtcha.Text = SinhVien.Sdt_cha;
            lb_quoctichcha.Text = SinhVien.Quoc_tich_cha;
            lb_tenme.Text = SinhVien.Ten_me;
            lb_ngaysinhme.Text = SinhVien.Ngay_sinh_me;
            lb_nghenghiepme.Text = SinhVien.Nghe_nghiep_me;
            lb_sdtme.Text = SinhVien.Sdt_me;
            lb_quoctichme.Text = SinhVien.Quoc_tich_me;
        }

        /* ------------- Các hàm mở form mới ------------- */

        /* Mở form đang phát triển */
        void Open_DangPhatTrien()
        {
            FormDangPhatTrien dpt = new FormDangPhatTrien();
            dpt.ShowDialog();
            dpt.Close();
        }

        /* Mở form sửa thông tin sinh viên*/
        private void btSuaThongTinSV_Click(object sender, EventArgs e)
        {
            SuaThongTinSV editSV = new SuaThongTinSV(NameUser);
            editSV.ShowDialog();
            editSV.Close();
            getDataSVToForm();
        }
        /* Load panel thông tin gia đình*/
        private void btThongTinGiaDinh_Click(object sender, EventArgs e)
        {
            panelGiaDinh.Visible = true;
            panelThongTinSinhVien.Visible = false;
        }
        /* Load panel thông tin sinh viên*/
        private void btThongTinSV_Click(object sender, EventArgs e)
        {
            panelThongTinSinhVien.Visible = true;
            panelGiaDinh.Visible = false;
        }
        /* Mở form sửa thông tin gia đình*/
        private void bt_suathongtingiadinh_Click(object sender, EventArgs e)
        {
            SuaThongTinGD editGD = new SuaThongTinGD(NameUser);
            editGD.ShowDialog();
            editGD.Close();
        }
    }
}
