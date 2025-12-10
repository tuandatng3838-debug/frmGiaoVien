using System;

namespace frmGiaoVien.Models;

public class SangKien
{
    public int Id { get; set; }
    public string Ten { get; set; } = string.Empty;
    public int GiangVienId { get; set; }
    public string GiangVienTen { get; set; } = string.Empty;
    public string TuCach { get; set; } = string.Empty;
    public string Loai { get; set; } = string.Empty;
    public string LinhVuc { get; set; } = string.Empty;
    public string NamHoc { get; set; } = string.Empty;
    public string ThoiGianThucHien { get; set; } = string.Empty;
    public string DiaDiem { get; set; } = string.Empty;
    public string XepLoai { get; set; } = string.Empty;
    public string GhiChu { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
