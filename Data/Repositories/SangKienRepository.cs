using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using frmGiaoVien.Models;
using frmGiaoVien.Services;
using Microsoft.Data.SqlClient;

namespace frmGiaoVien.Data.Repositories;

public class SangKienRepository
{
    private const string BaseQuery = @"
SELECT sk.Id,
       sk.Ten,
       sk.GiangVienId,
       gv.HoTen AS GiangVienTen,
       sk.TuCach,
       sk.Loai,
       sk.LinhVuc,
       sk.NamHoc,
       sk.ThoiGianThucHien,
       sk.DiaDiem,
       sk.XepLoai,
       sk.GhiChu,
       sk.CreatedAt
FROM SangKien sk
JOIN GiaoVien gv ON sk.GiangVienId = gv.Id"; // ASSUMPTION: bảng GiaoVien có cột Id, HoTen

    public async Task<IEnumerable<SangKien>> GetAsync(string? namHoc, string? giangVien, string? linhVuc)
    {
        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();

        var filters = new List<string>();
        if (!string.IsNullOrWhiteSpace(namHoc))
            filters.Add("sk.NamHoc = @NamHoc");
        if (!string.IsNullOrWhiteSpace(giangVien))
            filters.Add("(gv.HoTen LIKE CONCAT('%', @GiangVien, '%'))");
        if (!string.IsNullOrWhiteSpace(linhVuc))
            filters.Add("sk.LinhVuc LIKE CONCAT('%', @LinhVuc, '%')");

        string sql = BaseQuery;
        if (filters.Any())
            sql += " WHERE " + string.Join(" AND ", filters);

        sql += " ORDER BY sk.CreatedAt DESC";

        return await conn.QueryAsync<SangKien>(sql, new
        {
            NamHoc = namHoc,
            GiangVien = giangVien,
            LinhVuc = linhVuc
        });
    }

    public async Task<OperationResult<int>> CreateAsync(SangKien model)
    {
        const string insertSql = @"
INSERT INTO SangKien
    (Ten, GiangVienId, TuCach, Loai, LinhVuc, NamHoc, ThoiGianThucHien,
     DiaDiem, XepLoai, GhiChu, CreatedAt)
VALUES
    (@Ten, @GiangVienId, @TuCach, @Loai, @LinhVuc, @NamHoc, @ThoiGianThucHien,
     @DiaDiem, @XepLoai, @GhiChu, SYSUTCDATETIME());
SELECT CAST(SCOPE_IDENTITY() as int);";

        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        try
        {
            var id = await conn.ExecuteScalarAsync<int>(insertSql, model);
            return OperationResult<int>.Ok(id);
        }
        catch (SqlException ex)
        {
            return OperationResult<int>.Fail("Không thể lưu sáng kiến: " + ex.Message);
        }
    }

    public async Task<OperationResult<bool>> UpdateAsync(SangKien model)
    {
        const string updateSql = @"
UPDATE SangKien
SET Ten = @Ten,
    GiangVienId = @GiangVienId,
    TuCach = @TuCach,
    Loai = @Loai,
    LinhVuc = @LinhVuc,
    NamHoc = @NamHoc,
    ThoiGianThucHien = @ThoiGianThucHien,
    DiaDiem = @DiaDiem,
    XepLoai = @XepLoai,
    GhiChu = @GhiChu
WHERE Id = @Id";

        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        try
        {
            await conn.ExecuteAsync(updateSql, model);
            return OperationResult<bool>.Ok(true);
        }
        catch (SqlException ex)
        {
            return OperationResult<bool>.Fail("Không thể cập nhật sáng kiến: " + ex.Message);
        }
    }

    public async Task<OperationResult<bool>> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM SangKien WHERE Id = @Id";
        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        try
        {
            await conn.ExecuteAsync(sql, new { Id = id });
            return OperationResult<bool>.Ok(true);
        }
        catch (SqlException ex)
        {
            return OperationResult<bool>.Fail("Không thể xóa sáng kiến: " + ex.Message);
        }
    }
}
