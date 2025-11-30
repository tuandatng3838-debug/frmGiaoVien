using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;


namespace frmGiaoVien
{
    public partial class frmKetQuaHoiGiang : Form
    {
        // Sửa YOUR_SERVER_NAME cho đúng
        private readonly string connectionString =
    ConfigurationManager.ConnectionStrings["QLHoiGiang"].ConnectionString;

        private string trangThai = ""; // "", "them", "sua"

        public frmKetQuaHoiGiang()
        {
            InitializeComponent();

            // Gắn event
            this.Load += frmKetQuaHoiGiang_Load;

            cboHoiGiang.SelectedIndexChanged += cboHoiGiang_SelectedIndexChanged;
            dgvKetQua.CellClick += dgvKetQua_CellClick;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;

            btnTim.Click += btnTim_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
        }

        // ===== LOAD FORM =====
        private void frmKetQuaHoiGiang_Load(object sender, EventArgs e)
        {
            LoadDanhSachHoiGiang();
            LoadDanhMucGiaiThuong();
            LoadKetQua();
        }

        // ===== LOAD DANH SÁCH HỘI GIẢNG VÀO COMBO =====
        private void LoadDanhSachHoiGiang()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT hg.MaHG,
                           (hg.MaHG + ' - ' + gv.HoTen + ' - ' + ISNULL(hg.TenBai, '')) AS HienThi,
                           gv.HoTen,
                           gv.DonViCongTac,
                           gv.CapBac,
                           hg.TenBai,
                           hg.CapThucHien
                    FROM HoiGiang hg
                    INNER JOIN GiaoVien gv ON hg.MaSoCB = gv.MaSoCB
                    ORDER BY hg.ThoiGian DESC";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboHoiGiang.DataSource = dt;
                    cboHoiGiang.DisplayMember = "HienThi";
                    cboHoiGiang.ValueMember = "MaHG";

