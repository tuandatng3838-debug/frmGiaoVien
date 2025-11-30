using System.Windows.Forms;

namespace frmGiaoVien
{
    partial class frmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            lblTitle = new Label();
            tabControl1 = new TabControl();
            tabKhoa = new TabPage();
            dgvGiaiTheoKhoa = new DataGridView();
            grpKhoaFilter = new GroupBox();
            btnExportKhoa = new Button();
            btnThongKeKhoa = new Button();
            cboNamHocKhoa = new ComboBox();
            lblNamHocKhoa = new Label();
            tabHoiDong = new TabPage();
            dgvHoiDong = new DataGridView();
            grpHoiDongFilter = new GroupBox();
            btnExportHoiDong = new Button();
            btnThongKeHoiDong = new Button();
            cboNamHocHoiDong = new ComboBox();
            lblNamHocHoiDong = new Label();
            tabHoiGiang = new TabPage();
            dgvHoiGiangThongKe = new DataGridView();
            grpHoiGiangFilter = new GroupBox();
            btnExportHoiGiang = new Button();
            btnThongKeHoiGiang = new Button();
            cboNamHocHoiGiang = new ComboBox();
            lblNamHocHoiGiang = new Label();
            tabTiLe = new TabPage();
            dgvTiLeThamGia = new DataGridView();
            grpTiLeFilter = new GroupBox();
            btnExportTiLe = new Button();
            btnThongKeTiLe = new Button();
            cboNamHocTiLe = new ComboBox();
            lblNamHocTiLe = new Label();
            tabControl1.SuspendLayout();
            tabKhoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGiaiTheoKhoa).BeginInit();
            grpKhoaFilter.SuspendLayout();
            tabHoiDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiDong).BeginInit();
            grpHoiDongFilter.SuspendLayout();
            tabHoiGiang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoiGiangThongKe).BeginInit();
            grpHoiGiangFilter.SuspendLayout();
            tabTiLe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTiLeThamGia).BeginInit();
            grpTiLeFilter.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1371, 53);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THỐNG KÊ / BÁO CÁO";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabKhoa);
            tabControl1.Controls.Add(tabHoiDong);
            tabControl1.Controls.Add(tabHoiGiang);
            tabControl1.Controls.Add(tabTiLe);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 53);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1371, 814);
            tabControl1.TabIndex = 1;
            // 
            // tabKhoa
            // 
            tabKhoa.Controls.Add(dgvGiaiTheoKhoa);
            tabKhoa.Controls.Add(grpKhoaFilter);
            tabKhoa.Location = new Point(4, 29);
            tabKhoa.Margin = new Padding(3, 4, 3, 4);
            tabKhoa.Name = "tabKhoa";
            tabKhoa.Padding = new Padding(3, 4, 3, 4);
            tabKhoa.Size = new Size(1363, 781);
            tabKhoa.TabIndex = 0;
            tabKhoa.Text = "Giải theo khoa";
            tabKhoa.UseVisualStyleBackColor = true;
            // 
            // dgvGiaiTheoKhoa
            // 
            dgvGiaiTheoKhoa.AllowUserToAddRows = false;
            dgvGiaiTheoKhoa.AllowUserToDeleteRows = false;
            dgvGiaiTheoKhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGiaiTheoKhoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiaiTheoKhoa.Dock = DockStyle.Fill;
            dgvGiaiTheoKhoa.Location = new Point(3, 84);
            dgvGiaiTheoKhoa.Margin = new Padding(3, 4, 3, 4);
            dgvGiaiTheoKhoa.MultiSelect = false;
            dgvGiaiTheoKhoa.Name = "dgvGiaiTheoKhoa";
            dgvGiaiTheoKhoa.ReadOnly = true;
            dgvGiaiTheoKhoa.RowHeadersWidth = 51;
            dgvGiaiTheoKhoa.RowTemplate.Height = 25;
            dgvGiaiTheoKhoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiaiTheoKhoa.Size = new Size(1357, 693);
            dgvGiaiTheoKhoa.TabIndex = 1;
            // 
            // grpKhoaFilter
            // 
            grpKhoaFilter.Controls.Add(btnExportKhoa);
            grpKhoaFilter.Controls.Add(btnThongKeKhoa);
            grpKhoaFilter.Controls.Add(cboNamHocKhoa);
            grpKhoaFilter.Controls.Add(lblNamHocKhoa);
            grpKhoaFilter.Dock = DockStyle.Top;
            grpKhoaFilter.Location = new Point(3, 4);
            grpKhoaFilter.Margin = new Padding(3, 4, 3, 4);
            grpKhoaFilter.Name = "grpKhoaFilter";
            grpKhoaFilter.Padding = new Padding(3, 4, 3, 4);
            grpKhoaFilter.Size = new Size(1357, 80);
            grpKhoaFilter.TabIndex = 0;
            grpKhoaFilter.TabStop = false;
            grpKhoaFilter.Text = "Lọc theo năm học";
            // 
            // btnExportKhoa
            // 
            btnExportKhoa.Anchor = AnchorStyles.Right;
            btnExportKhoa.Location = new Point(1159, 29);
            btnExportKhoa.Margin = new Padding(3, 4, 3, 4);
            btnExportKhoa.Name = "btnExportKhoa";
            btnExportKhoa.Size = new Size(86, 33);
            btnExportKhoa.TabIndex = 3;
            btnExportKhoa.Text = "Xuất CSV";
            btnExportKhoa.UseVisualStyleBackColor = true;
            // 
            // btnThongKeKhoa
            // 
            btnThongKeKhoa.Anchor = AnchorStyles.Right;
            btnThongKeKhoa.Location = new Point(1251, 29);
            btnThongKeKhoa.Margin = new Padding(3, 4, 3, 4);
            btnThongKeKhoa.Name = "btnThongKeKhoa";
            btnThongKeKhoa.Size = new Size(86, 33);
            btnThongKeKhoa.TabIndex = 2;
            btnThongKeKhoa.Text = "Thống kê";
            btnThongKeKhoa.UseVisualStyleBackColor = true;
            // 
            // cboNamHocKhoa
            // 
            cboNamHocKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNamHocKhoa.FormattingEnabled = true;
            cboNamHocKhoa.Location = new Point(103, 31);
            cboNamHocKhoa.Margin = new Padding(3, 4, 3, 4);
            cboNamHocKhoa.Name = "cboNamHocKhoa";
            cboNamHocKhoa.Size = new Size(228, 28);
            cboNamHocKhoa.TabIndex = 1;
            // 
            // lblNamHocKhoa
            // 
            lblNamHocKhoa.AutoSize = true;
            lblNamHocKhoa.Location = new Point(23, 35);
            lblNamHocKhoa.Name = "lblNamHocKhoa";
            lblNamHocKhoa.Size = new Size(72, 20);
            lblNamHocKhoa.TabIndex = 0;
            lblNamHocKhoa.Text = "Năm học:";
            // 
            // tabHoiDong
            // 
            tabHoiDong.Controls.Add(dgvHoiDong);
            tabHoiDong.Controls.Add(grpHoiDongFilter);
            tabHoiDong.Location = new Point(4, 29);
            tabHoiDong.Margin = new Padding(3, 4, 3, 4);
            tabHoiDong.Name = "tabHoiDong";
            tabHoiDong.Padding = new Padding(3, 4, 3, 4);
            tabHoiDong.Size = new Size(1363, 780);
            tabHoiDong.TabIndex = 1;
            tabHoiDong.Text = "Số lần ngồi Hội đồng";
            tabHoiDong.UseVisualStyleBackColor = true;
            // 
            // dgvHoiDong
            // 
            dgvHoiDong.AllowUserToAddRows = false;
            dgvHoiDong.AllowUserToDeleteRows = false;
            dgvHoiDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiDong.Dock = DockStyle.Fill;
            dgvHoiDong.Location = new Point(3, 84);
            dgvHoiDong.Margin = new Padding(3, 4, 3, 4);
            dgvHoiDong.MultiSelect = false;
            dgvHoiDong.Name = "dgvHoiDong";
            dgvHoiDong.ReadOnly = true;
            dgvHoiDong.RowHeadersWidth = 51;
            dgvHoiDong.RowTemplate.Height = 25;
            dgvHoiDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoiDong.Size = new Size(1357, 692);
            dgvHoiDong.TabIndex = 1;
            // 
            // grpHoiDongFilter
            // 
            grpHoiDongFilter.Controls.Add(btnExportHoiDong);
            grpHoiDongFilter.Controls.Add(btnThongKeHoiDong);
            grpHoiDongFilter.Controls.Add(cboNamHocHoiDong);
            grpHoiDongFilter.Controls.Add(lblNamHocHoiDong);
            grpHoiDongFilter.Dock = DockStyle.Top;
            grpHoiDongFilter.Location = new Point(3, 4);
            grpHoiDongFilter.Margin = new Padding(3, 4, 3, 4);
            grpHoiDongFilter.Name = "grpHoiDongFilter";
            grpHoiDongFilter.Padding = new Padding(3, 4, 3, 4);
            grpHoiDongFilter.Size = new Size(1357, 80);
            grpHoiDongFilter.TabIndex = 0;
            grpHoiDongFilter.TabStop = false;
            grpHoiDongFilter.Text = "Lọc theo năm học";
            // 
            // btnExportHoiDong
            // 
            btnExportHoiDong.Anchor = AnchorStyles.Right;
            btnExportHoiDong.Location = new Point(1159, 29);
            btnExportHoiDong.Margin = new Padding(3, 4, 3, 4);
            btnExportHoiDong.Name = "btnExportHoiDong";
            btnExportHoiDong.Size = new Size(86, 33);
            btnExportHoiDong.TabIndex = 3;
            btnExportHoiDong.Text = "Xuất CSV";
            btnExportHoiDong.UseVisualStyleBackColor = true;
            // 
            // btnThongKeHoiDong
            // 
            btnThongKeHoiDong.Anchor = AnchorStyles.Right;
            btnThongKeHoiDong.Location = new Point(1251, 29);
            btnThongKeHoiDong.Margin = new Padding(3, 4, 3, 4);
            btnThongKeHoiDong.Name = "btnThongKeHoiDong";
            btnThongKeHoiDong.Size = new Size(86, 33);
            btnThongKeHoiDong.TabIndex = 2;
            btnThongKeHoiDong.Text = "Thống kê";
            btnThongKeHoiDong.UseVisualStyleBackColor = true;
            // 
            // cboNamHocHoiDong
            // 
            cboNamHocHoiDong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNamHocHoiDong.FormattingEnabled = true;
            cboNamHocHoiDong.Location = new Point(103, 31);
            cboNamHocHoiDong.Margin = new Padding(3, 4, 3, 4);
            cboNamHocHoiDong.Name = "cboNamHocHoiDong";
            cboNamHocHoiDong.Size = new Size(228, 28);
            cboNamHocHoiDong.TabIndex = 1;
            // 
            // lblNamHocHoiDong
            // 
            lblNamHocHoiDong.AutoSize = true;
            lblNamHocHoiDong.Location = new Point(23, 35);
            lblNamHocHoiDong.Name = "lblNamHocHoiDong";
            lblNamHocHoiDong.Size = new Size(72, 20);
            lblNamHocHoiDong.TabIndex = 0;
            lblNamHocHoiDong.Text = "Năm học:";
            // 
            // tabHoiGiang
            // 
            tabHoiGiang.Controls.Add(dgvHoiGiangThongKe);
            tabHoiGiang.Controls.Add(grpHoiGiangFilter);
            tabHoiGiang.Location = new Point(4, 29);
            tabHoiGiang.Margin = new Padding(3, 4, 3, 4);
            tabHoiGiang.Name = "tabHoiGiang";
            tabHoiGiang.Padding = new Padding(3, 4, 3, 4);
            tabHoiGiang.Size = new Size(1363, 780);
            tabHoiGiang.TabIndex = 2;
            tabHoiGiang.Text = "Số bài hội giảng";
            tabHoiGiang.UseVisualStyleBackColor = true;
            // 
            // dgvHoiGiangThongKe
            // 
            dgvHoiGiangThongKe.AllowUserToAddRows = false;
            dgvHoiGiangThongKe.AllowUserToDeleteRows = false;
            dgvHoiGiangThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiGiangThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoiGiangThongKe.Dock = DockStyle.Fill;
            dgvHoiGiangThongKe.Location = new Point(3, 84);
            dgvHoiGiangThongKe.Margin = new Padding(3, 4, 3, 4);
            dgvHoiGiangThongKe.MultiSelect = false;
            dgvHoiGiangThongKe.Name = "dgvHoiGiangThongKe";
            dgvHoiGiangThongKe.ReadOnly = true;
            dgvHoiGiangThongKe.RowHeadersWidth = 51;
            dgvHoiGiangThongKe.RowTemplate.Height = 25;
            dgvHoiGiangThongKe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoiGiangThongKe.Size = new Size(1357, 692);
            dgvHoiGiangThongKe.TabIndex = 1;
            // 
            // grpHoiGiangFilter
            // 
            grpHoiGiangFilter.Controls.Add(btnExportHoiGiang);
            grpHoiGiangFilter.Controls.Add(btnThongKeHoiGiang);
            grpHoiGiangFilter.Controls.Add(cboNamHocHoiGiang);
            grpHoiGiangFilter.Controls.Add(lblNamHocHoiGiang);
            grpHoiGiangFilter.Dock = DockStyle.Top;
            grpHoiGiangFilter.Location = new Point(3, 4);
            grpHoiGiangFilter.Margin = new Padding(3, 4, 3, 4);
            grpHoiGiangFilter.Name = "grpHoiGiangFilter";
            grpHoiGiangFilter.Padding = new Padding(3, 4, 3, 4);
            grpHoiGiangFilter.Size = new Size(1357, 80);
            grpHoiGiangFilter.TabIndex = 0;
            grpHoiGiangFilter.TabStop = false;
            grpHoiGiangFilter.Text = "Lọc theo năm học";
            // 
            // btnExportHoiGiang
            // 
            btnExportHoiGiang.Anchor = AnchorStyles.Right;
            btnExportHoiGiang.Location = new Point(1159, 29);
            btnExportHoiGiang.Margin = new Padding(3, 4, 3, 4);
            btnExportHoiGiang.Name = "btnExportHoiGiang";
            btnExportHoiGiang.Size = new Size(86, 33);
            btnExportHoiGiang.TabIndex = 3;
            btnExportHoiGiang.Text = "Xuất CSV";
            btnExportHoiGiang.UseVisualStyleBackColor = true;
            // 
            // btnThongKeHoiGiang
            // 
            btnThongKeHoiGiang.Anchor = AnchorStyles.Right;
            btnThongKeHoiGiang.Location = new Point(1251, 29);
            btnThongKeHoiGiang.Margin = new Padding(3, 4, 3, 4);
            btnThongKeHoiGiang.Name = "btnThongKeHoiGiang";
            btnThongKeHoiGiang.Size = new Size(86, 33);
            btnThongKeHoiGiang.TabIndex = 2;
            btnThongKeHoiGiang.Text = "Thống kê";
            btnThongKeHoiGiang.UseVisualStyleBackColor = true;
            // 
            // cboNamHocHoiGiang
            // 
            cboNamHocHoiGiang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNamHocHoiGiang.FormattingEnabled = true;
            cboNamHocHoiGiang.Location = new Point(103, 31);
            cboNamHocHoiGiang.Margin = new Padding(3, 4, 3, 4);
            cboNamHocHoiGiang.Name = "cboNamHocHoiGiang";
            cboNamHocHoiGiang.Size = new Size(228, 28);
            cboNamHocHoiGiang.TabIndex = 1;
            // 
            // lblNamHocHoiGiang
            // 
            lblNamHocHoiGiang.AutoSize = true;
            lblNamHocHoiGiang.Location = new Point(23, 35);
            lblNamHocHoiGiang.Name = "lblNamHocHoiGiang";
            lblNamHocHoiGiang.Size = new Size(72, 20);
            lblNamHocHoiGiang.TabIndex = 0;
            lblNamHocHoiGiang.Text = "Năm học:";
            // 
            // tabTiLe
            // 
            tabTiLe.Controls.Add(dgvTiLeThamGia);
            tabTiLe.Controls.Add(grpTiLeFilter);
            tabTiLe.Location = new Point(4, 29);
            tabTiLe.Margin = new Padding(3, 4, 3, 4);
            tabTiLe.Name = "tabTiLe";
            tabTiLe.Padding = new Padding(3, 4, 3, 4);
            tabTiLe.Size = new Size(1363, 780);
            tabTiLe.TabIndex = 3;
            tabTiLe.Text = "Tỉ lệ tham gia";
            tabTiLe.UseVisualStyleBackColor = true;
            // 
            // dgvTiLeThamGia
            // 
            dgvTiLeThamGia.AllowUserToAddRows = false;
            dgvTiLeThamGia.AllowUserToDeleteRows = false;
            dgvTiLeThamGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTiLeThamGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTiLeThamGia.Dock = DockStyle.Fill;
            dgvTiLeThamGia.Location = new Point(3, 84);
            dgvTiLeThamGia.Margin = new Padding(3, 4, 3, 4);
            dgvTiLeThamGia.MultiSelect = false;
            dgvTiLeThamGia.Name = "dgvTiLeThamGia";
            dgvTiLeThamGia.ReadOnly = true;
            dgvTiLeThamGia.RowHeadersWidth = 51;
            dgvTiLeThamGia.RowTemplate.Height = 25;
            dgvTiLeThamGia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTiLeThamGia.Size = new Size(1357, 692);
            dgvTiLeThamGia.TabIndex = 1;
            // 
            // grpTiLeFilter
            // 
            grpTiLeFilter.Controls.Add(btnExportTiLe);
            grpTiLeFilter.Controls.Add(btnThongKeTiLe);
            grpTiLeFilter.Controls.Add(cboNamHocTiLe);
            grpTiLeFilter.Controls.Add(lblNamHocTiLe);
            grpTiLeFilter.Dock = DockStyle.Top;
            grpTiLeFilter.Location = new Point(3, 4);
            grpTiLeFilter.Margin = new Padding(3, 4, 3, 4);
            grpTiLeFilter.Name = "grpTiLeFilter";
            grpTiLeFilter.Padding = new Padding(3, 4, 3, 4);
            grpTiLeFilter.Size = new Size(1357, 80);
            grpTiLeFilter.TabIndex = 0;
            grpTiLeFilter.TabStop = false;
            grpTiLeFilter.Text = "Lọc theo năm học";
            // 
            // btnExportTiLe
            // 
            btnExportTiLe.Anchor = AnchorStyles.Right;
            btnExportTiLe.Location = new Point(1159, 29);
            btnExportTiLe.Margin = new Padding(3, 4, 3, 4);
            btnExportTiLe.Name = "btnExportTiLe";
            btnExportTiLe.Size = new Size(86, 33);
            btnExportTiLe.TabIndex = 3;
            btnExportTiLe.Text = "Xuất CSV";
            btnExportTiLe.UseVisualStyleBackColor = true;
            // 
            // btnThongKeTiLe
            // 
            btnThongKeTiLe.Anchor = AnchorStyles.Right;
            btnThongKeTiLe.Location = new Point(1251, 29);
            btnThongKeTiLe.Margin = new Padding(3, 4, 3, 4);
            btnThongKeTiLe.Name = "btnThongKeTiLe";
            btnThongKeTiLe.Size = new Size(86, 33);
            btnThongKeTiLe.TabIndex = 2;
            btnThongKeTiLe.Text = "Thống kê";
            btnThongKeTiLe.UseVisualStyleBackColor = true;
            // 
            // cboNamHocTiLe
            // 
            cboNamHocTiLe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNamHocTiLe.FormattingEnabled = true;
            cboNamHocTiLe.Location = new Point(103, 31);
            cboNamHocTiLe.Margin = new Padding(3, 4, 3, 4);
            cboNamHocTiLe.Name = "cboNamHocTiLe";
            cboNamHocTiLe.Size = new Size(228, 28);
            cboNamHocTiLe.TabIndex = 1;
            // 
            // lblNamHocTiLe
            // 
            lblNamHocTiLe.AutoSize = true;
            lblNamHocTiLe.Location = new Point(23, 35);
            lblNamHocTiLe.Name = "lblNamHocTiLe";
            lblNamHocTiLe.Size = new Size(72, 20);
            lblNamHocTiLe.TabIndex = 0;
            lblNamHocTiLe.Text = "Năm học:";
            // 
            // frmThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 867);
            Controls.Add(tabControl1);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê / báo cáo";
            Load += frmThongKe_Load_1;
            tabControl1.ResumeLayout(false);
            tabKhoa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGiaiTheoKhoa).EndInit();
            grpKhoaFilter.ResumeLayout(false);
            grpKhoaFilter.PerformLayout();
            tabHoiDong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoiDong).EndInit();
            grpHoiDongFilter.ResumeLayout(false);
            grpHoiDongFilter.PerformLayout();
            tabHoiGiang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoiGiangThongKe).EndInit();
            grpHoiGiangFilter.ResumeLayout(false);
            grpHoiGiangFilter.PerformLayout();
            tabTiLe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTiLeThamGia).EndInit();
            grpTiLeFilter.ResumeLayout(false);
            grpTiLeFilter.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKhoa;
        private System.Windows.Forms.DataGridView dgvGiaiTheoKhoa;
        private System.Windows.Forms.GroupBox grpKhoaFilter;
        private System.Windows.Forms.Button btnExportKhoa;
        private System.Windows.Forms.Button btnThongKeKhoa;
        private System.Windows.Forms.ComboBox cboNamHocKhoa;
        private System.Windows.Forms.Label lblNamHocKhoa;
        private System.Windows.Forms.TabPage tabHoiDong;
        private System.Windows.Forms.DataGridView dgvHoiDong;
        private System.Windows.Forms.GroupBox grpHoiDongFilter;
        private System.Windows.Forms.Button btnExportHoiDong;
        private System.Windows.Forms.Button btnThongKeHoiDong;
        private System.Windows.Forms.ComboBox cboNamHocHoiDong;
        private System.Windows.Forms.Label lblNamHocHoiDong;
        private System.Windows.Forms.TabPage tabHoiGiang;
        private System.Windows.Forms.DataGridView dgvHoiGiangThongKe;
        private System.Windows.Forms.GroupBox grpHoiGiangFilter;
        private System.Windows.Forms.Button btnExportHoiGiang;
        private System.Windows.Forms.Button btnThongKeHoiGiang;
        private System.Windows.Forms.ComboBox cboNamHocHoiGiang;
        private System.Windows.Forms.Label lblNamHocHoiGiang;
        private System.Windows.Forms.TabPage tabTiLe;
        private System.Windows.Forms.DataGridView dgvTiLeThamGia;
        private System.Windows.Forms.GroupBox grpTiLeFilter;
        private System.Windows.Forms.Button btnExportTiLe;
        private System.Windows.Forms.Button btnThongKeTiLe;
        private System.Windows.Forms.ComboBox cboNamHocTiLe;
        private System.Windows.Forms.Label lblNamHocTiLe;
    }
}
