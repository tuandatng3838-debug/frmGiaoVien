using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmGiaoVien.Data.Repositories;
using frmGiaoVien.Models;
using frmGiaoVien.Services;
using Krypton.Toolkit;

namespace frmGiaoVien;

public partial class frmLichGiangDay : KryptonForm
{
    private readonly LichGiangDayRepository _repository = new();
    private readonly GiangVienRepository _giangVienRepository = new();
    private readonly BindingSource _bindingSource = new();

    private KryptonComboBox cboNamHoc = null!;
    private KryptonTextBox txtGiangVien = null!;
    private KryptonComboBox cboBuoi = null!;
    private KryptonTextBox txtLop = null!;
    private KryptonTextBox txtMon = null!;
    private KryptonDataGridView dgvLich = null!;
    private KryptonLabel lblRows = null!;

    public frmLichGiangDay()
    {
        InitializeComponent();
        dgvLich.AutoGenerateColumns = false;
        dgvLich.DataSource = _bindingSource;
    }

    private async void frmLichGiangDay_Load(object? sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var rows = await _repository.GetAsync(
            cboNamHoc.Text,
            txtGiangVien.Text,
            cboBuoi.Text,
            txtLop.Text,
            txtMon.Text);
        _bindingSource.DataSource = rows.ToList();
        lblRows.Text = $"Tổng { _bindingSource.Count } lịch";
    }

    private async void btnTim_Click(object? sender, EventArgs e) => await LoadDataAsync();

    private async void btnLamMoi_Click(object? sender, EventArgs e)
    {
        cboNamHoc.SelectedIndex = -1;
        txtGiangVien.Clear();
        cboBuoi.SelectedIndex = -1;
        txtLop.Clear();
        txtMon.Clear();
        await LoadDataAsync();
    }

    private LichGiangDay? Current => _bindingSource.Current as LichGiangDay;

    private async void btnThem_Click(object? sender, EventArgs e)
    {
        var dlg = new dlgLichGiangDay(_giangVienRepository);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        var conflict = await _repository.HasConflictAsync(dlg.Model.GiangVienId, dlg.Model.Buoi, dlg.Model.NgayHoc, null);
        if (conflict.Data == true)
        {
            var confirm = MessageBox.Show(
                "Giảng viên đã có lịch trùng. Bạn vẫn muốn lưu?",
                "Cảnh báo: Trùng lịch",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
        }

        var result = await _repository.CreateAsync(dlg.Model);
        if (!result.Success)
        {
            MessageBox.Show( result.Message, "Lỗi");
            return;
        }
        await LoadDataAsync();
    }

    private async void btnSua_Click(object? sender, EventArgs e)
    {
        if (Current == null)
        {
            MessageBox.Show( "Chọn một lịch.", "Thông báo");
            return;
        }
        var dlg = new dlgLichGiangDay(_giangVienRepository, Current);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        var conflict = await _repository.HasConflictAsync(dlg.Model.GiangVienId, dlg.Model.Buoi, dlg.Model.NgayHoc, dlg.Model.Id);
        if (conflict.Data == true)
        {
            var confirm = MessageBox.Show(
                "Giảng viên đã có lịch trùng. Bạn vẫn muốn lưu?",
                "Cảnh báo: Trùng lịch",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
        }

        var result = await _repository.UpdateAsync(dlg.Model);
        if (!result.Success)
        {
            MessageBox.Show( result.Message, "Lỗi");
            return;
        }
        await LoadDataAsync();
    }

    private async void btnXoa_Click(object? sender, EventArgs e)
    {
        if (Current == null)
        {
            MessageBox.Show( "Chọn một lịch.", "Thông báo");
            return;
        }
        var confirm = MessageBox.Show( "Bạn có chắc muốn xóa lịch đã chọn?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;
        var result = await _repository.DeleteAsync(Current.Id);
        if (!result.Success)
        {
            MessageBox.Show( result.Message, "Lỗi");
            return;
        }
        await LoadDataAsync();
    }

    private void btnExport_Click(object? sender, EventArgs e)
    {
        if (_bindingSource.Count == 0)
        {
            MessageBox.Show( "Không có dữ liệu xuất CSV.", "Thông báo");
            return;
        }

        using SaveFileDialog dlg = new()
        {
            Filter = "CSV (*.csv)|*.csv",
            FileName = $"lichgiangday_{DateTime.Now:yyyyMMddHHmmss}.csv"
        };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        var sb = new StringBuilder();
        sb.AppendLine("NamHoc,TenLop,TenMon,GiangVien,Buoi,NgayHoc,PhongHoc,SoTiet,SoSinhVien");
        foreach (LichGiangDay row in _bindingSource.List)
        {
            sb.AppendLine(string.Join(",",
                Csv(row.NamHoc),
                Csv(row.TenLop),
                Csv(row.TenMon),
                Csv(row.GiangVienTen),
                Csv(row.Buoi),
                row.NgayHoc.ToString("dd/MM/yyyy"),
                Csv(row.PhongHoc),
                row.SoTiet,
                row.SoSinhVien));
        }
        File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
        MessageBox.Show( "Đã xuất CSV.", "Thông báo");
    }

    private static string Csv(string? value) =>
        $"\"{(value ?? string.Empty).Replace("\"", "\"\"")}\"";

    private void InitializeComponent()
    {
        Text = "Quản lý lịch giảng dạy";
        Width = 1200;
        Height = 720;
        StartPosition = FormStartPosition.CenterScreen;

        var container = new KryptonPanel { Dock = DockStyle.Fill, Padding = new Padding(10) };
        Controls.Add(container);

        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3 };
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        container.Controls.Add(layout);

        var filter = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Fill, WrapContents = true };
        layout.Controls.Add(filter, 0, 0);

