USE pubs;
GO
IF OBJECT_ID('dbo.app_users','U') IS NULL
BEGIN
 CREATE TABLE dbo.app_users (
  user_id INT IDENTITY(1,1) PRIMARY KEY,
  username NVARCHAR(50) NOT NULL UNIQUE,
  password_hash VARBINARY(32) NOT NULL,
  active BIT NOT NULL DEFAULT(1)
 );
END;
GO
IF NOT EXISTS (SELECT 1 FROM dbo.app_users WHERE username=N'admin')
 INSERT INTO dbo.app_users(username,password_hash) VALUES(N'admin',HASHBYTES('SHA2_256',N'Admin123!'));
GO
