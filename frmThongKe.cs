using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace frmGiaoVien
{
    public partial class frmThongKe : Form
    {
        // Sửa YOUR_SERVER_NAME cho đúng
        private readonly string connectionString =
    ConfigurationManager.ConnectionStrings["QLHoiGiang"].ConnectionString;

    public frmThongKe()
        {
            InitializeComponent();

            this.Load += frmThongKe_Load;

            btnThongKeKhoa.Click += btnThongKeKhoa_Click;
            btnThongKeHoiDong.Click += btnThongKeHoiDong_Click;
            btnThongKeHoiGiang.Click += btnThongKeHoiGiang_Click;
            btnThongKeTiLe.Click += btnThongKeTiLe_Click;

            btnExportKhoa.Click += (s, e) => ExportGridToCsv(dgvGiaiTheoKhoa);
            btnExportHoiDong.Click += (s, e) => ExportGridToCsv(dgvHoiDong);
            btnExportHoiGiang.Click += (s, e) => ExportGridToCsv(dgvHoiGiangThongKe);
            btnExportTiLe.Click += (s, e) => ExportGridToCsv(dgvTiLeThamGia);
        }

        // ===== LOAD FORM =====
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadNamHocForComboHoiGiang(cboNamHocKhoa);
            LoadNamHocForComboHoiDong(cboNamHocHoiDong);
            LoadNamHocForComboHoiGiang(cboNamHocHoiGiang);
            LoadNamHocForComboHoiGiang(cboNamHocTiLe);

            ThongKeGiaiTheoKhoa();
            ThongKeHoiDong();
            ThongKeHoiGiang();
            ThongKeTiLeThamGia();
        }

        // ===== HÀM LOAD NĂM HỌC TỪ HoiGiang =====
        private void LoadNamHocForComboHoiGiang(ComboBox cbo)
        {
            cbo.Items.Clear();
            cbo.Items.Add(""); // trống = tất cả

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT DISTINCT NamHoc
                               FROM HoiGiang
                               WHERE NamHoc IS NOT NULL AND NamHoc <> ''
                               ORDER BY NamHoc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cbo.Items.Add(rd.GetString(0));
                    }
                }
            }

            cbo.SelectedIndex = 0;
        }

        // ===== HÀM LOAD NĂM HỌC TỪ HoiDong =====
        private void LoadNamHocForComboHoiDong(ComboBox cbo)
        {
            cbo.Items.Clear();
            cbo.Items.Add(""); // trống = tất cả

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT DISTINCT NamHoc
                               FROM HoiDong
                               WHERE NamHoc IS NOT NULL AND NamHoc <> ''
                               ORDER BY NamHoc";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cbo.Items.Add(rd.GetString(0));
                    }
                }
            }

            cbo.SelectedIndex = 0;
        }

        // =====================================================================
        // 1. THỐNG KÊ MỖI KHOA CÓ BAO NHIÊU GIẢI (CƠ CẤU GIẢI)
        // =====================================================================
        private void btnThongKeKhoa_Click(object sender, EventArgs e)
        {
            ThongKeGiaiTheoKhoa();
        }

        private void ThongKeGiaiTheoKhoa()
        {
            string namHoc = cboNamHocKhoa.Text.Trim(); // có thể rỗng = tất cả

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        ISNULL(gv.DonViCongTac, N'Chưa rõ') AS Khoa,
                        ISNULL(kq.GiaiThuong, N'Chưa xếp giải') AS GiaiThuong,
                        COUNT(*) AS SoLuong
                    FROM KetQuaHoiGiang kq
                    INNER JOIN HoiGiang hg ON kq.MaHG = hg.MaHG
                    INNER JOIN GiaoVien gv ON hg.MaSoCB = gv.MaSoCB
                    WHERE (@NamHoc = '' OR ISNULL(hg.NamHoc, '') = @NamHoc)
                    GROUP BY ISNULL(gv.DonViCongTac, N'Chưa rõ'),
                             ISNULL(kq.GiaiThuong, N'Chưa xếp giải')
                    ORDER BY Khoa, GiaiThuong;";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvGiaiTheoKhoa.DataSource = dt;
                    }
                }
            }

            if (dgvGiaiTheoKhoa.Columns.Contains("Khoa"))
                dgvGiaiTheoKhoa.Columns["Khoa"].HeaderText = "Khoa / Đơn vị";
            if (dgvGiaiTheoKhoa.Columns.Contains("GiaiThuong"))
                dgvGiaiTheoKhoa.Columns["GiaiThuong"].HeaderText = "Giải thưởng";
            if (dgvGiaiTheoKhoa.Columns.Contains("SoLuong"))
                dgvGiaiTheoKhoa.Columns["SoLuong"].HeaderText = "Số lượng";
        }

        // =====================================================================
        // 2. THỐNG KÊ MỖI NGƯỜI ĐÃ NGỒI BAO NHIÊU HỘI ĐỒNG
        // =====================================================================
        private void btnThongKeHoiDong_Click(object sender, EventArgs e)
        {
            ThongKeHoiDong();
        }

        private void ThongKeHoiDong()
        {
            string namHoc = cboNamHocHoiDong.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        tv.MaSoCB,
                        gv.HoTen,
                        gv.DonViCongTac AS Khoa,
                        COUNT(*) AS SoLanThamGia
                    FROM ThanhVienHoiDong tv
                    INNER JOIN HoiDong hd ON tv.MaHD = hd.MaHD
                    INNER JOIN GiaoVien gv ON tv.MaSoCB = gv.MaSoCB
                    WHERE (@NamHoc = '' OR ISNULL(hd.NamHoc, '') = @NamHoc)
                    GROUP BY tv.MaSoCB, gv.HoTen, gv.DonViCongTac
                    ORDER BY gv.HoTen;";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvHoiDong.DataSource = dt;
                    }
                }
            }

            if (dgvHoiDong.Columns.Contains("MaSoCB"))
                dgvHoiDong.Columns["MaSoCB"].HeaderText = "Mã CB";
            if (dgvHoiDong.Columns.Contains("HoTen"))
                dgvHoiDong.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvHoiDong.Columns.Contains("Khoa"))
                dgvHoiDong.Columns["Khoa"].HeaderText = "Khoa / Đơn vị";
            if (dgvHoiDong.Columns.Contains("SoLanThamGia"))
                dgvHoiDong.Columns["SoLanThamGia"].HeaderText = "Số lần tham gia";
        }

        // =====================================================================
        // 3. THỐNG KÊ SỐ BÀI HỘI GIẢNG THEO NĂM HỌC + CẤP THỰC HIỆN
        // =====================================================================
        private void btnThongKeHoiGiang_Click(object sender, EventArgs e)
        {
            ThongKeHoiGiang();
        }

        private void ThongKeHoiGiang()
        {
            string namHoc = cboNamHocHoiGiang.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        ISNULL(hg.NamHoc, '') AS NamHoc,
                        ISNULL(hg.CapThucHien, N'Chưa rõ') AS CapThucHien,
                        COUNT(*) AS SoBai
                    FROM HoiGiang hg
                    WHERE (@NamHoc = '' OR ISNULL(hg.NamHoc, '') = @NamHoc)
                    GROUP BY ISNULL(hg.NamHoc, ''), ISNULL(hg.CapThucHien, N'Chưa rõ')
                    ORDER BY NamHoc, CapThucHien;";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvHoiGiangThongKe.DataSource = dt;
                    }
                }
            }

            if (dgvHoiGiangThongKe.Columns.Contains("NamHoc"))
                dgvHoiGiangThongKe.Columns["NamHoc"].HeaderText = "Năm học";
            if (dgvHoiGiangThongKe.Columns.Contains("CapThucHien"))
                dgvHoiGiangThongKe.Columns["CapThucHien"].HeaderText = "Cấp thực hiện";
            if (dgvHoiGiangThongKe.Columns.Contains("SoBai"))
                dgvHoiGiangThongKe.Columns["SoBai"].HeaderText = "Số bài hội giảng";
        }

        // =====================================================================
        // 4. THỐNG KÊ TỈ LỆ THAM GIA HỘI GIẢNG THEO KHOA
        // =====================================================================
        private void btnThongKeTiLe_Click(object sender, EventArgs e)
        {
            ThongKeTiLeThamGia();
        }

        private void ThongKeTiLeThamGia()
        {
            string namHoc = cboNamHocTiLe.Text.Trim(); // rỗng = tất cả

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    ;WITH GV_Khoa AS (
                        SELECT 
                            ISNULL(DonViCongTac, N'Chưa rõ') AS Khoa,
                            MaSoCB
                        FROM GiaoVien
                    ),
                    ThamGia AS (
                        SELECT DISTINCT 
                            ISNULL(gv.DonViCongTac, N'Chưa rõ') AS Khoa,
                            gv.MaSoCB
                        FROM HoiGiang hg
                        INNER JOIN GiaoVien gv ON hg.MaSoCB = gv.MaSoCB
                        WHERE (@NamHoc = '' OR ISNULL(hg.NamHoc, '') = @NamHoc)
                    )
                    SELECT 
                        k.Khoa,
                        COUNT(*) AS TongGV,
                        COUNT(DISTINCT t.MaSoCB) AS GVThamGia,
                        CASE 
                            WHEN COUNT(*) = 0 THEN 0
                            ELSE CAST(COUNT(DISTINCT t.MaSoCB) AS DECIMAL(10,2)) 
                                 / COUNT(*) * 100
                        END AS TiLeThamGia
                    FROM GV_Khoa k
                    LEFT JOIN ThamGia t 
                        ON k.Khoa = t.Khoa AND k.MaSoCB = t.MaSoCB
                    GROUP BY k.Khoa
                    ORDER BY k.Khoa;";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvTiLeThamGia.DataSource = dt;
                    }
                }
            }

            if (dgvTiLeThamGia.Columns.Contains("Khoa"))
                dgvTiLeThamGia.Columns["Khoa"].HeaderText = "Khoa / Đơn vị";
            if (dgvTiLeThamGia.Columns.Contains("TongGV"))
                dgvTiLeThamGia.Columns["TongGV"].HeaderText = "Tổng GV";
            if (dgvTiLeThamGia.Columns.Contains("GVThamGia"))
                dgvTiLeThamGia.Columns["GVThamGia"].HeaderText = "GV có hội giảng";
            if (dgvTiLeThamGia.Columns.Contains("TiLeThamGia"))
            {
                dgvTiLeThamGia.Columns["TiLeThamGia"].HeaderText = "Tỉ lệ tham gia (%)";
                dgvTiLeThamGia.Columns["TiLeThamGia"].DefaultCellStyle.Format = "0.00";
            }
        }

        // =====================================================================
        // 5. XUẤT CSV (MỞ BẰNG EXCEL)
        // =====================================================================
        private void ExportGridToCsv(DataGridView dgv)
        {
            if (dgv == null || dgv.Columns.Count == 0 || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV file (*.csv)|*.csv";
                sfd.FileName = "thongke.csv";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        // Header
                        bool firstCol = true;
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (!col.Visible) continue;
                            if (!firstCol) sw.Write(";");
                            sw.Write(col.HeaderText);
                            firstCol = false;
                        }
                        sw.WriteLine();

                        // Rows
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;

                            firstCol = true;
                            foreach (DataGridViewColumn col in dgv.Columns)
                            {
                                if (!col.Visible) continue;

                                if (!firstCol) sw.Write(";");
                                var val = row.Cells[col.Index].Value;
                                string text = val == null ? "" : val.ToString();

                                // thay dấu ; để tránh vỡ cột
                                text = text.Replace(";", ",");

                                sw.Write(text);
                                firstCol = false;
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show("Đã xuất file CSV. Bạn có thể mở bằng Excel.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message);
                }
            }
        }

        private void frmThongKe_Load_1(object sender, EventArgs e)
        {

        }
    }
}
