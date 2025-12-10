using System;
using System.Windows.Forms;

namespace frmGiaoVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            mnuThoat.Click += (s, e) =>
            {
                if (MessageBox.Show("Thoát chương trình?", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            };

            mnuGiaoVien.Click += (s, e) => OpenChildForm(new frmGiaoVien());
            mnuSangKien.Click += (s, e) => OpenChildForm(new frmSangKien());
            mnuHoiGiang.Click += (s, e) => OpenChildForm(new frmHoiGiang());
            mnuKetQua.Click += (s, e) => OpenChildForm(new frmKetQuaHoiGiang());
            mnuLichGiangDay.Click += (s, e) => OpenChildForm(new frmLichGiangDay());
            mnuLichTheoGiangVien.Click += (s, e) => OpenChildForm(new frmLichTheoGiangVien());
            mnuThongKeTongHop.Click += (s, e) => OpenChildForm(new frmThongKeTongHopMoi());
            mnuThongKeMoRong.Click += (s, e) => OpenChildForm(new frmThongKe());
            mnuThongKeKetHop.Click += (s, e) => OpenChildForm(new frmThongKeGV());
        }

        private void OpenChildForm(Form frm)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == frm.GetType())
                {
                    f.Activate();
                    return;
                }
            }

            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            lblStatus.Text = "Đang làm việc với: " + frm.Text;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
