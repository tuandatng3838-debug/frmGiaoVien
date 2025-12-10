using System;
using System.Collections.Generic;
using System.Data;
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

public partial class frmSangKien : KryptonForm
{
    private readonly SangKienRepository _repository = new();
    private readonly GiangVienRepository _giangVienRepository = new();
    private readonly BindingSource _bindingSource = new();

    private KryptonComboBox cboNamHoc = null!;
    private KryptonTextBox txtGiangVien = null!;
    private KryptonTextBox txtLinhVuc = null!;
    private KryptonButton btnTim = null!;
    private KryptonButton btnLamMoi = null!;
    private KryptonButton btnThem = null!;
    private KryptonButton btnSua = null!;
    private KryptonButton btnXoa = null!;
    private KryptonButton btnExport = null!;
    private KryptonDataGridView dgvSangKien = null!;
    private KryptonLabel lblRows = null!;

    public frmSangKien()
    {
        InitializeComponent();
        dgvSangKien.AutoGenerateColumns = false;
        dgvSangKien.DataSource = _bindingSource;
    }

    private async void frmSangKien_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var rows = await _repository.GetAsync(
            cboNamHoc.Text,
            txtGiangVien.Text,
            txtLinhVuc.Text);
        _bindingSource.DataSource = rows.ToList();
        lblRows.Text = $"Tổng { _bindingSource.Count } bản ghi";
    }

    private async void btnTim_Click(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        txtGiangVien.Clear();
        txtLinhVuc.Clear();
        cboNamHoc.SelectedIndex = -1;
        await LoadDataAsync();
    }

    private async void btnThem_Click(object sender, EventArgs e)
    {
        var dlg = new dlgSangKien(_giangVienRepository);
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            var result = await _repository.CreateAsync(dlg.Model);
            if (!result.Success)
            {
                MessageBox.Show( result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await LoadDataAsync();
        }
    }

    private SangKien? CurrentRow => _bindingSource.Current as SangKien;

    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (CurrentRow == null)
        {
            MessageBox.Show( "Chọn 1 sáng kiến trước.", "Thông báo");
            return;
        }
        var editModel = CurrentRow;
        var dlg = new dlgSangKien(_giangVienRepository, editModel);
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            var result = await _repository.UpdateAsync(dlg.Model);
            if (!result.Success)
            {
                MessageBox.Show( result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await LoadDataAsync();
        }
    }

    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (CurrentRow == null)
        {
            MessageBox.Show( "Chọn 1 sáng kiến trước.", "Thông báo");
            return;
        }
        var confirm = MessageBox.Show(
            this,
            $"Bạn có chắc muốn xóa sáng kiến \"{CurrentRow.Ten}\"?",
            "Xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        var result = await _repository.DeleteAsync(CurrentRow.Id);
        if (!result.Success)
        {
            MessageBox.Show( result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        await LoadDataAsync();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Count == 0)
        {
            MessageBox.Show( "Không có dữ liệu để xuất.", "Thông báo");
            return;
        }

        using SaveFileDialog dlg = new()
        {
            Filter = "CSV (*.csv)|*.csv",
            FileName = $"sangkien_{DateTime.Now:yyyyMMddHHmmss}.csv"
        };

        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        var sb = new StringBuilder();
        sb.AppendLine("Ten,GiangVien,Loai,TuCach,LinhVuc,NamHoc,XepLoai");
        foreach (SangKien row in _bindingSource.List)
        {
            sb.AppendLine(string.Join(",",
                Csv(row.Ten),
                Csv(row.GiangVienTen),
                Csv(row.Loai),
                Csv(row.TuCach),
                Csv(row.LinhVuc),
                Csv(row.NamHoc),
                Csv(row.XepLoai)));
        }
        File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
        MessageBox.Show( "Đã xuất CSV.", "Thông báo");
    }

    private static string Csv(string? value) =>
        $"\"{(value ?? string.Empty).Replace("\"", "\"\"")}\"";

    private void InitializeComponent()
    {
        Text = "Quản lý sáng kiến";
        Width = 1100;
        Height = 700;
        StartPosition = FormStartPosition.CenterScreen;

        var container = new KryptonPanel { Dock = DockStyle.Fill, Padding = new Padding(10) };
        Controls.Add(container);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3
        };
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        container.Controls.Add(layout);

        var filterPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true
        };
        layout.Controls.Add(filterPanel, 0, 0);

        cboNamHoc = new KryptonComboBox { Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
        cboNamHoc.Items.AddRange(new object[]
        {
            "2023-2024", "2024-2025", "2025-2026"
        });
        filterPanel.Controls.Add(new KryptonLabel { Text = "Năm học", Margin = new Padding(0, 7, 5, 0) });
        filterPanel.Controls.Add(cboNamHoc);

        txtGiangVien = new KryptonTextBox { Width = 200 };
        filterPanel.Controls.Add(new KryptonLabel { Text = "Giảng viên", Margin = new Padding(15, 7, 5, 0) });
        filterPanel.Controls.Add(txtGiangVien);

        txtLinhVuc = new KryptonTextBox { Width = 180 };
        filterPanel.Controls.Add(new KryptonLabel { Text = "Lĩnh vực", Margin = new Padding(15, 7, 5, 0) });
        filterPanel.Controls.Add(txtLinhVuc);

        btnTim = new KryptonButton { Text = "Tìm", Width = 80, Margin = new Padding(15, 3, 0, 3) };
        btnTim.Click += btnTim_Click;
        btnLamMoi = new KryptonButton { Text = "Làm mới", Width = 100, Margin = new Padding(5, 3, 0, 3) };
        btnLamMoi.Click += btnLamMoi_Click;
        filterPanel.Controls.Add(btnTim);
        filterPanel.Controls.Add(btnLamMoi);

        var gridPanel = new Panel { Dock = DockStyle.Fill };
        layout.Controls.Add(gridPanel, 0, 1);

        dgvSangKien = new KryptonDataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false
        };

        dgvSangKien.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(SangKien.Ten),
            HeaderText = "Tên sáng kiến"
        });
        dgvSangKien.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(SangKien.GiangVienTen),
            HeaderText = "Giảng viên"
        });
        dgvSangKien.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(SangKien.Loai),
            HeaderText = "Loại"
        });
        dgvSangKien.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(SangKien.LinhVuc),
            HeaderText = "Lĩnh vực"
        });
        dgvSangKien.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(SangKien.NamHoc),
            HeaderText = "Năm học"
        });
        dgvSangKien.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(SangKien.XepLoai),
            HeaderText = "Xếp loại"
        });
        gridPanel.Controls.Add(dgvSangKien);

        var footer = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            AutoSize = true,
            WrapContents = false
        };
        layout.Controls.Add(footer, 0, 2);

        btnThem = new KryptonButton { Text = "Thêm", Width = 90 };
        btnThem.Click += btnThem_Click;
        btnSua = new KryptonButton { Text = "Sửa", Width = 90 };
        btnSua.Click += btnSua_Click;
        btnXoa = new KryptonButton { Text = "Xóa", Width = 90 };
        btnXoa.Click += btnXoa_Click;
        btnExport = new KryptonButton { Text = "Xuất CSV", Width = 120 };
        btnExport.Click += btnExport_Click;
        lblRows = new KryptonLabel { Text = "Tổng 0 bản ghi", Margin = new Padding(15, 7, 0, 0) };

        footer.Controls.Add(btnThem);
        footer.Controls.Add(btnSua);
        footer.Controls.Add(btnXoa);
        footer.Controls.Add(btnExport);
        footer.Controls.Add(lblRows);

        Load += frmSangKien_Load;
    }
}
