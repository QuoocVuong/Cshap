ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT FK__Accounts__UserID__5AEE82B9;
ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT FK__Accounts__RoleID__5BE2A6F2;
ALTER TABLE [dbo].[Role_Permissions] DROP CONSTRAINT FK__Role_Perm__RoleID__5CD6CB2B;
ALTER TABLE [dbo].[Role_Permissions] DROP CONSTRAINT FK__Role_Perm__Permis__5DCAEF64;
DROP TABLE IF EXISTS [dbo].[Role_Permissions];
DROP TABLE IF EXISTS [dbo].[Permissions];
DROP TABLE IF EXISTS [dbo].[Roles];
DROP TABLE IF EXISTS [dbo].[Accounts];
DROP TABLE IF EXISTS [dbo].[Users];
ALTER TABLE [dbo].[MonHoc_GiangVien] DROP CONSTRAINT FK__MonHoc_Gi__ID_Gian__628FA481;
DROP TABLE IF EXISTS [dbo].[GiangVien];
DROP TABLE IF EXISTS [dbo].[SinhVien];
ALTER TABLE [dbo].[SinhVien] DROP CONSTRAINT FK__SinhVien__ID_Lop__5EBF139D;
ALTER TABLE SinhVien
ALTER COLUMN UserID INT NOT NULL;