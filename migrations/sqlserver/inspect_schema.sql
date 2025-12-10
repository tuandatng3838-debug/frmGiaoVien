-- Inspect schema for QLHoiGiang database
-- Liệt kê bảng
SELECT TABLE_SCHEMA, TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_SCHEMA, TABLE_NAME;
GO

-- Liệt kê cột
SELECT TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH,
       IS_NULLABLE, COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS
ORDER BY TABLE_SCHEMA, TABLE_NAME, ORDINAL_POSITION;
GO

-- Foreign keys
SELECT fk.name AS FK_Name,
       schp.name + '.' + tp.name AS ParentTable,
       schr.name + '.' + tr.name AS ReferencedTable,
       cpa.name AS ParentColumn,
       cra.name AS ReferencedColumn
FROM sys.foreign_keys fk
JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
JOIN sys.tables tp ON fkc.parent_object_id = tp.object_id
JOIN sys.schemas schp ON tp.schema_id = schp.schema_id
JOIN sys.columns cpa ON cpa.object_id = tp.object_id AND cpa.column_id = fkc.parent_column_id
JOIN sys.tables tr ON fkc.referenced_object_id = tr.object_id
JOIN sys.schemas schr ON tr.schema_id = schr.schema_id
JOIN sys.columns cra ON cra.object_id = tr.object_id AND cra.column_id = fkc.referenced_column_id
ORDER BY fk.name;
GO

-- Top 50 rows per table (dynamic SQL)
DECLARE @sql NVARCHAR(MAX) = N'';
SELECT @sql = @sql + N'SELECT TOP 50 * FROM ' + QUOTENAME(TABLE_SCHEMA) + N'.' + QUOTENAME(TABLE_NAME) + N' ORDER BY 1;\nGO\n'
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_SCHEMA, TABLE_NAME;

PRINT @sql;
-- Sau khi chạy script, copy phần in ra và chạy thủ công nếu cần xem dữ liệu mẫu.
GO