                    if (dt.Rows.Count > 0)
                        cboHoiGiang.SelectedIndex = 0;
                    else
                        cboHoiGiang.SelectedIndex = -1;
                }
            }
        }

        // ===== LOAD DANH MỤC GIẢI THƯỞNG =====
        private void LoadDanhMucGiaiThuong()
        {
            cboGiaiThuong.Items.Clear();
            cboGiaiThuong.Items.Add(""); // cho phép để trống
            cboGiaiThuong.Items.Add("Nhất");
            cboGiaiThuong.Items.Add("Nhì");
            cboGiaiThuong.Items.Add("Ba");
            cboGiaiThuong.Items.Add("Khuyến khích");
            cboGiaiThuong.SelectedIndex = 0;
        }

        // ===== KHI CHỌN HỘI GIẢNG TRONG COMBO =====
        private void cboHoiGiang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHoiGiang.SelectedItem is DataRowView drv)
            {
                txtHoTenGV.Text = drv["HoTen"]?.ToString();
                txtCapBac.Text = drv["CapBac"]?.ToString();
                txtDonVi.Text = drv["DonViCongTac"]?.ToString();
                txtTenBai.Text = drv["TenBai"]?.ToString();
                txtCapThucHien.Text = drv["CapThucHien"]?.ToString();
            }
            else
            {
                txtHoTenGV.Text = "";
                txtCapBac.Text = "";
                txtDonVi.Text = "";
                txtTenBai.Text = "";
                txtCapThucHien.Text = "";
            }
        }

        // ===== LOAD DỮ LIỆU KẾT QUẢ LÊN GRID =====
        private void LoadKetQua(string tuKhoa = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT kq.MaHG,
                           gv.MaSoCB,
                           gv.HoTen       AS HoTenGV,
                           gv.DonViCongTac AS DonViGV,
                           gv.CapBac      AS CapBacGV,
                           hg.TenBai,
                           hg.CapThucHien,
                           kq.DiemHieuBiet,
                           kq.DiemGioiThieu,
                           kq.DiemThucHanh1,
                           kq.DiemThucHanh2,
                           kq.DiemThucHanh3,
                           kq.DiemThucHanh4,
                           kq.DiemThucHanh5,
                           kq.DiemThucHanhTB,
                           kq.TongDiem,
                           kq.GiaiThuong
                    FROM KetQuaHoiGiang kq
                    INNER JOIN HoiGiang hg ON kq.MaHG = hg.MaHG
                    INNER JOIN GiaoVien gv ON hg.MaSoCB = gv.MaSoCB
                    WHERE (@TuKhoa = '' OR
                           gv.HoTen       LIKE '%' + @TuKhoa + '%' OR
                           hg.TenBai      LIKE '%' + @TuKhoa + '%' OR
                           hg.CapThucHien LIKE '%' + @TuKhoa + '%' OR
                           kq.GiaiThuong  LIKE '%' + @TuKhoa + '%')
                    ORDER BY kq.TongDiem DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa ?? string.Empty);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvKetQua.DataSource = dt;
                    }
                }
            }

            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvKetQua.Columns.Contains("MaSoCB"))
                dgvKetQua.Columns["MaSoCB"].Visible = false;

            if (dgvKetQua.Columns.Contains("MaHG"))
                dgvKetQua.Columns["MaHG"].HeaderText = "Mã HG";
            if (dgvKetQua.Columns.Contains("HoTenGV"))
                dgvKetQua.Columns["HoTenGV"].HeaderText = "Họ tên GV";
            if (dgvKetQua.Columns.Contains("DonViGV"))
                dgvKetQua.Columns["DonViGV"].HeaderText = "Đơn vị";
            if (dgvKetQua.Columns.Contains("CapBacGV"))
                dgvKetQua.Columns["CapBacGV"].HeaderText = "Cấp bậc";
            if (dgvKetQua.Columns.Contains("TenBai"))
                dgvKetQua.Columns["TenBai"].HeaderText = "Tên bài";
            if (dgvKetQua.Columns.Contains("CapThucHien"))
                dgvKetQua.Columns["CapThucHien"].HeaderText = "Cấp thực hiện";
            if (dgvKetQua.Columns.Contains("DiemHieuBiet"))
                dgvKetQua.Columns["DiemHieuBiet"].HeaderText = "Hiểu biết";
            if (dgvKetQua.Columns.Contains("DiemGioiThieu"))
                dgvKetQua.Columns["DiemGioiThieu"].HeaderText = "Giới thiệu";
            if (dgvKetQua.Columns.Contains("DiemThucHanh1"))
                dgvKetQua.Columns["DiemThucHanh1"].HeaderText = "P1";
            if (dgvKetQua.Columns.Contains("DiemThucHanh2"))
                dgvKetQua.Columns["DiemThucHanh2"].HeaderText = "P2";
            if (dgvKetQua.Columns.Contains("DiemThucHanh3"))
                dgvKetQua.Columns["DiemThucHanh3"].HeaderText = "P3";
            if (dgvKetQua.Columns.Contains("DiemThucHanh4"))
                dgvKetQua.Columns["DiemThucHanh4"].HeaderText = "P4";
            if (dgvKetQua.Columns.Contains("DiemThucHanh5"))
                dgvKetQua.Columns["DiemThucHanh5"].HeaderText = "P5";
            if (dgvKetQua.Columns.Contains("DiemThucHanhTB"))
                dgvKetQua.Columns["DiemThucHanhTB"].HeaderText = "TH TB";
            if (dgvKetQua.Columns.Contains("TongDiem"))
                dgvKetQua.Columns["TongDiem"].HeaderText = "Tổng điểm";
            if (dgvKetQua.Columns.Contains("GiaiThuong"))
                dgvKetQua.Columns["GiaiThuong"].HeaderText = "Giải thưởng";
        }

        // ===== XÓA Ô NHẬP =====
        private void ClearInput()
        {
            if (cboHoiGiang.Items.Count > 0)
                cboHoiGiang.SelectedIndex = 0;
            txtDiemHieuBiet.Text = "";
            txtDiemGioiThieu.Text = "";
            txtDiemThucHanh1.Text = "";
            txtDiemThucHanh2.Text = "";
            txtDiemThucHanh3.Text = "";
            txtDiemThucHanh4.Text = "";
            txtDiemThucHanh5.Text = "";
            txtDiemThucHanhTB.Text = "";
            txtTongDiem.Text = "";
            cboGiaiThuong.SelectedIndex = 0;
        }

        // ===== ĐỔ DỮ LIỆU TỪ GRID LÊN FORM =====
        private void FillInputFromRow(DataGridViewRow row)
        {
            string maHG = row.Cells["MaHG"].Value?.ToString();

            if (!string.IsNullOrWhiteSpace(maHG))
                cboHoiGiang.SelectedValue = maHG;

            txtHoTenGV.Text = row.Cells["HoTenGV"].Value?.ToString();
            txtDonVi.Text = row.Cells["DonViGV"].Value?.ToString();
            txtCapBac.Text = row.Cells["CapBacGV"].Value?.ToString();
            txtTenBai.Text = row.Cells["TenBai"].Value?.ToString();
            txtCapThucHien.Text = row.Cells["CapThucHien"].Value?.ToString();

            txtDiemHieuBiet.Text = row.Cells["DiemHieuBiet"].Value?.ToString();
            txtDiemGioiThieu.Text = row.Cells["DiemGioiThieu"].Value?.ToString();
            txtDiemThucHanh1.Text = row.Cells["DiemThucHanh1"].Value?.ToString();
            txtDiemThucHanh2.Text = row.Cells["DiemThucHanh2"].Value?.ToString();
            txtDiemThucHanh3.Text = row.Cells["DiemThucHanh3"].Value?.ToString();
            txtDiemThucHanh4.Text = row.Cells["DiemThucHanh4"].Value?.ToString();
            txtDiemThucHanh5.Text = row.Cells["DiemThucHanh5"].Value?.ToString();
            txtDiemThucHanhTB.Text = row.Cells["DiemThucHanhTB"].Value?.ToString();
            txtTongDiem.Text = row.Cells["TongDiem"].Value?.ToString();
            cboGiaiThuong.Text = row.Cells["GiaiThuong"].Value?.ToString();
        }

        // ===== CLICK DÒNG TRONG GRID =====
        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvKetQua.Rows.Count <= e.RowIndex) return;

            DataGridViewRow row = dgvKetQua.Rows[e.RowIndex];
            FillInputFromRow(row);
        }

        // ===== KIỂM TRA DỮ LIỆU =====
        private bool ValidateInput(out decimal diemHB, out decimal diemGT,
                                   out decimal d1, out decimal d2, out decimal d3,
                                   out decimal d4, out decimal d5)
        {
            diemHB = diemGT = d1 = d2 = d3 = d4 = d5 = 0m;

            if (cboHoiGiang.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn một hội giảng.");
                cboHoiGiang.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDiemHieuBiet.Text.Trim(), out diemHB))
            {
                MessageBox.Show("Điểm phần hiểu biết không hợp lệ.");
                txtDiemHieuBiet.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDiemGioiThieu.Text.Trim(), out diemGT))
            {
                MessageBox.Show("Điểm phần giới thiệu không hợp lệ.");
                txtDiemGioiThieu.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDiemThucHanh1.Text.Trim(), out d1))
            {
                MessageBox.Show("Điểm P1 không hợp lệ.");
                txtDiemThucHanh1.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDiemThucHanh2.Text.Trim(), out d2))
            {
                MessageBox.Show("Điểm P2 không hợp lệ.");
                txtDiemThucHanh2.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDiemThucHanh3.Text.Trim(), out d3))
            {
                MessageBox.Show("Điểm P3 không hợp lệ.");
                txtDiemThucHanh3.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDiemThucHanh4.Text.Trim(), out d4))
            {
                MessageBox.Show("Điểm P4 không hợp lệ.");
                txtDiemThucHanh4.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDiemThucHanh5.Text.Trim(), out d5))
            {
                MessageBox.Show("Điểm P5 không hợp lệ.");
                txtDiemThucHanh5.Focus();
                return false;
            }

            return true;
        }

        // ===== TÍNH TB THỰC HÀNH + TỔNG ĐIỂM =====
        private void TinhLaiDiem(decimal diemHB, decimal diemGT,
                                 decimal d1, decimal d2, decimal d3,
                                 decimal d4, decimal d5,
                                 out decimal diemTH_TB, out decimal tong)
        {
            diemTH_TB = (d1 + d2 + d3 + d4 + d5) / 5m;
            tong = diemHB + diemGT + diemTH_TB;

            txtDiemThucHanhTB.Text = diemTH_TB.ToString("0.00");
            txtTongDiem.Text = tong.ToString("0.00");
        }

        // ===== NÚT THÊM =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            trangThai = "them";
            ClearInput();
        }

        // ===== NÚT SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKetQua.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn bản ghi kết quả để sửa.");
                return;
            }

            trangThai = "sua";
        }

        // ===== NÚT XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cboHoiGiang.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn hội giảng có kết quả để xóa.");
                return;
            }

            string maHG = cboHoiGiang.SelectedValue.ToString();

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa kết quả hội giảng này?",
                "Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM KetQuaHoiGiang WHERE MaHG = @MaHG", conn))
                {
                    cmd.Parameters.AddWithValue("@MaHG", maHG);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa kết quả hội giảng.");
                        LoadKetQua(txtTimKiem.Text.Trim());
                        ClearInput();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                    }
                }
            }
        }

        // ===== NÚT LƯU (THÊM / SỬA) =====
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal diemHB, out decimal diemGT,
                               out decimal d1, out decimal d2, out decimal d3,
                               out decimal d4, out decimal d5))
                return;

            TinhLaiDiem(diemHB, diemGT, d1, d2, d3, d4, d5,
                        out decimal diemTH_TB, out decimal tong);

            if (cboHoiGiang.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn hội giảng.");
                return;
            }

            string maHG = cboHoiGiang.SelectedValue.ToString();
            string giaiThuong = cboGiaiThuong.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                if (trangThai == "them")
                {
                    cmd.CommandText = @"
                        INSERT INTO KetQuaHoiGiang
                        (MaHG, DiemHieuBiet, DiemGioiThieu,
                         DiemThucHanh1, DiemThucHanh2, DiemThucHanh3,
                         DiemThucHanh4, DiemThucHanh5,
                         DiemThucHanhTB, TongDiem, GiaiThuong)
                        VALUES
                        (@MaHG, @DiemHB, @DiemGT,
                         @D1, @D2, @D3, @D4, @D5,
                         @DTH_TB, @TongDiem, @GiaiThuong)";
                }
                else if (trangThai == "sua")
                {
                    cmd.CommandText = @"
                        UPDATE KetQuaHoiGiang
                        SET DiemHieuBiet = @DiemHB,
                            DiemGioiThieu = @DiemGT,
                            DiemThucHanh1 = @D1,
                            DiemThucHanh2 = @D2,
                            DiemThucHanh3 = @D3,
                            DiemThucHanh4 = @D4,
                            DiemThucHanh5 = @D5,
                            DiemThucHanhTB = @DTH_TB,
                            TongDiem = @TongDiem,
                            GiaiThuong = @GiaiThuong
                        WHERE MaHG = @MaHG";
                }
                else
                {
                    MessageBox.Show("Hãy bấm Thêm hoặc Sửa trước khi Lưu.");
                    return;
                }

                cmd.Parameters.AddWithValue("@MaHG", maHG);
                cmd.Parameters.AddWithValue("@DiemHB", diemHB);
                cmd.Parameters.AddWithValue("@DiemGT", diemGT);
                cmd.Parameters.AddWithValue("@D1", d1);
                cmd.Parameters.AddWithValue("@D2", d2);
                cmd.Parameters.AddWithValue("@D3", d3);
                cmd.Parameters.AddWithValue("@D4", d4);
                cmd.Parameters.AddWithValue("@D5", d5);
                cmd.Parameters.AddWithValue("@DTH_TB", diemTH_TB);
                cmd.Parameters.AddWithValue("@TongDiem", tong);
                cmd.Parameters.AddWithValue("@GiaiThuong",
                    string.IsNullOrWhiteSpace(giaiThuong) ? (object)DBNull.Value : giaiThuong);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu kết quả hội giảng.");
                    LoadKetQua(txtTimKiem.Text.Trim());
                    trangThai = "";
                }
                catch (SqlException ex)
                {
                    // Nếu trùng khóa chính (hội giảng đã có kết quả)
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        MessageBox.Show("Hội giảng này đã có kết quả. Hãy dùng chức năng Sửa.");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                    }
                }
            }
        }

        // ===== NÚT HỦY =====
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInput();
            trangThai = "";
        }

        // ===== TÌM KIẾM =====
        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadKetQua(txtTimKiem.Text.Trim());
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadKetQua(txtTimKiem.Text.Trim());
            }
        }

        private void frmKetQuaHoiGiang_Load_1(object sender, EventArgs e)
        {

        }
    }
}
