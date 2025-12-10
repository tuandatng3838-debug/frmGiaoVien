using System.Threading.Tasks;
using System.Windows.Forms;
using frmGiaoVien.Data.Repositories;
using frmGiaoVien.Models;
using Krypton.Toolkit;

namespace frmGiaoVien;

public class frmLichTheoGiangVien : KryptonForm
{
    private readonly LichGiangDayRepository _repository = new();
    private readonly GiangVienRepository _giangVienRepository = new();
    private KryptonComboBox cboGiangVien = null!;
    private KryptonComboBox cboNamHoc = null!;
    private KryptonDataGridView dgv = null!;

    public frmLichTheoGiangVien()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Text = "Lịch giảng dạy theo giảng viên";
        Width = 900;
        Height = 600;
        StartPosition = FormStartPosition.CenterScreen;

        var container = new KryptonPanel { Dock = DockStyle.Fill, Padding = new Padding(10) };
        Controls.Add(container);

        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2 };
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        container.Controls.Add(layout);

        var filter = new FlowLayoutPanel { AutoSize = true, Dock = DockStyle.Fill };
        layout.Controls.Add(filter, 0, 0);

        cboGiangVien = new KryptonComboBox { Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
        filter.Controls.Add(new KryptonLabel { Text = "Giảng viên", Margin = new Padding(0, 7, 5, 0) });
        filter.Controls.Add(cboGiangVien);

        cboNamHoc = new KryptonComboBox { Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
        cboNamHoc.Items.AddRange(new[] { "2023-2024", "2024-2025", "2025-2026" });
        filter.Controls.Add(new KryptonLabel { Text = "Năm học", Margin = new Padding(15, 7, 5, 0) });
        filter.Controls.Add(cboNamHoc);

        var btnTim = new KryptonButton { Text = "Tải lịch", Width = 100, Margin = new Padding(15, 3, 0, 3) };
        btnTim.Click += async (_, _) => await LoadDataAsync();
        filter.Controls.Add(btnTim);

        dgv = new KryptonDataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true
        };
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.NgayHoc), HeaderText = "Ngày", DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.Buoi), HeaderText = "Buổi" });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.TenLop), HeaderText = "Tên lớp" });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.TenMon), HeaderText = "Tên môn" });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.PhongHoc), HeaderText = "Phòng" });
        dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(LichGiangDay.SoTiet), HeaderText = "Số tiết" });
        layout.Controls.Add(dgv, 0, 1);

        Load += frmLichTheoGiangVien_Load;
    }

    private async void frmLichTheoGiangVien_Load(object? sender, System.EventArgs e)
    {
        await LoadGiangVienAsync();
    }

    private async Task LoadGiangVienAsync()
    {
        var list = await _giangVienRepository.SearchAsync(string.Empty);
        cboGiangVien.Items.Clear();
        foreach (var gv in list)
        {
            cboGiangVien.Items.Add(new KryptonListItem($"{gv.HoTen} (#{gv.Id})") { Tag = gv.Id });
        }
    }

    private async Task LoadDataAsync()
    {
        if (cboGiangVien.SelectedItem is not KryptonListItem selected)
        {
            MessageBox.Show( "Chọn giảng viên.", "Thông báo");
            return;
        }

        var rows = await _repository.GetByGiangVienAsync((int)(selected.Tag ?? 0), cboNamHoc.Text);
        dgv.DataSource = rows;
    }
}
