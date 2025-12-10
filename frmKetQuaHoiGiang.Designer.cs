using Krypton.Toolkit;
using System.Drawing;
using System.Windows.Forms;

namespace frmGiaoVien
{
    partial class frmKetQuaHoiGiang
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlMain = new KryptonPanel();
            layoutMain = new TableLayoutPanel();
            lblTitle = new KryptonLabel();
            grpThongTin = new KryptonGroupBox();
            tableInfo = new TableLayoutPanel();
            lblHoiGiang = new KryptonLabel();
            cboHoiGiang = new KryptonComboBox();
            lblHoTenGV = new KryptonLabel();
            txtHoTenGV = new KryptonTextBox();
            lblCapBac = new KryptonLabel();
            txtCapBac = new KryptonTextBox();
            lblDonVi = new KryptonLabel();
            txtDonVi = new KryptonTextBox();
            lblTenBai = new KryptonLabel();
            txtTenBai = new KryptonTextBox();
            lblCapThucHien = new KryptonLabel();
            txtCapThucHien = new KryptonTextBox();
            grpDiem = new KryptonGroupBox();
            tableScore = new TableLayoutPanel();
            lblDiemHieuBiet = new KryptonLabel();
            txtDiemHieuBiet = new KryptonTextBox();
            lblDiemGioiThieu = new KryptonLabel();
            txtDiemGioiThieu = new KryptonTextBox();
            lblP1 = new KryptonLabel();
            txtDiemThucHanh1 = new KryptonTextBox();
            lblP2 = new KryptonLabel();
            txtDiemThucHanh2 = new KryptonTextBox();
            lblP3 = new KryptonLabel();
            txtDiemThucHanh3 = new KryptonTextBox();
            lblP4 = new KryptonLabel();
            txtDiemThucHanh4 = new KryptonTextBox();
            lblP5 = new KryptonLabel();
            txtDiemThucHanh5 = new KryptonTextBox();
            lblDiemThucHanhTB = new KryptonLabel();
            txtDiemThucHanhTB = new KryptonTextBox();
            lblTongDiem = new KryptonLabel();
            txtTongDiem = new KryptonTextBox();
            lblGiaiThuong = new KryptonLabel();
            cboGiaiThuong = new KryptonComboBox();
            grpSearch = new KryptonGroupBox();
            searchLayout = new TableLayoutPanel();
            lblTim = new KryptonLabel();
            txtTimKiem = new KryptonTextBox();
            btnTim = new KryptonButton();
            dgvKetQua = new KryptonDataGridView();
            buttonPanel = new TableLayoutPanel();
            flowButtons = new FlowLayoutPanel();
            btnThem = new KryptonButton();
            btnSua = new KryptonButton();
            btnXoa = new KryptonButton();
            btnLuu = new KryptonButton();
            btnHuy = new KryptonButton();
            ((System.ComponentModel.ISupportInitialize)pnlMain).BeginInit();
            pnlMain.SuspendLayout();
            layoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpThongTin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpThongTin.Panel).BeginInit();
            grpThongTin.Panel.SuspendLayout();
            grpThongTin.SuspendLayout();
            tableInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboHoiGiang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpDiem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpDiem.Panel).BeginInit();
            grpDiem.Panel.SuspendLayout();
            grpDiem.SuspendLayout();
            tableScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboGiaiThuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpSearch.Panel).BeginInit();
            grpSearch.Panel.SuspendLayout();
            grpSearch.SuspendLayout();
            searchLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            buttonPanel.SuspendLayout();
            flowButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Padding = new Padding(16);
            pnlMain.Controls.Add(layoutMain);
            // 
            // layoutMain
            // 
            layoutMain.ColumnCount = 1;
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.RowCount = 6;
            layoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layoutMain.Controls.Add(lblTitle, 0, 0);
            layoutMain.Controls.Add(grpThongTin, 0, 1);
            layoutMain.Controls.Add(grpDiem, 0, 2);
            layoutMain.Controls.Add(grpSearch, 0, 3);
            layoutMain.Controls.Add(dgvKetQua, 0, 4);
            layoutMain.Controls.Add(buttonPanel, 0, 5);
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 40;
            lblTitle.Text = "KẾT QUẢ HỘI GIẢNG";
            lblTitle.StateCommon.ShortText.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;
            lblTitle.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
            lblTitle.Margin = new Padding(0, 0, 0, 10);
            // 
            // grpThongTin
            // 
            grpThongTin.Text = "Thông tin hội giảng";
            grpThongTin.Panel.Padding = new Padding(10);
            grpThongTin.Dock = DockStyle.Top;
            grpThongTin.Margin = new Padding(0, 0, 0, 10);
            grpThongTin.Panel.Controls.Add(tableInfo);
            // 
            // tableInfo
            // 
            tableInfo.ColumnCount = 4;
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableInfo.Dock = DockStyle.Fill;
            tableInfo.RowCount = 3;
            tableInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableInfo.Padding = new Padding(5);
            tableInfo.Controls.Add(lblHoiGiang, 0, 0);
            tableInfo.Controls.Add(cboHoiGiang, 1, 0);
            tableInfo.Controls.Add(lblHoTenGV, 2, 0);
            tableInfo.Controls.Add(txtHoTenGV, 3, 0);
            tableInfo.Controls.Add(lblCapBac, 0, 1);
            tableInfo.Controls.Add(txtCapBac, 1, 1);
            tableInfo.Controls.Add(lblDonVi, 2, 1);
            tableInfo.Controls.Add(txtDonVi, 3, 1);
            tableInfo.Controls.Add(lblTenBai, 0, 2);
            tableInfo.Controls.Add(txtTenBai, 1, 2);
            tableInfo.Controls.Add(lblCapThucHien, 2, 2);
            tableInfo.Controls.Add(txtCapThucHien, 3, 2);
            // 
            // lblHoiGiang
            // 
            lblHoiGiang.Text = "Chọn hội giảng";
            lblHoiGiang.Margin = new Padding(5);
            // 
            // cboHoiGiang
            // 
            cboHoiGiang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHoiGiang.Margin = new Padding(5);
            // 
            // lblHoTenGV
            // 
            lblHoTenGV.Text = "Họ tên GV";
            lblHoTenGV.Margin = new Padding(5);
            // 
            // txtHoTenGV
            // 
            txtHoTenGV.Margin = new Padding(5);
            txtHoTenGV.ReadOnly = true;
            // 
            // lblCapBac
            // 
            lblCapBac.Text = "Cấp bậc";
            lblCapBac.Margin = new Padding(5);
            // 
            // txtCapBac
            // 
            txtCapBac.Margin = new Padding(5);
            txtCapBac.ReadOnly = true;
            // 
            // lblDonVi
            // 
            lblDonVi.Text = "Đơn vị";
            lblDonVi.Margin = new Padding(5);
            // 
            // txtDonVi
            // 
            txtDonVi.Margin = new Padding(5);
            txtDonVi.ReadOnly = true;
            // 
            // lblTenBai
            // 
            lblTenBai.Text = "Tên bài";
            lblTenBai.Margin = new Padding(5);
            // 
            // txtTenBai
            // 
            txtTenBai.Margin = new Padding(5);
            txtTenBai.ReadOnly = true;
            // 
            // lblCapThucHien
            // 
            lblCapThucHien.Text = "Cấp thực hiện";
            lblCapThucHien.Margin = new Padding(5);
            // 
            // txtCapThucHien
            // 
            txtCapThucHien.Margin = new Padding(5);
            txtCapThucHien.ReadOnly = true;
            // 
            // grpDiem
            // 
            grpDiem.Text = "Điểm các phần thi";
            grpDiem.Dock = DockStyle.Top;
            grpDiem.Margin = new Padding(0, 0, 0, 10);
            grpDiem.Panel.Padding = new Padding(10);
            grpDiem.Panel.Controls.Add(tableScore);
            // 
            // tableScore
            // 
            tableScore.ColumnCount = 6;
            tableScore.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableScore.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableScore.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableScore.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableScore.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableScore.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableScore.Dock = DockStyle.Fill;
            tableScore.RowCount = 4;
            tableScore.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableScore.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableScore.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableScore.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableScore.Padding = new Padding(5);
            tableScore.Controls.Add(lblDiemHieuBiet, 0, 0);
            tableScore.Controls.Add(txtDiemHieuBiet, 1, 0);
            tableScore.Controls.Add(lblDiemGioiThieu, 2, 0);
            tableScore.Controls.Add(txtDiemGioiThieu, 3, 0);
            tableScore.Controls.Add(lblP1, 0, 1);
            tableScore.Controls.Add(txtDiemThucHanh1, 1, 1);
            tableScore.Controls.Add(lblP2, 2, 1);
            tableScore.Controls.Add(txtDiemThucHanh2, 3, 1);
            tableScore.Controls.Add(lblP3, 4, 1);
            tableScore.Controls.Add(txtDiemThucHanh3, 5, 1);
            tableScore.Controls.Add(lblP4, 0, 2);
            tableScore.Controls.Add(txtDiemThucHanh4, 1, 2);
            tableScore.Controls.Add(lblP5, 2, 2);
            tableScore.Controls.Add(txtDiemThucHanh5, 3, 2);
            tableScore.Controls.Add(lblDiemThucHanhTB, 0, 3);
            tableScore.Controls.Add(txtDiemThucHanhTB, 1, 3);
            tableScore.Controls.Add(lblTongDiem, 2, 3);
            tableScore.Controls.Add(txtTongDiem, 3, 3);
            tableScore.Controls.Add(lblGiaiThuong, 4, 3);
            tableScore.Controls.Add(cboGiaiThuong, 5, 3);
            // 
            // Score labels/controls
            lblDiemHieuBiet.Text = "Hiểu biết";
            lblDiemHieuBiet.Margin = new Padding(5);
            txtDiemHieuBiet.Margin = new Padding(5);
            lblDiemGioiThieu.Text = "Giới thiệu";
            lblDiemGioiThieu.Margin = new Padding(5);
            txtDiemGioiThieu.Margin = new Padding(5);
            lblP1.Text = "P1";
            lblP1.Margin = new Padding(5);
            txtDiemThucHanh1.Margin = new Padding(5);
            lblP2.Text = "P2";
            lblP2.Margin = new Padding(5);
            txtDiemThucHanh2.Margin = new Padding(5);
            lblP3.Text = "P3";
            lblP3.Margin = new Padding(5);
            txtDiemThucHanh3.Margin = new Padding(5);
            lblP4.Text = "P4";
            lblP4.Margin = new Padding(5);
            txtDiemThucHanh4.Margin = new Padding(5);
            lblP5.Text = "P5";
            lblP5.Margin = new Padding(5);
            txtDiemThucHanh5.Margin = new Padding(5);
            lblDiemThucHanhTB.Text = "Điểm TH TB";
            lblDiemThucHanhTB.Margin = new Padding(5);
            txtDiemThucHanhTB.Margin = new Padding(5);
            txtDiemThucHanhTB.ReadOnly = true;
            lblTongDiem.Text = "Tổng điểm";
            lblTongDiem.Margin = new Padding(5);
            txtTongDiem.Margin = new Padding(5);
            txtTongDiem.ReadOnly = true;
            lblGiaiThuong.Text = "Giải thưởng";
            lblGiaiThuong.Margin = new Padding(5);
            cboGiaiThuong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGiaiThuong.Margin = new Padding(5);
            // 
            // grpSearch
            // 
            grpSearch.Text = "Tìm kiếm";
            grpSearch.Dock = DockStyle.Top;
            grpSearch.Margin = new Padding(0, 0, 0, 10);
            grpSearch.Panel.Controls.Add(searchLayout);
            // 
            // searchLayout
            // 
            searchLayout.ColumnCount = 3;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            searchLayout.Dock = DockStyle.Fill;
            searchLayout.Padding = new Padding(10);
            searchLayout.Controls.Add(lblTim, 0, 0);
            searchLayout.Controls.Add(txtTimKiem, 1, 0);
            searchLayout.Controls.Add(btnTim, 2, 0);
            // 
            lblTim.Text = "Từ khóa:";
            lblTim.Margin = new Padding(5);
            txtTimKiem.Margin = new Padding(5);
            btnTim.Text = "Tìm";
            btnTim.Margin = new Padding(5);
            btnTim.Width = 90;
            // 
            // dgvKetQua
            // 
            dgvKetQua.Dock = DockStyle.Fill;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.MultiSelect = false;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.Margin = new Padding(0, 0, 0, 10);
            // 
            // buttonPanel
            // 
            buttonPanel.ColumnCount = 1;
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Controls.Add(flowButtons, 0, 0);
            // 
            // flowButtons
            // 
            flowButtons.Dock = DockStyle.Fill;
            flowButtons.FlowDirection = FlowDirection.LeftToRight;
            flowButtons.AutoSize = true;
            flowButtons.Controls.Add(btnThem);
            flowButtons.Controls.Add(btnSua);
            flowButtons.Controls.Add(btnXoa);
            flowButtons.Controls.Add(btnLuu);
            flowButtons.Controls.Add(btnHuy);
            flowButtons.Padding = new Padding(0, 5, 0, 5);
            btnThem.Text = "Thêm";
            btnSua.Text = "Sửa";
            btnXoa.Text = "Xóa";
            btnLuu.Text = "Lưu";
            btnHuy.Text = "Hủy";
            foreach (var btn in new[] { btnThem, btnSua, btnXoa, btnLuu, btnHuy })
            {
                btn.Width = 100;
                btn.Margin = new Padding(5);
            }
            // 
            // frmKetQuaHoiGiang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 900);
            Controls.Add(pnlMain);
            Name = "frmKetQuaHoiGiang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kết quả hội giảng";
            ((System.ComponentModel.ISupportInitialize)pnlMain).EndInit();
            pnlMain.ResumeLayout(false);
            layoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grpThongTin.Panel).EndInit();
            grpThongTin.Panel.ResumeLayout(false);
            grpThongTin.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grpThongTin).EndInit();
            grpThongTin.ResumeLayout(false);
            tableInfo.ResumeLayout(false);
            tableInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cboHoiGiang).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpDiem.Panel).EndInit();
            grpDiem.Panel.ResumeLayout(false);
            grpDiem.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grpDiem).EndInit();
            grpDiem.ResumeLayout(false);
            tableScore.ResumeLayout(false);
            tableScore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cboGiaiThuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpSearch.Panel).EndInit();
            grpSearch.Panel.ResumeLayout(false);
            grpSearch.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grpSearch).EndInit();
            grpSearch.ResumeLayout(false);
            searchLayout.ResumeLayout(false);
            searchLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            buttonPanel.ResumeLayout(false);
            buttonPanel.PerformLayout();
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private KryptonPanel pnlMain;
        private TableLayoutPanel layoutMain;
        private KryptonLabel lblTitle;
        private KryptonGroupBox grpThongTin;
        private TableLayoutPanel tableInfo;
        private KryptonLabel lblHoiGiang;
        private KryptonComboBox cboHoiGiang;
        private KryptonLabel lblHoTenGV;
        private KryptonTextBox txtHoTenGV;
        private KryptonLabel lblCapBac;
        private KryptonTextBox txtCapBac;
        private KryptonLabel lblDonVi;
        private KryptonTextBox txtDonVi;
        private KryptonLabel lblTenBai;
        private KryptonTextBox txtTenBai;
        private KryptonLabel lblCapThucHien;
        private KryptonTextBox txtCapThucHien;
        private KryptonGroupBox grpDiem;
        private TableLayoutPanel tableScore;
        private KryptonLabel lblDiemHieuBiet;
        private KryptonTextBox txtDiemHieuBiet;
        private KryptonLabel lblDiemGioiThieu;
        private KryptonTextBox txtDiemGioiThieu;
        private KryptonLabel lblP1;
        private KryptonTextBox txtDiemThucHanh1;
        private KryptonLabel lblP2;
        private KryptonTextBox txtDiemThucHanh2;
        private KryptonLabel lblP3;
        private KryptonTextBox txtDiemThucHanh3;
        private KryptonLabel lblP4;
        private KryptonTextBox txtDiemThucHanh4;
        private KryptonLabel lblP5;
        private KryptonTextBox txtDiemThucHanh5;
        private KryptonLabel lblDiemThucHanhTB;
        private KryptonTextBox txtDiemThucHanhTB;
        private KryptonLabel lblTongDiem;
        private KryptonTextBox txtTongDiem;
        private KryptonLabel lblGiaiThuong;
        private KryptonComboBox cboGiaiThuong;
        private KryptonGroupBox grpSearch;
        private TableLayoutPanel searchLayout;
        private KryptonLabel lblTim;
        private KryptonTextBox txtTimKiem;
        private KryptonButton btnTim;
        private KryptonDataGridView dgvKetQua;
        private TableLayoutPanel buttonPanel;
        private FlowLayoutPanel flowButtons;
        private KryptonButton btnThem;
        private KryptonButton btnSua;
        private KryptonButton btnXoa;
        private KryptonButton btnLuu;
        private KryptonButton btnHuy;
    }
}
