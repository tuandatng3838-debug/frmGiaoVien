using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using frmGiaoVien.Data;
using frmGiaoVien.Models;
using Microsoft.Data.SqlClient;

namespace frmGiaoVien.Services;

public class ThongKeService
{
    public async Task<IEnumerable<ThongKeItem>> TongTietTheoGiangVienAsync(string namHoc)
    {
        const string sql = @"
SELECT gv.Id,
       gv.HoTen AS Ten,
       COALESCE(SUM(ld.SoTiet), 0) AS SoLuong
FROM GiaoVien gv
LEFT JOIN LichGiangDay ld
       ON gv.Id = ld.GiangVienId
      AND ld.NamHoc = @NamHoc
GROUP BY gv.Id, gv.HoTen
ORDER BY SoLuong DESC"; // ASSUMPTION: bảng GiaoVien có Id, HoTen

        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        return await conn.QueryAsync<ThongKeItem>(sql, new { NamHoc = namHoc });
    }

    public async Task<IEnumerable<ThongKeItem>> TongTietTheoKhoaAsync(string namHoc)
    {
        const string sql = @"
SELECT ISNULL(k.Id, 0) AS Id,
       ISNULL(k.TenKhoa, N'Chưa rõ khoa') AS Ten,
       COALESCE(SUM(ld.SoTiet), 0) AS SoLuong
FROM GiaoVien gv
LEFT JOIN Khoa k ON gv.KhoaId = k.Id -- ASSUMPTION: bảng Khoa tồn tại cùng khóa ngoại KhoaId
LEFT JOIN LichGiangDay ld
       ON gv.Id = ld.GiangVienId
      AND ld.NamHoc = @NamHoc
GROUP BY k.Id, k.TenKhoa
ORDER BY SoLuong DESC";

        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        return await conn.QueryAsync<ThongKeItem>(sql, new { NamHoc = namHoc });
    }

    public async Task<IEnumerable<ThongKeItem>> SoSangKienTheoGiangVienAsync()
    {
        const string sql = @"
SELECT gv.Id,
       gv.HoTen AS Ten,
       COALESCE(COUNT(sk.Id), 0) AS SoLuong
FROM GiaoVien gv
LEFT JOIN SangKien sk ON gv.Id = sk.GiangVienId
GROUP BY gv.Id, gv.HoTen
ORDER BY SoLuong DESC";

        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        return await conn.QueryAsync<ThongKeItem>(sql);
    }
}
