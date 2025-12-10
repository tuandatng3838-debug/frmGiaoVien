using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmGiaoVien.Models;
using frmGiaoVien.Services;
using Krypton.Toolkit;

namespace frmGiaoVien;

public partial class frmThongKeGV : KryptonForm
{
    private readonly ThongKeService _service = new();
    private KryptonComboBox cboNamHocGv = null!;
    private KryptonComboBox cboNamHocKhoa = null!;
    private KryptonDataGridView dgvTheoGV = null!;
    private KryptonDataGridView dgvTheoKhoa = null!;
    private KryptonDataGridView dgvSangKien = null!;

    public frmThongKeGV()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Text = "Thống kê giảng viên";
        Width = 1000;
        Height = 700;
        StartPosition = FormStartPosition.CenterScreen;

        var container = new KryptonPanel { Dock = DockStyle.Fill };
        Controls.Add(container);

        var tabs = new TabControl { Dock = DockStyle.Fill };
        container.Controls.Add(tabs);

        tabs.TabPages.Add(CreatePage("Theo giảng viên", BuildTheoGiangVien));
        tabs.TabPages.Add(CreatePage("Theo khoa", BuildTheoKhoa));
        tabs.TabPages.Add(CreatePage("Sáng kiến", BuildSangKien));
    }

    private TabPage CreatePage(string title, Action<TabPage> builder)
    {
        var page = new TabPage(title);
        builder(page);
        return page;
    }

    private void BuildTheoGiangVien(TabPage page)
    {
        var layout = CreateBaseLayout(out var filterPanel, out var grid);
        page.Controls.Add(layout);
        cboNamHocGv = new KryptonComboBox { Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
        cboNamHocGv.Items.AddRange(new[] { "2023-2024", "2024-2025", "2025-2026" });
        filterPanel.Controls.Add(new KryptonLabel { Text = "Năm học", Margin = new Padding(0, 7, 5, 0) });
        filterPanel.Controls.Add(cboNamHocGv);
        var btnXem = new KryptonButton { Text = "Xem", Width = 80, Margin = new Padding(15, 3, 0, 3) };
        btnXem.Click += async (_, _) => await LoadTheoGiangVienAsync();
        var btnExport = new KryptonButton { Text = "Xuất CSV", Width = 120, Margin = new Padding(5, 3, 0, 3) };
        btnExport.Click += (_, _) => ExportGrid(dgvTheoGV, "thongke_giangvien");
        filterPanel.Controls.Add(btnXem);
        filterPanel.Controls.Add(btnExport);

        dgvTheoGV = grid;
        dgvTheoGV.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ThongKeItem.Ten), HeaderText = "Giảng viên" });
        dgvTheoGV.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ThongKeItem.SoLuong), HeaderText = "Tổng số tiết", DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
    }

    private void BuildTheoKhoa(TabPage page)
    {
        var layout = CreateBaseLayout(out var filterPanel, out var grid);
        page.Controls.Add(layout);
        cboNamHocKhoa = new KryptonComboBox { Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
        cboNamHocKhoa.Items.AddRange(new[] { "2023-2024", "2024-2025", "2025-2026" });
        filterPanel.Controls.Add(new KryptonLabel { Text = "Năm học", Margin = new Padding(0, 7, 5, 0) });
        filterPanel.Controls.Add(cboNamHocKhoa);
        var btnXem = new KryptonButton { Text = "Xem", Width = 80, Margin = new Padding(15, 3, 0, 3) };
        btnXem.Click += async (_, _) => await LoadTheoKhoaAsync();
        var btnExport = new KryptonButton { Text = "Xuất CSV", Width = 120, Margin = new Padding(5, 3, 0, 3) };
        btnExport.Click += (_, _) => ExportGrid(dgvTheoKhoa, "thongke_khoa");
        filterPanel.Controls.Add(btnXem);
        filterPanel.Controls.Add(btnExport);

        dgvTheoKhoa = grid;
        dgvTheoKhoa.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ThongKeItem.Ten), HeaderText = "Khoa" });
        dgvTheoKhoa.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ThongKeItem.SoLuong), HeaderText = "Tổng số tiết", DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
    }

    private void BuildSangKien(TabPage page)
    {
        var layout = CreateBaseLayout(out var filterPanel, out var grid);
        page.Controls.Add(layout);
        var btnXem = new KryptonButton { Text = "Tải dữ liệu", Width = 120, Margin = new Padding(0, 3, 0, 3) };
        btnXem.Click += async (_, _) => await LoadSangKienAsync();
        var btnExport = new KryptonButton { Text = "Xuất CSV", Width = 120, Margin = new Padding(5, 3, 0, 3) };
        btnExport.Click += (_, _) => ExportGrid(dgvSangKien, "thongke_sangkien");
        filterPanel.Controls.Add(btnXem);
        filterPanel.Controls.Add(btnExport);

        dgvSangKien = grid;
        dgvSangKien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ThongKeItem.Ten), HeaderText = "Giảng viên" });
        dgvSangKien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ThongKeItem.SoLuong), HeaderText = "Số sáng kiến", DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight } });
    }

    private TableLayoutPanel CreateBaseLayout(out FlowLayoutPanel filterPanel, out KryptonDataGridView grid)
    {
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        filterPanel = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Fill, WrapContents = true, Padding = new Padding(10, 5, 0, 5) };
        layout.Controls.Add(filterPanel, 0, 0);

        grid = new KryptonDataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        layout.Controls.Add(grid, 0, 1);
        return layout;
    }

    private async Task LoadTheoGiangVienAsync()
    {
        var namHoc = cboNamHocGv.Text;
        if (string.IsNullOrWhiteSpace(namHoc))
        {
            MessageBox.Show( "Chọn năm học.", "Thông báo");
            return;
        }

        dgvTheoGV.DataSource = (await _service.TongTietTheoGiangVienAsync(namHoc)).ToList();
    }

    private async Task LoadTheoKhoaAsync()
    {
        var namHoc = cboNamHocKhoa.Text;
        if (string.IsNullOrWhiteSpace(namHoc))
        {
            MessageBox.Show( "Chọn năm học.", "Thông báo");
            return;
        }

        dgvTheoKhoa.DataSource = (await _service.TongTietTheoKhoaAsync(namHoc)).ToList();
    }

    private async Task LoadSangKienAsync()
    {
        dgvSangKien.DataSource = (await _service.SoSangKienTheoGiangVienAsync()).ToList();
    }

    private void ExportGrid(DataGridView grid, string prefix)
    {
        if (grid.DataSource == null || grid.Rows.Count == 0)
        {
            MessageBox.Show( "Không có dữ liệu để xuất.", "Thông báo");
            return;
        }

        using SaveFileDialog dlg = new()
        {
            Filter = "CSV (*.csv)|*.csv",
            FileName = $"{prefix}_{DateTime.Now:yyyyMMddHHmmss}.csv"
        };
        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        var sb = new StringBuilder();
        var headers = grid.Columns.Cast<DataGridViewColumn>().Select(c => c.HeaderText);
        sb.AppendLine(string.Join(",", headers.Select(Csv)));
        foreach (DataGridViewRow row in grid.Rows)
        {
            if (row.IsNewRow) continue;
            var values = row.Cells.Cast<DataGridViewCell>().Select(c => Csv(Convert.ToString(c.Value)));
            sb.AppendLine(string.Join(",", values));
        }
        File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
        MessageBox.Show( "Đã xuất CSV.", "Thông báo");
    }

    private static string Csv(string? value) => $"\"{(value ?? string.Empty).Replace("\"", "\"\"")}\"";
}
