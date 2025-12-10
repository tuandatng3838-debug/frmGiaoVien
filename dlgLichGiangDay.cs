using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmGiaoVien.Data.Repositories;
using frmGiaoVien.Models;
using Krypton.Toolkit;

namespace frmGiaoVien;

public class dlgLichGiangDay : KryptonForm
{
    private readonly GiangVienRepository _giangVienRepository;
    private readonly LichGiangDay? _existing;

    private KryptonComboBox cboGiangVien = null!;
    private KryptonComboBox cboNamHoc = null!;
    private KryptonTextBox txtLop = null!;
    private KryptonTextBox txtMon = null!;
    private KryptonComboBox cboBuoi = null!;
    private KryptonDateTimePicker dtNgayHoc = null!;
    private KryptonTextBox txtPhongHoc = null!;
    private KryptonNumericUpDown numSoTiet = null!;
    private KryptonNumericUpDown numSoSinhVien = null!;

    public LichGiangDay Model { get; private set; } = new();

    public dlgLichGiangDay(GiangVienRepository giangVienRepository, LichGiangDay? existing = null)
    {
        _giangVienRepository = giangVienRepository;
        _existing = existing;
        InitializeComponent();
    }

    private async void dlgLichGiangDay_Load(object? sender, EventArgs e)
    {
        await LoadGiangVienAsync(string.Empty);
        if (_existing != null)
        {
            cboNamHoc.SelectedItem = _existing.NamHoc;
            txtLop.Text = _existing.TenLop;
            txtMon.Text = _existing.TenMon;
            cboBuoi.SelectedItem = _existing.Buoi;
            dtNgayHoc.Value = _existing.NgayHoc;
            txtPhongHoc.Text = _existing.PhongHoc;
            numSoTiet.Value = _existing.SoTiet;
            numSoSinhVien.Value = _existing.SoSinhVien;
            SelectGiangVien(_existing.GiangVienId);
        }
    }

    private async Task LoadGiangVienAsync(string keyword)
    {
        var list = await _giangVienRepository.SearchAsync(keyword);
        cboGiangVien.Items.Clear();
        foreach (var gv in list)
        {
            var item = new KryptonListItem($"{gv.HoTen} (#{gv.Id})") { Tag = gv.Id };
            cboGiangVien.Items.Add(item);
        }
        if (_existing != null)
        {
            SelectGiangVien(_existing.GiangVienId);
        }
    }

    private void SelectGiangVien(int id)
    {
        foreach (var item in cboGiangVien.Items.OfType<KryptonListItem>())
        {
            if ((int)(item.Tag ?? 0) == id)
            {
                cboGiangVien.SelectedItem = item;
                break;
            }
        }
    }

    private void InitializeComponent()
    {
        Text = "Lịch giảng dạy";
        Width = 550;
        Height = 520;
        StartPosition = FormStartPosition.CenterParent;

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            Padding = new Padding(10),
            AutoSize = true
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
        Controls.Add(layout);

        int row = 0;
        void AddRow(string label, Control control)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Controls.Add(new KryptonLabel { Text = label, Margin = new Padding(3, 7, 3, 3) }, 0, row);
            control.Dock = DockStyle.Fill;
            layout.Controls.Add(control, 1, row);
            row++;
        }

        cboGiangVien = new KryptonComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        var panelGV = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
        var txtSearch = new KryptonTextBox { Width = 120 };
        var btnSearch = new KryptonButton { Text = "Tải", Width = 60 };
        btnSearch.Click += async (_, _) => await LoadGiangVienAsync(txtSearch.Text);
        panelGV.Controls.Add(cboGiangVien);
        panelGV.Controls.Add(txtSearch);
        panelGV.Controls.Add(btnSearch);
        AddRow("Giảng viên", panelGV);

        cboNamHoc = new KryptonComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cboNamHoc.Items.AddRange(new[] { "2023-2024", "2024-2025", "2025-2026" });
        AddRow("Năm học", cboNamHoc);

        txtLop = new KryptonTextBox();
        AddRow("Tên lớp", txtLop);

        txtMon = new KryptonTextBox();
        AddRow("Tên môn", txtMon);

        cboBuoi = new KryptonComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cboBuoi.Items.AddRange(new[] { "Sáng", "Chiều", "Tối" });
        AddRow("Buổi", cboBuoi);

        dtNgayHoc = new KryptonDateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
        AddRow("Ngày học", dtNgayHoc);

        txtPhongHoc = new KryptonTextBox();
        AddRow("Phòng học", txtPhongHoc);

        numSoTiet = new KryptonNumericUpDown { Minimum = 1, Maximum = 12, Value = 3 };
        AddRow("Số tiết", numSoTiet);

        numSoSinhVien = new KryptonNumericUpDown { Minimum = 1, Maximum = 200, Value = 30 };
        AddRow("Số sinh viên", numSoSinhVien);

        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
        var btnLuu = new KryptonButton { Text = "Lưu", Width = 90 };
        var btnDong = new KryptonButton { Text = "Đóng", Width = 90 };
        btnLuu.Click += BtnLuu_Click;
        btnDong.Click += (_, _) => DialogResult = DialogResult.Cancel;
        buttons.Controls.Add(btnLuu);
        buttons.Controls.Add(btnDong);
        layout.Controls.Add(buttons, 0, row);
        layout.SetColumnSpan(buttons, 2);

        Load += dlgLichGiangDay_Load;
    }

    private void BtnLuu_Click(object? sender, EventArgs e)
    {
        if (cboGiangVien.SelectedItem is not KryptonListItem selected)
        {
            MessageBox.Show( "Chọn giảng viên.", "Lỗi");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtLop.Text) || string.IsNullOrWhiteSpace(txtMon.Text))
        {
            MessageBox.Show( "Tên lớp và tên môn không được trống.", "Lỗi");
            return;
        }

        Model.Id = _existing?.Id ?? 0;
        Model.GiangVienId = (int)(selected.Tag ?? 0);
        Model.NamHoc = cboNamHoc.Text;
        Model.TenLop = txtLop.Text.Trim();
        Model.TenMon = txtMon.Text.Trim();
        Model.Buoi = cboBuoi.Text;
        Model.NgayHoc = dtNgayHoc.Value.Date;
        Model.PhongHoc = txtPhongHoc.Text.Trim();
        Model.SoTiet = (int)numSoTiet.Value;
        Model.SoSinhVien = (int)numSoSinhVien.Value;

        DialogResult = DialogResult.OK;
    }
}
