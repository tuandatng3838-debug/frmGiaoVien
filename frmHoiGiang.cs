using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using Krypton.Toolkit;

namespace frmGiaoVien
{
    public partial class frmHoiGiang : KryptonForm
    {
        // Sửa YOUR_SERVER_NAME cho đúng

        private readonly string connectionString =
    ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
            ?? ConfigurationManager.ConnectionStrings["QLHoiGiang"]?.ConnectionString
            ?? "Data Source=TUANDAT\\SQLEXPRESS;Initial Catalog=QLHoiGiang;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";


    private string trangThai = ""; // "", "them", "sua"

        public frmHoiGiang()
        {
            InitializeComponent();

            // Gắn event
            this.Load += frmHoiGiang_Load;
            cboGiaoVien.SelectedIndexChanged += cboGiaoVien_SelectedIndexChanged;
            dgvHoiGiang.CellClick += dgvHoiGiang_CellClick;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;

            btnTim.Click += btnTim_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
        }

        // ===== LOAD FORM =====
        private void frmHoiGiang_Load(object sender, EventArgs e)
        {
            LoadDanhSachGiaoVien();
            LoadDanhMucCoDinh();
            LoadHoiGiang();
        }

        // ===== LOAD DANH SÁCH GIÁO VIÊN VÀO COMBO =====
        private void LoadDanhSachGiaoVien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT MaSoCB, HoTen, CapBac, DonViCongTac
                               FROM GiaoVien
                               ORDER BY HoTen";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboGiaoVien.DataSource = dt;
                    cboGiaoVien.DisplayMember = "HoTen";
                    cboGiaoVien.ValueMember = "MaSoCB";
                    cboGiaoVien.SelectedIndex = dt.Rows.Count > 0 ? 0 : -1;
                }
            }
        }

        // ===== LOAD DANH MỤC CỐ ĐỊNH =====
        private void LoadDanhMucCoDinh()
        {
            // Chức danh giảng dạy
            cboChucDanhGD.Items.Clear();
            cboChucDanhGD.Items.Add("Chưa có chức danh");
            cboChucDanhGD.Items.Add("Trợ giảng");
            cboChucDanhGD.Items.Add("Giảng viên");
            cboChucDanhGD.Items.Add("Giảng viên chính");
            if (cboChucDanhGD.Items.Count > 0)
                cboChucDanhGD.SelectedIndex = 0;

            // Cấp thực hiện
            cboCapThucHien.Items.Clear();
            cboCapThucHien.Items.Add("Cấp Học viện");
            cboCapThucHien.Items.Add("Cấp Bộ");
            if (cboCapThucHien.Items.Count > 0)
                cboCapThucHien.SelectedIndex = 0;
        }

        // ===== KHI CHỌN GIÁO VIÊN TRONG COMBO =====
        private void cboGiaoVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGiaoVien.SelectedItem is DataRowView drv)
            {
                txtCapBac.Text = drv["CapBac"]?.ToString();
                txtDonVi.Text = drv["DonViCongTac"]?.ToString();
            }
            else
            {
                txtCapBac.Text = "";
                txtDonVi.Text = "";
            }
        }

        // ===== LOAD DỮ LIỆU HỘI GIẢNG LÊN LƯỚI =====
        private void LoadHoiGiang(string tuKhoa = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT hg.MaHG,
                           hg.MaSoCB,
                           gv.HoTen       AS HoTenGV,
                           gv.CapBac      AS CapBacGV,
                           gv.DonViCongTac AS DonViGV,
                           hg.ChucDanhGiangDay,
                           hg.TenBai,
                           hg.HocPhan,
                           hg.Lop,
                           hg.ThoiGian,
                           hg.CapThucHien
                    FROM HoiGiang hg
                    INNER JOIN GiaoVien gv ON hg.MaSoCB = gv.MaSoCB
                    WHERE (@TuKhoa = '' OR
                           gv.HoTen       LIKE '%' + @TuKhoa + '%' OR
                           hg.TenBai      LIKE '%' + @TuKhoa + '%' OR
                           hg.HocPhan     LIKE '%' + @TuKhoa + '%' OR
                           hg.Lop         LIKE '%' + @TuKhoa + '%' OR
                           hg.CapThucHien LIKE '%' + @TuKhoa + '%')
                    ORDER BY hg.ThoiGian DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa ?? string.Empty);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvHoiGiang.DataSource = dt;
                    }
                }
            }

            dgvHoiGiang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvHoiGiang.Columns.Contains("MaSoCB"))
                dgvHoiGiang.Columns["MaSoCB"].Visible = false;

            if (dgvHoiGiang.Columns.Contains("MaHG"))
                dgvHoiGiang.Columns["MaHG"].HeaderText = "Mã HG";
            if (dgvHoiGiang.Columns.Contains("HoTenGV"))
                dgvHoiGiang.Columns["HoTenGV"].HeaderText = "Họ tên GV";
            if (dgvHoiGiang.Columns.Contains("CapBacGV"))
                dgvHoiGiang.Columns["CapBacGV"].HeaderText = "Cấp bậc";
            if (dgvHoiGiang.Columns.Contains("DonViGV"))
                dgvHoiGiang.Columns["DonViGV"].HeaderText = "Đơn vị";
            if (dgvHoiGiang.Columns.Contains("ChucDanhGiangDay"))
                dgvHoiGiang.Columns["ChucDanhGiangDay"].HeaderText = "Chức danh GD";
            if (dgvHoiGiang.Columns.Contains("TenBai"))
                dgvHoiGiang.Columns["TenBai"].HeaderText = "Tên bài";
            if (dgvHoiGiang.Columns.Contains("HocPhan"))
                dgvHoiGiang.Columns["HocPhan"].HeaderText = "Học phần";
            if (dgvHoiGiang.Columns.Contains("Lop"))
                dgvHoiGiang.Columns["Lop"].HeaderText = "Lớp";
            if (dgvHoiGiang.Columns.Contains("ThoiGian"))
                dgvHoiGiang.Columns["ThoiGian"].HeaderText = "Thời gian";
            if (dgvHoiGiang.Columns.Contains("CapThucHien"))
                dgvHoiGiang.Columns["CapThucHien"].HeaderText = "Cấp thực hiện";
        }

        // ===== XÓA Ô NHẬP =====
        private void ClearInput()
        {
            txtMaHG.Text = "";
            if (cboGiaoVien.Items.Count > 0)
                cboGiaoVien.SelectedIndex = 0;
            txtCapBac.Text = "";
            txtDonVi.Text = "";
            cboChucDanhGD.SelectedIndex = cboChucDanhGD.Items.Count > 0 ? 0 : -1;
            txtTenBai.Text = "";
            txtHocPhan.Text = "";
            txtLop.Text = "";
            dtpThoiGian.Value = DateTime.Today;
            cboCapThucHien.SelectedIndex = cboCapThucHien.Items.Count > 0 ? 0 : -1;
        }

        // ===== ĐỔ DỮ LIỆU TỪ GRID LÊN FORM =====
        private void FillInputFromRow(DataGridViewRow row)
        {
            txtMaHG.Text = row.Cells["MaHG"].Value?.ToString();

            string maSoCB = row.Cells["MaSoCB"].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(maSoCB))
                cboGiaoVien.SelectedValue = maSoCB;

            txtCapBac.Text = row.Cells["CapBacGV"].Value?.ToString();
            txtDonVi.Text = row.Cells["DonViGV"].Value?.ToString();
            cboChucDanhGD.Text = row.Cells["ChucDanhGiangDay"].Value?.ToString();
            txtTenBai.Text = row.Cells["TenBai"].Value?.ToString();
            txtHocPhan.Text = row.Cells["HocPhan"].Value?.ToString();
            txtLop.Text = row.Cells["Lop"].Value?.ToString();

            if (row.Cells["ThoiGian"].Value != DBNull.Value && row.Cells["ThoiGian"].Value != null)
            {
                if (DateTime.TryParse(row.Cells["ThoiGian"].Value.ToString(), out DateTime tg))
                    dtpThoiGian.Value = tg;
            }

            cboCapThucHien.Text = row.Cells["CapThucHien"].Value?.ToString();
        }

        // ===== CLICK DÒNG TRONG LƯỚI =====
        private void dgvHoiGiang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHoiGiang.Rows.Count <= e.RowIndex) return;

            DataGridViewRow row = dgvHoiGiang.Rows[e.RowIndex];
            FillInputFromRow(row);
        }

        // ===== KIỂM TRA DỮ LIỆU =====
        private bool ValidateInput()
        {
            // Ở đây mình dùng MaHG làm khóa chính, bạn tự nhập (HG01, HG02...)
            if (string.IsNullOrWhiteSpace(txtMaHG.Text))
            {
                MessageBox.Show("Mã hội giảng không được để trống.");
                txtMaHG.Focus();
                return false;
            }

            if (cboGiaoVien.SelectedValue == null)
            {
                MessageBox.Show("Hãy chọn giáo viên.");
                cboGiaoVien.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenBai.Text))
            {
                MessageBox.Show("Tên bài không được để trống.");
                txtTenBai.Focus();
                return false;
            }

            return true;
        }

        // ===== NÚT THÊM =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            trangThai = "them";
            ClearInput();
            txtMaHG.Visible = true;
            lblMaHG.Visible = true;
            txtMaHG.Focus();
        }

        // ===== NÚT SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHG.Text))
            {
                MessageBox.Show("Hãy chọn một bản ghi hội giảng để sửa.");
                return;
            }

            trangThai = "sua";
            txtMaHG.Visible = true;
            lblMaHG.Visible = true;
        }

        // ===== NÚT XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHG.Text))
            {
                MessageBox.Show("Hãy chọn một bản ghi hội giảng để xóa.");
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa hội giảng này?",
                "Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM HoiGiang WHERE MaHG = @MaHG", conn))
                {
                    cmd.Parameters.AddWithValue("@MaHG", txtMaHG.Text.Trim());
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa hội giảng.");
                        LoadHoiGiang(txtTimKiem.Text.Trim());
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
            if (!ValidateInput()) return;

            string maHG = txtMaHG.Text.Trim();
            string maSoCB = cboGiaoVien.SelectedValue?.ToString();
            string chucDanh = cboChucDanhGD.Text.Trim();
            string tenBai = txtTenBai.Text.Trim();
            string hocPhan = txtHocPhan.Text.Trim();
            string lop = txtLop.Text.Trim();
            DateTime thoiGian = dtpThoiGian.Value.Date;
            string capThucHien = cboCapThucHien.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                if (trangThai == "them")
                {
                    cmd.CommandText = @"
                        INSERT INTO HoiGiang
                        (MaHG, MaSoCB, ChucDanhGiangDay, TenBai, HocPhan, Lop, ThoiGian, CapThucHien)
                        VALUES
                        (@MaHG, @MaSoCB, @ChucDanh, @TenBai, @HocPhan, @Lop, @ThoiGian, @CapThucHien)";
                }
                else if (trangThai == "sua")
                {
                    cmd.CommandText = @"
                        UPDATE HoiGiang
                        SET MaSoCB = @MaSoCB,
                            ChucDanhGiangDay = @ChucDanh,
                            TenBai = @TenBai,
                            HocPhan = @HocPhan,
                            Lop = @Lop,
                            ThoiGian = @ThoiGian,
                            CapThucHien = @CapThucHien
                        WHERE MaHG = @MaHG";
                }
                else
                {
                    MessageBox.Show("Hãy bấm Thêm hoặc Sửa trước khi Lưu.");
                    return;
                }

                cmd.Parameters.AddWithValue("@MaHG", maHG);
                cmd.Parameters.AddWithValue("@MaSoCB", maSoCB);
                cmd.Parameters.AddWithValue("@ChucDanh", (object)chucDanh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TenBai", (object)tenBai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HocPhan", (object)hocPhan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Lop", (object)lop ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ThoiGian", thoiGian);
                cmd.Parameters.AddWithValue("@CapThucHien", (object)capThucHien ?? DBNull.Value);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu thông tin hội giảng.");
                    LoadHoiGiang(txtTimKiem.Text.Trim());
                    trangThai = "";
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message);
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
            LoadHoiGiang(txtTimKiem.Text.Trim());
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadHoiGiang(txtTimKiem.Text.Trim());
            }
        }

        private void frmHoiGiang_Load_1(object sender, EventArgs e)
        {

        }
    }
}
