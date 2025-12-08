using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using Krypton.Toolkit;


namespace frmGiaoVien
{
    public partial class frmGiaoVien : KryptonForm
    {
        // TODO: sửa lại tên server cho đúng với máy bạn
        private readonly string connectionString =
    ConfigurationManager.ConnectionStrings["QLHoiGiang"].ConnectionString;


        private string trangThai = ""; // "", "them", "sua"

        public frmGiaoVien()
        {
            InitializeComponent();

            // Gắn event
            this.Load += frmGiaoVien_Load;
            dgvGiaoVien.CellClick += dgvGiaoVien_CellClick;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;

            btnTim.Click += btnTim_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
        }

        // ===== LOAD FORM =====
        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            // Giới tính
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("Khác");
            if (cboGioiTinh.Items.Count > 0)
                cboGioiTinh.SelectedIndex = 0;

            LoadGiaoVien();
        }

        // ===== LOAD DỮ LIỆU GIÁO VIÊN =====
        private void LoadGiaoVien(string tuKhoa = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                    SELECT MaSoCB, HoTen, GioiTinh, NgaySinh, QueQuan,
                           DanToc, TonGiao, SDT,
                           TrinhDoChuyenMon, TrinhDoLLCT,
                           DonViCongTac, ChucVu, CapBac,
                           HeSoLuong, ChucDanh, HocHam, HocVi,
                           LinhVucChuyenMon, NamDayGioiGanNhat
                    FROM GiaoVien
                    WHERE (@TuKhoa = '' OR
                           MaSoCB LIKE '%' + @TuKhoa + '%' OR
                           HoTen LIKE '%' + @TuKhoa + '%' OR
                           DonViCongTac LIKE '%' + @TuKhoa + '%')
                    ORDER BY HoTen";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa ?? string.Empty);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvGiaoVien.DataSource = dt;
                    }
                }
            }

            dgvGiaoVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvGiaoVien.Columns.Contains("MaSoCB"))
                dgvGiaoVien.Columns["MaSoCB"].HeaderText = "Mã số CB";
            if (dgvGiaoVien.Columns.Contains("HoTen"))
                dgvGiaoVien.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvGiaoVien.Columns.Contains("GioiTinh"))
                dgvGiaoVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            if (dgvGiaoVien.Columns.Contains("NgaySinh"))
                dgvGiaoVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            if (dgvGiaoVien.Columns.Contains("QueQuan"))
                dgvGiaoVien.Columns["QueQuan"].HeaderText = "Quê quán";
            if (dgvGiaoVien.Columns.Contains("DanToc"))
                dgvGiaoVien.Columns["DanToc"].HeaderText = "Dân tộc";
            if (dgvGiaoVien.Columns.Contains("TonGiao"))
                dgvGiaoVien.Columns["TonGiao"].HeaderText = "Tôn giáo";
            if (dgvGiaoVien.Columns.Contains("SDT"))
                dgvGiaoVien.Columns["SDT"].HeaderText = "SĐT";
            if (dgvGiaoVien.Columns.Contains("TrinhDoChuyenMon"))
                dgvGiaoVien.Columns["TrinhDoChuyenMon"].HeaderText = "Trình độ CM";
            if (dgvGiaoVien.Columns.Contains("TrinhDoLLCT"))
                dgvGiaoVien.Columns["TrinhDoLLCT"].HeaderText = "Trình độ LLCT";
            if (dgvGiaoVien.Columns.Contains("DonViCongTac"))
                dgvGiaoVien.Columns["DonViCongTac"].HeaderText = "Đơn vị công tác";
            if (dgvGiaoVien.Columns.Contains("ChucVu"))
                dgvGiaoVien.Columns["ChucVu"].HeaderText = "Chức vụ";
            if (dgvGiaoVien.Columns.Contains("CapBac"))
                dgvGiaoVien.Columns["CapBac"].HeaderText = "Cấp bậc";
            if (dgvGiaoVien.Columns.Contains("HeSoLuong"))
                dgvGiaoVien.Columns["HeSoLuong"].HeaderText = "Hệ số lương";
            if (dgvGiaoVien.Columns.Contains("ChucDanh"))
                dgvGiaoVien.Columns["ChucDanh"].HeaderText = "Chức danh";
            if (dgvGiaoVien.Columns.Contains("HocHam"))
                dgvGiaoVien.Columns["HocHam"].HeaderText = "Học hàm";
            if (dgvGiaoVien.Columns.Contains("HocVi"))
                dgvGiaoVien.Columns["HocVi"].HeaderText = "Học vị";
            if (dgvGiaoVien.Columns.Contains("LinhVucChuyenMon"))
                dgvGiaoVien.Columns["LinhVucChuyenMon"].HeaderText = "Lĩnh vực chuyên môn";
            if (dgvGiaoVien.Columns.Contains("NamDayGioiGanNhat"))
                dgvGiaoVien.Columns["NamDayGioiGanNhat"].HeaderText = "Năm dạy giỏi gần nhất";
        }

        // ===== XÓA Ô NHẬP =====
        private void ClearInput()
        {
            txtMaSoCB.Text = "";
            txtHoTen.Text = "";
            cboGioiTinh.SelectedIndex = cboGioiTinh.Items.Count > 0 ? 0 : -1;
            dtpNgaySinh.Value = DateTime.Today;
            txtQueQuan.Text = "";
            txtDanToc.Text = "";
            txtTonGiao.Text = "";
            txtSDT.Text = "";
            txtTrinhDoChuyenMon.Text = "";
            txtTrinhDoLLCT.Text = "";
            txtDonViCongTac.Text = "";
            txtChucVu.Text = "";
            txtCapBac.Text = "";
            txtHeSoLuong.Text = "";
            txtChucDanh.Text = "";
            txtHocHam.Text = "";
            txtHocVi.Text = "";
            txtLinhVucChuyenMon.Text = "";
            txtNamDayGioiGanNhat.Text = "";
        }

        // ===== ĐỔ DỮ LIỆU TỪ GRID LÊN FORM =====
        private void FillInputFromRow(DataGridViewRow row)
        {
            txtMaSoCB.Text = row.Cells["MaSoCB"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();

            if (row.Cells["NgaySinh"].Value != DBNull.Value && row.Cells["NgaySinh"].Value != null)
            {
                if (DateTime.TryParse(row.Cells["NgaySinh"].Value.ToString(), out DateTime ns))
                    dtpNgaySinh.Value = ns;
            }

            txtQueQuan.Text = row.Cells["QueQuan"].Value?.ToString();
            txtDanToc.Text = row.Cells["DanToc"].Value?.ToString();
            txtTonGiao.Text = row.Cells["TonGiao"].Value?.ToString();
            txtSDT.Text = row.Cells["SDT"].Value?.ToString();
            txtTrinhDoChuyenMon.Text = row.Cells["TrinhDoChuyenMon"].Value?.ToString();
            txtTrinhDoLLCT.Text = row.Cells["TrinhDoLLCT"].Value?.ToString();
            txtDonViCongTac.Text = row.Cells["DonViCongTac"].Value?.ToString();
            txtChucVu.Text = row.Cells["ChucVu"].Value?.ToString();
            txtCapBac.Text = row.Cells["CapBac"].Value?.ToString();
            txtHeSoLuong.Text = row.Cells["HeSoLuong"].Value?.ToString();
            txtChucDanh.Text = row.Cells["ChucDanh"].Value?.ToString();
            txtHocHam.Text = row.Cells["HocHam"].Value?.ToString();
            txtHocVi.Text = row.Cells["HocVi"].Value?.ToString();
            txtLinhVucChuyenMon.Text = row.Cells["LinhVucChuyenMon"].Value?.ToString();
            txtNamDayGioiGanNhat.Text = row.Cells["NamDayGioiGanNhat"].Value?.ToString();
        }

        // ===== CLICK DÒNG TRONG GRID =====
        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvGiaoVien.Rows.Count <= e.RowIndex) return;

            DataGridViewRow row = dgvGiaoVien.Rows[e.RowIndex];
            FillInputFromRow(row);
        }

        // ===== KIỂM TRA DỮ LIỆU =====
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSoCB.Text))
            {
                MessageBox.Show("Mã số CB không được để trống.");
                txtMaSoCB.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống.");
                txtHoTen.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtHeSoLuong.Text))
            {
                if (!decimal.TryParse(txtHeSoLuong.Text.Trim(), out _))
                {
                    MessageBox.Show("Hệ số lương phải là số.");
                    txtHeSoLuong.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtNamDayGioiGanNhat.Text))
            {
                if (!int.TryParse(txtNamDayGioiGanNhat.Text.Trim(), out _))
                {
                    MessageBox.Show("Năm dạy giỏi gần nhất phải là số nguyên.");
                    txtNamDayGioiGanNhat.Focus();
                    return false;
                }
            }

            return true;
        }

        // ===== NÚT THÊM =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            trangThai = "them";
            ClearInput();
            txtMaSoCB.Focus();
        }

        // ===== NÚT SỬA =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSoCB.Text))
            {
                MessageBox.Show("Hãy chọn một cán bộ / giáo viên để sửa.");
                return;
            }

            trangThai = "sua";
        }

        // ===== NÚT XÓA =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSoCB.Text))
            {
                MessageBox.Show("Hãy chọn một cán bộ / giáo viên để xóa.");
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa cán bộ / giáo viên này?",
                "Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM GiaoVien WHERE MaSoCB = @MaSoCB", conn))
                {
                    cmd.Parameters.AddWithValue("@MaSoCB", txtMaSoCB.Text.Trim());
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa cán bộ / giáo viên.");
                        LoadGiaoVien(txtTimKiem.Text.Trim());
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

            string maSoCB = txtMaSoCB.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string gioiTinh = cboGioiTinh.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value.Date;
            string queQuan = txtQueQuan.Text.Trim();
            string danToc = txtDanToc.Text.Trim();
            string tonGiao = txtTonGiao.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string trinhDoCM = txtTrinhDoChuyenMon.Text.Trim();
            string trinhDoLLCT = txtTrinhDoLLCT.Text.Trim();
            string donVi = txtDonViCongTac.Text.Trim();
            string chucVu = txtChucVu.Text.Trim();
            string capBac = txtCapBac.Text.Trim();
            string heSoLuongText = txtHeSoLuong.Text.Trim();
            string chucDanh = txtChucDanh.Text.Trim();
            string hocHam = txtHocHam.Text.Trim();
            string hocVi = txtHocVi.Text.Trim();
            string linhVuc = txtLinhVucChuyenMon.Text.Trim();
            string namDayGioiText = txtNamDayGioiGanNhat.Text.Trim();

            decimal? heSoLuong = null;
            if (decimal.TryParse(heSoLuongText, out var hs))
                heSoLuong = hs;

            int? namDayGioi = null;
            if (int.TryParse(namDayGioiText, out var nam))
                namDayGioi = nam;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();

                if (trangThai == "them")
                {
                    cmd.CommandText = @"
                        INSERT INTO GiaoVien
                        (MaSoCB, HoTen, GioiTinh, NgaySinh, QueQuan,
                         DanToc, TonGiao, SDT,
                         TrinhDoChuyenMon, TrinhDoLLCT,
                         DonViCongTac, ChucVu, CapBac,
                         HeSoLuong, ChucDanh, HocHam, HocVi,
                         LinhVucChuyenMon, NamDayGioiGanNhat)
                        VALUES
                        (@MaSoCB, @HoTen, @GioiTinh, @NgaySinh, @QueQuan,
                         @DanToc, @TonGiao, @SDT,
                         @TrinhDoCM, @TrinhDoLLCT,
                         @DonVi, @ChucVu, @CapBac,
                         @HeSoLuong, @ChucDanh, @HocHam, @HocVi,
                         @LinhVuc, @NamDayGioi)";
                }
                else if (trangThai == "sua")
                {
                    cmd.CommandText = @"
                        UPDATE GiaoVien
                        SET HoTen = @HoTen,
                            GioiTinh = @GioiTinh,
                            NgaySinh = @NgaySinh,
                            QueQuan = @QueQuan,
                            DanToc = @DanToc,
                            TonGiao = @TonGiao,
                            SDT = @SDT,
                            TrinhDoChuyenMon = @TrinhDoCM,
                            TrinhDoLLCT = @TrinhDoLLCT,
                            DonViCongTac = @DonVi,
                            ChucVu = @ChucVu,
                            CapBac = @CapBac,
                            HeSoLuong = @HeSoLuong,
                            ChucDanh = @ChucDanh,
                            HocHam = @HocHam,
                            HocVi = @HocVi,
                            LinhVucChuyenMon = @LinhVuc,
                            NamDayGioiGanNhat = @NamDayGioi
                        WHERE MaSoCB = @MaSoCB";
                }
                else
                {
                    MessageBox.Show("Hãy bấm Thêm hoặc Sửa trước khi Lưu.");
                    return;
                }

                cmd.Parameters.AddWithValue("@MaSoCB", maSoCB);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@QueQuan", (object)queQuan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DanToc", (object)danToc ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TonGiao", (object)tonGiao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SDT", (object)sdt ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrinhDoCM", (object)trinhDoCM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrinhDoLLCT", (object)trinhDoLLCT ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DonVi", (object)donVi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ChucVu", (object)chucVu ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CapBac", (object)capBac ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HeSoLuong", (object?)heSoLuong ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ChucDanh", (object)chucDanh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HocHam", (object)hocHam ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HocVi", (object)hocVi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LinhVuc", (object)linhVuc ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NamDayGioi", (object?)namDayGioi ?? DBNull.Value);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu thông tin cán bộ / giáo viên.");
                    LoadGiaoVien(txtTimKiem.Text.Trim());
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
            LoadGiaoVien(txtTimKiem.Text.Trim());
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadGiaoVien(txtTimKiem.Text.Trim());
            }
        }

        private void frmGiaoVien_Load_1(object sender, EventArgs e)
        {

        }
    }
}
