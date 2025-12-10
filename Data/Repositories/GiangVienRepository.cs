using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using frmGiaoVien.Models;
using Microsoft.Data.SqlClient;

namespace frmGiaoVien.Data.Repositories;

public class GiangVienRepository
{
    public async Task<IEnumerable<GiangVienLookup>> SearchAsync(string keyword)
    {
        const string sql = @"
SELECT TOP 20 Id, HoTen
FROM GiaoVien
WHERE (@Keyword = '' OR HoTen LIKE CONCAT('%', @Keyword, '%') OR MaSoCB LIKE CONCAT('%', @Keyword, '%'))
ORDER BY HoTen";

        using SqlConnection conn = DatabaseManager.CreateConnection();
        await conn.OpenAsync();
        return await conn.QueryAsync<GiangVienLookup>(sql, new { Keyword = keyword ?? string.Empty });
    }
}
