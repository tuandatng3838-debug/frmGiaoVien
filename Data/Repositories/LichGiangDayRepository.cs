using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using frmGiaoVien.Models;
using frmGiaoVien.Services;
using Microsoft.Data.SqlClient;

namespace frmGiaoVien.Data.Repositories;

public class LichGiangDayRepository
{
    private const string BaseQuery = @"
SELECT lich.Id,
       lich.NamHoc,
       lich.TenLop,
       lich.TenMon,
       lich.GiangVienId,
       gv.HoTen AS GiangVienTen,
       lich.Buoi,
        lich.NgayHoc,
       lich.PhongHoc,
       lich.SoTiet,
       lich.SoSinhVien,
       lich.CreatedAt
FROM LichGiangDay lich
JOIN GiaoVien gv ON lich.GiangVienId = gv.Id"; // ASSUMPTION: bảng GiaoVien có Id

    public async Task<IEnumerable<LichGiangDay>> GetAsync(string? namHoc, string? giangVien, string? buoi, string? tenLop, string? tenMon)
    {
        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        var filters = new List<string>();
        if (!string.IsNullOrWhiteSpace(namHoc))
            filters.Add("lich.NamHoc = @NamHoc");
        if (!string.IsNullOrWhiteSpace(giangVien))
            filters.Add("(gv.HoTen LIKE CONCAT('%', @GiangVien, '%'))");
        if (!string.IsNullOrWhiteSpace(buoi))
            filters.Add("lich.Buoi = @Buoi");
        if (!string.IsNullOrWhiteSpace(tenLop))
            filters.Add("lich.TenLop LIKE CONCAT('%', @TenLop, '%')");
        if (!string.IsNullOrWhiteSpace(tenMon))
            filters.Add("lich.TenMon LIKE CONCAT('%', @TenMon, '%')");

        string sql = BaseQuery;
        if (filters.Any())
            sql += " WHERE " + string.Join(" AND ", filters);
        sql += " ORDER BY lich.NgayHoc DESC";

        return await conn.QueryAsync<LichGiangDay>(sql, new
        {
            NamHoc = namHoc,
            GiangVien = giangVien,
            Buoi = buoi,
            TenLop = tenLop,
            TenMon = tenMon
        });
    }

    public async Task<IEnumerable<LichGiangDay>> GetByGiangVienAsync(int giangVienId, string? namHoc)
    {
        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        const string sql = BaseQuery + @"
 WHERE lich.GiangVienId = @GiangVienId
   AND (@NamHoc IS NULL OR lich.NamHoc = @NamHoc)
 ORDER BY lich.NgayHoc, lich.Buoi";
        return await conn.QueryAsync<LichGiangDay>(sql, new { GiangVienId = giangVienId, NamHoc = namHoc });
    }

    public async Task<OperationResult<bool>> HasConflictAsync(int giangVienId, string buoi, System.DateTime ngayHoc, int? excludeId = null)
    {
        const string sql = @"
SELECT COUNT(1)
FROM LichGiangDay
WHERE GiangVienId = @GiangVienId
  AND NgayHoc = @NgayHoc
  AND Buoi = @Buoi
  AND (@ExcludeId IS NULL OR Id <> @ExcludeId)";
        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        var count = await conn.ExecuteScalarAsync<int>(sql, new
        {
            GiangVienId = giangVienId,
            NgayHoc = ngayHoc,
            Buoi = buoi,
            ExcludeId = excludeId
        });
        return OperationResult<bool>.Ok(count > 0);
    }

    public async Task<OperationResult<int>> CreateAsync(LichGiangDay model)
    {
        const string sql = @"
INSERT INTO LichGiangDay
    (NamHoc, TenLop, TenMon, GiangVienId, Buoi, NgayHoc, PhongHoc, SoTiet, SoSinhVien, CreatedAt)
VALUES
    (@NamHoc, @TenLop, @TenMon, @GiangVienId, @Buoi, @NgayHoc, @PhongHoc, @SoTiet, @SoSinhVien, SYSUTCDATETIME());
SELECT CAST(SCOPE_IDENTITY() as int);";
        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        try
        {
            var id = await conn.ExecuteScalarAsync<int>(sql, model);
            return OperationResult<int>.Ok(id);
        }
        catch (SqlException ex)
        {
            return OperationResult<int>.Fail("Không thể lưu lịch giảng dạy: " + ex.Message);
        }
    }

    public async Task<OperationResult<bool>> UpdateAsync(LichGiangDay model)
    {
        const string sql = @"
UPDATE LichGiangDay
SET NamHoc = @NamHoc,
    TenLop = @TenLop,
    TenMon = @TenMon,
    GiangVienId = @GiangVienId,
    Buoi = @Buoi,
    NgayHoc = @NgayHoc,
    PhongHoc = @PhongHoc,
    SoTiet = @SoTiet,
    SoSinhVien = @SoSinhVien
WHERE Id = @Id";
        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        try
        {
            await conn.ExecuteAsync(sql, model);
            return OperationResult<bool>.Ok(true);
        }
        catch (SqlException ex)
        {
            return OperationResult<bool>.Fail("Không thể cập nhật lịch giảng dạy: " + ex.Message);
        }
    }

    public async Task<OperationResult<bool>> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM LichGiangDay WHERE Id = @Id";
        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        try
        {
            await conn.ExecuteAsync(sql, new { Id = id });
            return OperationResult<bool>.Ok(true);
        }
        catch (SqlException ex)
        {
            return OperationResult<bool>.Fail("Không thể xóa lịch giảng dạy: " + ex.Message);
        }
    }
}
