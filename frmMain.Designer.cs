using System.Windows.Forms;

namespace frmGiaoVien
{
    partial class frmMain
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
            menuStrip1 = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuDanhMuc = new ToolStripMenuItem();
            mnuGiaoVien = new ToolStripMenuItem();
            mnuNghiepVu = new ToolStripMenuItem();
            mnuHoiGiang = new ToolStripMenuItem();
            mnuKetQua = new ToolStripMenuItem();
            mnuThongKe = new ToolStripMenuItem();
            mnuThongKeTongHop = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuDanhMuc, mnuNghiepVu, mnuThongKe });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1371, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(85, 24);
            mnuHeThong.Text = "Hệ thống";
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(130, 26);
            mnuThoat.Text = "Thoát";
            // 
            // mnuDanhMuc
            // 
            mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { mnuGiaoVien });
            mnuDanhMuc.Name = "mnuDanhMuc";
            mnuDanhMuc.Size = new Size(90, 24);
            mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuGiaoVien
            // 
            mnuGiaoVien.Name = "mnuGiaoVien";
            mnuGiaoVien.Size = new Size(154, 26);
            mnuGiaoVien.Text = "Giáo viên";
            // 
            // mnuNghiepVu
            // 
            mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] { mnuHoiGiang, mnuKetQua });
            mnuNghiepVu.Name = "mnuNghiepVu";
            mnuNghiepVu.Size = new Size(91, 24);
            mnuNghiepVu.Text = "Nghiệp vụ";
            // 
            // mnuHoiGiang
            // 
            mnuHoiGiang.Name = "mnuHoiGiang";
            mnuHoiGiang.Size = new Size(213, 26);
            mnuHoiGiang.Text = "Đăng ký hội giảng";
            // 
            // mnuKetQua
            // 
            mnuKetQua.Name = "mnuKetQua";
            mnuKetQua.Size = new Size(213, 26);
            mnuKetQua.Text = "Kết quả hội giảng";
            // 
            // mnuThongKe
            // 
            mnuThongKe.DropDownItems.AddRange(new ToolStripItem[] { mnuThongKeTongHop });
            mnuThongKe.Name = "mnuThongKe";
            mnuThongKe.Size = new Size(84, 24);
            mnuThongKe.Text = "Thống kê";
            // 
            // mnuThongKeTongHop
            // 
            mnuThongKeTongHop.Name = "mnuThongKeTongHop";
            mnuThongKeTongHop.Size = new Size(221, 26);
            mnuThongKeTongHop.Text = "Thống kê / báo cáo";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 907);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1371, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(134, 20);
            lblStatus.Text = "Sẵn sàng sử dụng...";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 933);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý hội giảng";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuGiaoVien;
        private ToolStripMenuItem mnuNghiepVu;
        private ToolStripMenuItem mnuHoiGiang;
        private ToolStripMenuItem mnuKetQua;
        private ToolStripMenuItem mnuThongKe;
        private ToolStripMenuItem mnuThongKeTongHop;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}
