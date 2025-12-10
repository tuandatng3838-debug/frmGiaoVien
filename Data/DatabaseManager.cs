using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace frmGiaoVien.Data;

public static class DatabaseManager
{
    private static readonly string? ExplicitConnection =
        ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
        ?? ConfigurationManager.ConnectionStrings["QLHoiGiang"]?.ConnectionString;

    private const string DefaultFallback =
        "Data Source=TUANDAT\\\\SQLEXPRESS;Initial Catalog=QLHoiGiang;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";

    public static SqlConnection CreateConnection()
    {
        var connString = string.IsNullOrWhiteSpace(ExplicitConnection)
            ? DefaultFallback
            : ExplicitConnection;
        return new SqlConnection(connString);
    }
}
