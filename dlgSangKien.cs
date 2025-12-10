using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmGiaoVien.Data.Repositories;
using frmGiaoVien.Models;
using Krypton.Toolkit;

namespace frmGiaoVien;

public class dlgSangKien : KryptonForm
{
    private readonly GiangVienRepository _giangVienRepository;
    private readonly SangKien? _original;

    private KryptonTextBox txtTen = null!;
    private KryptonComboBox cboGiangVien = null!;
    private KryptonComboBox cboTuCach = null!;
    private KryptonComboBox cboLoai = null!;
    private KryptonTextBox txtLinhVuc = null!;
    private KryptonComboBox cboNamHoc = null!;
    private KryptonTextBox txtThoiGian = null!;
    private KryptonTextBox txtDiaDiem = null!;
    private KryptonComboBox cboXepLoai = null!;
    private KryptonTextBox txtGhiChu = null!;
    private KryptonButton btnLuu = null!;
    private KryptonButton btnDong = null!;
    private KryptonButton btnReloadGV = null!;

    public SangKien Model { get; private set; } = new();

    public dlgSangKien(GiangVienRepository giangVienRepository, SangKien? existing = null)
    {
        _giangVienRepository = giangVienRepository;
        _original = existing;
        InitializeComponent();
        if (existing != null)
        {
            Model = new SangKien
            {
                Id = existing.Id,
                Ten = existing.Ten,
                GiangVienId = existing.GiangVienId,
                TuCach = existing.TuCach,
                Loai = existing.Loai,
                LinhVuc = existing.LinhVuc,
                NamHoc = existing.NamHoc,
                ThoiGianThucHien = existing.ThoiGianThucHien,
                DiaDiem = existing.DiaDiem,
                XepLoai = existing.XepLoai,
                GhiChu = existing.GhiChu
            };
        }
    }

    private async void dlgSangKien_Load(object sender, EventArgs e)
    {
        await LoadGiangVienAsync(string.Empty);
        cboTuCach.Items.AddRange(new[] { "Tác giả", "Đồng tác giả" });
        cboLoai.Items.AddRange(new[] { "Sáng kiến", "Cải tiến" });
        cboXepLoai.Items.AddRange(new[] { "Khá", "Tốt", "Xuất sắc" });
        cboNamHoc.Items.AddRange(new[] { "2023-2024", "2024-2025", "2025-2026" });

        if (_original != null)
        {
            txtTen.Text = _original.Ten;
            SetComboSelection(cboGiangVien, _original.GiangVienId);
            cboTuCach.SelectedItem = _original.TuCach;
            cboLoai.SelectedItem = _original.Loai;
            txtLinhVuc.Text = _original.LinhVuc;
            cboNamHoc.SelectedItem = _original.NamHoc;
            txtThoiGian.Text = _original.ThoiGianThucHien;
            txtDiaDiem.Text = _original.DiaDiem;
            cboXepLoai.SelectedItem = _original.XepLoai;
            txtGhiChu.Text = _original.GhiChu;
        }
    }

    private void SetComboSelection(KryptonComboBox combo, int value)
    {
        foreach (var item in combo.Items.OfType<KryptonListItem>())
        {
            if (item.Tag is int id && id == value)
            {
                combo.SelectedItem = item;
                break;
            }
        }
    }

    private async Task LoadGiangVienAsync(string keyword)
    {
        var list = await _giangVienRepository.SearchAsync(keyword);
        var selectedId = (_original?.GiangVienId) ?? Model.GiangVienId;

        cboGiangVien.Items.Clear();
        foreach (var gv in list)
        {
            var item = new KryptonListItem($"{gv.HoTen} (# {gv.Id})")
            {
                Tag = gv.Id
            };
            cboGiangVien.Items.Add(item);
            if (gv.Id == selectedId)
            {
                cboGiangVien.SelectedItem = item;
            }
        }
    }

    private void InitializeComponent()
    {
        Text = "Sáng kiến";
        Width = 600;
        Height = 600;
        StartPosition = FormStartPosition.CenterParent;

        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 12,
            Padding = new Padding(10),
            AutoSize = true
        };

        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

        Controls.Add(panel);

        int row = 0;
        void AddRow(string label, Control control)
        {
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.Controls.Add(new KryptonLabel { Text = label, Margin = new Padding(3, 7, 3, 3) }, 0, row);
            control.Dock = DockStyle.Fill;
            panel.Controls.Add(control, 1, row);
            row++;
        }

        txtTen = new KryptonTextBox();
        AddRow("Tên sáng kiến", txtTen);

        cboGiangVien = new KryptonComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        var gvPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true };
        gvPanel.Controls.Add(cboGiangVien);
        var txtSearchGV = new KryptonTextBox { Width = 120 };
        btnReloadGV = new KryptonButton { Text = "Tải", Width = 60 };
        btnReloadGV.Click += async (_, _) => await LoadGiangVienAsync(txtSearchGV.Text);
        gvPanel.Controls.Add(txtSearchGV);
        gvPanel.Controls.Add(btnReloadGV);
        AddRow("Giảng viên", gvPanel);

        cboTuCach = new KryptonComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Tư cách", cboTuCach);

        cboLoai = new KryptonComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Loại", cboLoai);

        txtLinhVuc = new KryptonTextBox();
        AddRow("Lĩnh vực", txtLinhVuc);

        cboNamHoc = new KryptonComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Năm học", cboNamHoc);

        txtThoiGian = new KryptonTextBox();
        AddRow("Thời gian thực hiện", txtThoiGian);

        txtDiaDiem = new KryptonTextBox();
        AddRow("Địa điểm", txtDiaDiem);

        cboXepLoai = new KryptonComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        AddRow("Xếp loại", cboXepLoai);

        txtGhiChu = new KryptonTextBox { Multiline = true, Height = 80 };
        AddRow("Ghi chú", txtGhiChu);

        panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        var buttonPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
        btnLuu = new KryptonButton { Text = "Lưu", Width = 90 };
        btnDong = new KryptonButton { Text = "Đóng", Width = 90 };
        btnLuu.Click += BtnLuu_Click;
        btnDong.Click += (_, _) => DialogResult = DialogResult.Cancel;
        buttonPanel.Controls.Add(btnLuu);
        buttonPanel.Controls.Add(btnDong);
        panel.Controls.Add(buttonPanel, 0, row);
        panel.SetColumnSpan(buttonPanel, 2);

        Load += dlgSangKien_Load;
    }

    private void BtnLuu_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTen.Text))
        {
            MessageBox.Show( "Tên sáng kiến không được để trống.", "Lỗi");
            return;
        }

        if (cboGiangVien.SelectedItem is not KryptonListItem selectedGv)
        {
            MessageBox.Show( "Chọn giảng viên.", "Lỗi");
            return;
        }

        Model.Id = _original?.Id ?? 0;
        Model.Ten = txtTen.Text.Trim();
        Model.GiangVienId = (int)(selectedGv.Tag ?? 0);
        Model.TuCach = cboTuCach.Text;
        Model.Loai = cboLoai.Text;
        Model.LinhVuc = txtLinhVuc.Text.Trim();
        Model.NamHoc = cboNamHoc.Text;
        Model.ThoiGianThucHien = txtThoiGian.Text.Trim();
        Model.DiaDiem = txtDiaDiem.Text.Trim();
        Model.XepLoai = cboXepLoai.Text;
        Model.GhiChu = txtGhiChu.Text.Trim();

        DialogResult = DialogResult.OK;
    }
}
