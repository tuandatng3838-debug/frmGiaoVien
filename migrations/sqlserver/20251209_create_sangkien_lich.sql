IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'SangKien')
BEGIN
    CREATE TABLE dbo.SangKien
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Ten NVARCHAR(255) NOT NULL,
        GiangVienId INT NOT NULL,
        TuCach NVARCHAR(100) NOT NULL,
        Loai NVARCHAR(100) NOT NULL,
        LinhVuc NVARCHAR(255) NULL,
        NamHoc NVARCHAR(20) NULL,
        ThoiGianThucHien NVARCHAR(255) NULL,
        DiaDiem NVARCHAR(255) NULL,
        XepLoai NVARCHAR(50) NULL,
        GhiChu NVARCHAR(MAX) NULL,
        CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_SangKien_CreatedAt DEFAULT SYSUTCDATETIME()
    );

    ALTER TABLE dbo.SangKien
    ADD CONSTRAINT FK_SangKien_GiaoVien
        FOREIGN KEY (GiangVienId) REFERENCES dbo.GiaoVien(Id);
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'LichGiangDay')
BEGIN
    CREATE TABLE dbo.LichGiangDay
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        NamHoc NVARCHAR(20) NOT NULL,
        TenLop NVARCHAR(200) NOT NULL,
        TenMon NVARCHAR(200) NOT NULL,
        GiangVienId INT NOT NULL,
        Buoi NVARCHAR(20) NOT NULL,
        NgayHoc DATE NOT NULL,
        PhongHoc NVARCHAR(100) NULL,
        SoTiet INT NOT NULL,
        SoSinhVien INT NOT NULL,
        CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_LichGiangDay_CreatedAt DEFAULT SYSUTCDATETIME()
    );

    ALTER TABLE dbo.LichGiangDay
    ADD CONSTRAINT FK_LichGiangDay_GiaoVien
        FOREIGN KEY (GiangVienId) REFERENCES dbo.GiaoVien(Id);
END
GO
