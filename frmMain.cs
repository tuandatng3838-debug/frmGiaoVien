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
            mnuHoiGiang.Click += (s, e) => OpenChildForm(new frmHoiGiang());
            mnuKetQua.Click += (s, e) => OpenChildForm(new frmKetQuaHoiGiang());
            mnuThongKeTongHop.Click += (s, e) => OpenChildForm(new frmThongKe());
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
