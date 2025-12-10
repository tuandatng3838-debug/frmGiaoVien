namespace frmGiaoVien.Models;

public class ThongKeItem
{
    public int Id { get; set; }
    public string Ten { get; set; } = string.Empty;
    public string? Khoa { get; set; }
    public int SoLuong { get; set; }
}
