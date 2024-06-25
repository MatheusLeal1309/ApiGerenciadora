BEGIN TRANSACTION;
GO

EXEC sp_rename N'[TB_USURARIO].[Senha]', N'Username', N'COLUMN';
GO

ALTER TABLE [TB_USURARIO] ADD [DataAcesso] datetime2 NULL;
GO

ALTER TABLE [TB_USURARIO] ADD [Foto] varbinary(max) NULL;
GO

ALTER TABLE [TB_USURARIO] ADD [Latitude] float NULL;
GO

ALTER TABLE [TB_USURARIO] ADD [Longitude] float NULL;
GO

ALTER TABLE [TB_USURARIO] ADD [PasswordHash] varbinary(max) NULL;
GO

ALTER TABLE [TB_USURARIO] ADD [PasswordSalt] varbinary(max) NULL;
GO

ALTER TABLE [TB_USURARIO] ADD [Perfil] varchar(200) NOT NULL DEFAULT '';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240617172918_MigracaoUsuario', N'8.0.4');
GO

COMMIT;
GO