        cboNamHoc = new KryptonComboBox { Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
        cboNamHoc.Items.AddRange(new[] { "2023-2024", "2024-2025", "2025-2026" });
        filter.Controls.Add(new KryptonLabel { Text = "Năm học", Margin = new Padding(0, 7, 5, 0) });
        filter.Controls.Add(cboNamHoc);

        txtGiangVien = new KryptonTextBox { Width = 180 };
        filter.Controls.Add(new KryptonLabel { Text = "Giảng viên", Margin = new Padding(15, 7, 5, 0) });
        filter.Controls.Add(txtGiangVien);

        cboBuoi = new KryptonComboBox { Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
        cboBuoi.Items.AddRange(new[] { "Sáng", "Chiều", "Tối" });
        filter.Controls.Add(new KryptonLabel { Text = "Buổi", Margin = new Padding(15, 7, 5, 0) });
        filter.Controls.Add(cboBuoi);

        txtLop = new KryptonTextBox { Width = 150 };
        filter.Controls.Add(new KryptonLabel { Text = "Tên lớp", Margin = new Padding(15, 7, 5, 0) });
        filter.Controls.Add(txtLop);

        txtMon = new KryptonTextBox { Width = 150 };
        filter.Controls.Add(new KryptonLabel { Text = "Tên môn", Margin = new Padding(15, 7, 5, 0) });
        filter.Controls.Add(txtMon);

        var btnTim = new KryptonButton { Text = "Tìm", Width = 80, Margin = new Padding(15, 3, 0, 3) };
        btnTim.Click += btnTim_Click;
        var btnLamMoi = new KryptonButton { Text = "Làm mới", Width = 100, Margin = new Padding(5, 3, 0, 3) };
        btnLamMoi.Click += btnLamMoi_Click;
        filter.Controls.Add(btnTim);
        filter.Controls.Add(btnLamMoi);

        dgvLich = new KryptonDataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false
        };

        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.NamHoc), HeaderText = "Năm học" });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.TenLop), HeaderText = "Tên lớp" });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.TenMon), HeaderText = "Tên môn" });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.GiangVienTen), HeaderText = "Giảng viên" });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.Buoi), HeaderText = "Buổi" });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.NgayHoc), HeaderText = "Ngày học", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.SoTiet), HeaderText = "Số tiết", DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
        dgvLich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.SoSinhVien), HeaderText = "Số SV", DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
        layout.Controls.Add(dgvLich, 0, 1);

        var footer = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
        layout.Controls.Add(footer, 0, 2);

        var btnThem = new KryptonButton { Text = "Thêm", Width = 90 };
        btnThem.Click += btnThem_Click;
        var btnSua = new KryptonButton { Text = "Sửa", Width = 90 };
        btnSua.Click += btnSua_Click;
        var btnXoa = new KryptonButton { Text = "Xóa", Width = 90 };
        btnXoa.Click += btnXoa_Click;
        var btnExport = new KryptonButton { Text = "Xuất CSV", Width = 120 };
        btnExport.Click += btnExport_Click;
        lblRows = new KryptonLabel { Text = "Tổng 0 lịch", Margin = new Padding(15, 7, 0, 0) };

        footer.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa, btnExport, lblRows });

        Load += frmLichGiangDay_Load;
    }
}
