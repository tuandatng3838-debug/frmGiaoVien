-- Seed demo data for SangKien and LichGiangDay
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'SangKien')
BEGIN
    INSERT INTO SangKien (Ten, GiangVienId, TuCach, Loai, LinhVuc, NamHoc, ThoiGianThucHien, DiaDiem, XepLoai, GhiChu)
    SELECT TOP 1
        N'Ứng dụng AI trong giảng dạy',
        gv.Id,
        N'Tác giả',
        N'Sáng kiến',
        N'Công nghệ thông tin',
        N'2024-2025',
        N'6 tháng',
        N'TP. Hồ Chí Minh',
        N'Xuất sắc',
        N'Minh họa seed'
    FROM GiaoVien gv
    WHERE NOT EXISTS (SELECT 1 FROM SangKien);
END
GO

IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'LichGiangDay')
BEGIN
    INSERT INTO LichGiangDay (NamHoc, TenLop, TenMon, GiangVienId, Buoi, NgayHoc, PhongHoc, SoTiet, SoSinhVien)
    SELECT TOP 1
        N'2024-2025',
        N'CNTT K45',
        N'Lập trình .NET',
        gv.Id,
        N'Sáng',
        CAST(GETDATE() AS DATE),
        N'C201',
        3,
        45
    FROM GiaoVien gv
    WHERE NOT EXISTS (SELECT 1 FROM LichGiangDay);
END
GO
