IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'sa')
CREATE USER [sa] FOR LOGIN [BUILTIN\Administrators]
