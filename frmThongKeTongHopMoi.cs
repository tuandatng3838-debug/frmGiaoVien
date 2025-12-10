using System;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace frmGiaoVien;

public class frmThongKeTongHopMoi : KryptonForm
{
    private readonly TabControl _tabControl;
    private readonly Panel _pnlThongKeCu;
    private readonly Panel _pnlThongKeMoRong;

    private frmThongKe? _frmThongKeCu;
    private frmThongKeGV? _frmThongKeMoRong;

    public frmThongKeTongHopMoi()
    {
        Text = "Trung tâm thống kê";
        Width = 1200;
        Height = 800;
        StartPosition = FormStartPosition.CenterScreen;

        _tabControl = new TabControl
        {
            Dock = DockStyle.Fill
        };
        _tabControl.SelectedIndexChanged += TabControlOnSelectedIndexChanged;

        _pnlThongKeCu = new Panel { Dock = DockStyle.Fill };
        _pnlThongKeMoRong = new Panel { Dock = DockStyle.Fill };

        var tabClassic = new TabPage("Thống kê / báo cáo");
        tabClassic.Controls.Add(_pnlThongKeCu);

        var tabExtended = new TabPage("Thống kê mở rộng");
        tabExtended.Controls.Add(_pnlThongKeMoRong);

        _tabControl.TabPages.Add(tabClassic);
        _tabControl.TabPages.Add(tabExtended);

        Controls.Add(_tabControl);

        EnsureClassicLoaded();
        EnsureExtendedLoaded();
    }

    private void TabControlOnSelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_tabControl.SelectedIndex == 0)
        {
            EnsureClassicLoaded();
        }
        else if (_tabControl.SelectedIndex == 1)
        {
            EnsureExtendedLoaded();
        }
    }

    private void EnsureClassicLoaded()
    {
        if (_frmThongKeCu != null) return;

        _frmThongKeCu = new frmThongKe
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill
        };

        _pnlThongKeCu.Controls.Clear();
        _pnlThongKeCu.Controls.Add(_frmThongKeCu);
        _frmThongKeCu.Show();
    }

    private void EnsureExtendedLoaded()
    {
        if (_frmThongKeMoRong != null) return;

        _frmThongKeMoRong = new frmThongKeGV
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None,
            Dock = DockStyle.Fill
        };

        _pnlThongKeMoRong.Controls.Clear();
        _pnlThongKeMoRong.Controls.Add(_frmThongKeMoRong);
        _frmThongKeMoRong.Show();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        _frmThongKeCu?.Dispose();
        _frmThongKeMoRong?.Dispose();
    }
}
