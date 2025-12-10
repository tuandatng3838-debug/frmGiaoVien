using Krypton.Toolkit;
using System.Drawing;
using System.Windows.Forms;

namespace frmGiaoVien
{
    partial class frmHoiGiang
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
            components = new System.ComponentModel.Container();
            pnlMain = new KryptonPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new KryptonLabel();
            infoGroup = new KryptonGroupBox();
            tableInfo = new TableLayoutPanel();
            lblMaHG = new KryptonLabel();
            txtMaHG = new KryptonTextBox();
            lblGiaoVien = new KryptonLabel();
            cboGiaoVien = new KryptonComboBox();
            lblCapBac = new KryptonLabel();
            txtCapBac = new KryptonTextBox();
            lblDonVi = new KryptonLabel();
            txtDonVi = new KryptonTextBox();
            lblChucDanhGD = new KryptonLabel();
            cboChucDanhGD = new KryptonComboBox();
            lblTenBai = new KryptonLabel();
            txtTenBai = new KryptonTextBox();
            lblHocPhan = new KryptonLabel();
            txtHocPhan = new KryptonTextBox();
            lblLop = new KryptonLabel();
            txtLop = new KryptonTextBox();
            lblThoiGian = new KryptonLabel();
            dtpThoiGian = new KryptonDateTimePicker();
            lblCapThucHien = new KryptonLabel();
            cboCapThucHien = new KryptonComboBox();
            searchGroup = new KryptonGroupBox();
            searchLayout = new TableLayoutPanel();
            lblTimKiem = new KryptonLabel();
            txtTimKiem = new KryptonTextBox();
            btnTim = new KryptonButton();
            dgvHoiGiang = new KryptonDataGridView();
            buttonPanel = new TableLayoutPanel();
            flowButtons = new FlowLayoutPanel();
            btnThem = new KryptonButton();
            btnSua = new KryptonButton();
            btnXoa = new KryptonButton();
            btnLuu = new KryptonButton();
            btnHuy = new KryptonButton();
            ((System.ComponentModel.ISupportInitialize)pnlMain).BeginInit();
            pnlMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)infoGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)infoGroup.Panel).BeginInit();
            infoGroup.Panel.SuspendLayout();
            infoGroup.SuspendLayout();
            tableInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cboGiaoVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboChucDanhGD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cboCapThucHien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchGroup.Panel).BeginInit();
            searchGroup.Panel.SuspendLayout();
            searchGroup.SuspendLayout();
            searchLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiGiang).BeginInit();
            buttonPanel.SuspendLayout();
            flowButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Padding = new Padding(16);
            pnlMain.Controls.Add(tableLayoutPanel1);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Controls.Add(infoGroup, 0, 1);
            tableLayoutPanel1.Controls.Add(searchGroup, 0, 2);
            tableLayoutPanel1.Controls.Add(dgvHoiGiang, 0, 3);
            tableLayoutPanel1.Controls.Add(buttonPanel, 0, 4);
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.AutoSize = false;
            lblTitle.Text = "ĐĂNG KÝ HỘI GIẢNG";
            lblTitle.StateCommon.ShortText.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;
            lblTitle.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
            lblTitle.Margin = new Padding(0, 0, 0, 10);
            lblTitle.Height = 40;
            // 
            // infoGroup
            // 
            infoGroup.Text = "Thông tin hội giảng";
            infoGroup.Dock = DockStyle.Top;
            infoGroup.Panel.Padding = new Padding(10);
            infoGroup.Margin = new Padding(0, 0, 0, 10);
            infoGroup.Panel.Controls.Add(tableInfo);
            // 
            // tableInfo
            // 
            tableInfo.ColumnCount = 4;
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableInfo.Dock = DockStyle.Fill;
            tableInfo.RowCount = 5;
            tableInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableInfo.Controls.Add(lblMaHG, 0, 0);
            tableInfo.Controls.Add(txtMaHG, 1, 0);
            tableInfo.Controls.Add(lblGiaoVien, 2, 0);
            tableInfo.Controls.Add(cboGiaoVien, 3, 0);
            tableInfo.Controls.Add(lblCapBac, 0, 1);
            tableInfo.Controls.Add(txtCapBac, 1, 1);
            tableInfo.Controls.Add(lblDonVi, 2, 1);
            tableInfo.Controls.Add(txtDonVi, 3, 1);
            tableInfo.Controls.Add(lblChucDanhGD, 0, 2);
            tableInfo.Controls.Add(cboChucDanhGD, 1, 2);
            tableInfo.Controls.Add(lblTenBai, 2, 2);
            tableInfo.Controls.Add(txtTenBai, 3, 2);
            tableInfo.Controls.Add(lblHocPhan, 0, 3);
            tableInfo.Controls.Add(txtHocPhan, 1, 3);
            tableInfo.Controls.Add(lblLop, 2, 3);
            tableInfo.Controls.Add(txtLop, 3, 3);
            tableInfo.Controls.Add(lblThoiGian, 0, 4);
            tableInfo.Controls.Add(dtpThoiGian, 1, 4);
            tableInfo.Controls.Add(lblCapThucHien, 2, 4);
            tableInfo.Controls.Add(cboCapThucHien, 3, 4);
            tableInfo.Padding = new Padding(5);
            tableInfo.AutoSize = true;
            // 
            // lblMaHG
            // 
            lblMaHG.Text = "Mã hội giảng (*)";
            lblMaHG.Margin = new Padding(5);
            lblMaHG.Visible = false;
            // 
            // txtMaHG
            // 
            txtMaHG.Margin = new Padding(5);
            txtMaHG.Visible = false;
            // 
            // lblGiaoVien
            // 
            lblGiaoVien.Text = "Họ tên GV";
            lblGiaoVien.Margin = new Padding(5);
            // 
            // cboGiaoVien
            // 
            cboGiaoVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGiaoVien.Margin = new Padding(5);
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
            // lblChucDanhGD
            // 
            lblChucDanhGD.Text = "Chức danh GD";
            lblChucDanhGD.Margin = new Padding(5);
            // 
            // cboChucDanhGD
            // 
            cboChucDanhGD.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucDanhGD.Margin = new Padding(5);
            // 
            // lblTenBai
            // 
            lblTenBai.Text = "Tên bài";
            lblTenBai.Margin = new Padding(5);
            // 
            // txtTenBai
            // 
            txtTenBai.Margin = new Padding(5);
            // 
            // lblHocPhan
            // 
            lblHocPhan.Text = "Thuộc học phần";
            lblHocPhan.Margin = new Padding(5);
            // 
            // txtHocPhan
            // 
            txtHocPhan.Margin = new Padding(5);
            // 
            // lblLop
            // 
            lblLop.Text = "Thực hiện lớp";
            lblLop.Margin = new Padding(5);
            // 
            // txtLop
            // 
            txtLop.Margin = new Padding(5);
            // 
            // lblThoiGian
            // 
            lblThoiGian.Text = "Thời gian";
            lblThoiGian.Margin = new Padding(5);
            // 
            // dtpThoiGian
            // 
            dtpThoiGian.Format = DateTimePickerFormat.Custom;
            dtpThoiGian.CustomFormat = "dd/MM/yyyy";
            dtpThoiGian.Margin = new Padding(5);
            // 
            // lblCapThucHien
            // 
            lblCapThucHien.Text = "Cấp thực hiện";
            lblCapThucHien.Margin = new Padding(5);
            // 
            // cboCapThucHien
            // 
            cboCapThucHien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCapThucHien.Margin = new Padding(5);
            // 
            // searchGroup
            // 
            searchGroup.Text = "Tìm kiếm";
            searchGroup.Dock = DockStyle.Top;
            searchGroup.Margin = new Padding(0, 0, 0, 10);
            searchGroup.Panel.Controls.Add(searchLayout);
            // 
            // searchLayout
            // 
            searchLayout.ColumnCount = 3;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            searchLayout.Dock = DockStyle.Fill;
            searchLayout.Padding = new Padding(10);
            searchLayout.Controls.Add(lblTimKiem, 0, 0);
            searchLayout.Controls.Add(txtTimKiem, 1, 0);
            searchLayout.Controls.Add(btnTim, 2, 0);
            // 
            // lblTimKiem
            // 
            lblTimKiem.Text = "Từ khóa:";
            lblTimKiem.Margin = new Padding(5);
            // 
            // txtTimKiem
            // 
            txtTimKiem.Margin = new Padding(5);
            // 
            // btnTim
            // 
            btnTim.Text = "Tìm";
            btnTim.Margin = new Padding(5);
            btnTim.Width = 90;
            // 
            // dgvHoiGiang
            // 
            dgvHoiGiang.Dock = DockStyle.Fill;
            dgvHoiGiang.Margin = new Padding(0, 0, 0, 10);
            dgvHoiGiang.AllowUserToAddRows = false;
            dgvHoiGiang.AllowUserToDeleteRows = false;
            dgvHoiGiang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoiGiang.MultiSelect = false;
            dgvHoiGiang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            // 
            // btnThem
            // 
            btnThem.Text = "Thêm";
            btnThem.Width = 100;
            btnThem.Margin = new Padding(5);
            // 
            // btnSua
            // 
            btnSua.Text = "Sửa";
            btnSua.Width = 100;
            btnSua.Margin = new Padding(5);
            // 
            // btnXoa
            // 
            btnXoa.Text = "Xóa";
            btnXoa.Width = 100;
            btnXoa.Margin = new Padding(5);
            // 
            // btnLuu
            // 
            btnLuu.Text = "Lưu";
            btnLuu.Width = 100;
            btnLuu.Margin = new Padding(5);
            // 
            // btnHuy
            // 
            btnHuy.Text = "Hủy";
            btnHuy.Width = 100;
            btnHuy.Margin = new Padding(5);
            // 
            // frmHoiGiang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 850);
            Controls.Add(pnlMain);
            Name = "frmHoiGiang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký hội giảng";
            ((System.ComponentModel.ISupportInitialize)pnlMain).EndInit();
            pnlMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)infoGroup.Panel).EndInit();
            infoGroup.Panel.ResumeLayout(false);
            infoGroup.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)infoGroup).EndInit();
            infoGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cboGiaoVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboChucDanhGD).EndInit();
            ((System.ComponentModel.ISupportInitialize)cboCapThucHien).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchGroup.Panel).EndInit();
            searchGroup.Panel.ResumeLayout(false);
            searchGroup.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)searchGroup).EndInit();
            searchGroup.ResumeLayout(false);
            searchLayout.ResumeLayout(false);
            searchLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiGiang).EndInit();
            buttonPanel.ResumeLayout(false);
            buttonPanel.PerformLayout();
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private KryptonPanel pnlMain;
        private TableLayoutPanel tableLayoutPanel1;
        private KryptonLabel lblTitle;
        private KryptonGroupBox infoGroup;
        private TableLayoutPanel tableInfo;
        private KryptonLabel lblMaHG;
        private KryptonTextBox txtMaHG;
        private KryptonLabel lblGiaoVien;
        private KryptonComboBox cboGiaoVien;
        private KryptonLabel lblCapBac;
        private KryptonTextBox txtCapBac;
        private KryptonLabel lblDonVi;
        private KryptonTextBox txtDonVi;
        private KryptonLabel lblChucDanhGD;
        private KryptonComboBox cboChucDanhGD;
        private KryptonLabel lblTenBai;
        private KryptonTextBox txtTenBai;
        private KryptonLabel lblHocPhan;
        private KryptonTextBox txtHocPhan;
        private KryptonLabel lblLop;
        private KryptonTextBox txtLop;
        private KryptonLabel lblThoiGian;
        private KryptonDateTimePicker dtpThoiGian;
        private KryptonLabel lblCapThucHien;
        private KryptonComboBox cboCapThucHien;
        private KryptonGroupBox searchGroup;
        private TableLayoutPanel searchLayout;
        private KryptonLabel lblTimKiem;
        private KryptonTextBox txtTimKiem;
        private KryptonButton btnTim;
        private KryptonDataGridView dgvHoiGiang;
        private TableLayoutPanel buttonPanel;
        private FlowLayoutPanel flowButtons;
        private KryptonButton btnThem;
        private KryptonButton btnSua;
        private KryptonButton btnXoa;
        private KryptonButton btnLuu;
        private KryptonButton btnHuy;
    }
}
