using System;

namespace frmGiaoVien.Models;

public class LichGiangDay
{
    public int Id { get; set; }
    public string NamHoc { get; set; } = string.Empty;
    public string TenLop { get; set; } = string.Empty;
    public string TenMon { get; set; } = string.Empty;
    public int GiangVienId { get; set; }
    public string GiangVienTen { get; set; } = string.Empty;
    public string Buoi { get; set; } = string.Empty;
    public DateTime NgayHoc { get; set; }
    public string PhongHoc { get; set; } = string.Empty;
    public int SoTiet { get; set; }
    public int SoSinhVien { get; set; }
    public DateTime CreatedAt { get; set; }
}
