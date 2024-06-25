IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_TAREFAS] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] varchar(200) NOT NULL,
    [Descricao] varchar(200) NOT NULL,
    [Status] varchar(200) NOT NULL,
    [Prioridade] varchar(200) NOT NULL,
    [TempoEstimado] decimal(18,2) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataConclusao] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_TAREFAS] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_USURARIO] (
    [Id] int NOT NULL IDENTITY,
    [Email] varchar(200) NOT NULL,
    [Senha] varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_USURARIO] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataConclusao', N'DataCriacao', N'Descricao', N'Prioridade', N'Status', N'TempoEstimado', N'Titulo') AND [object_id] = OBJECT_ID(N'[TB_TAREFAS]'))
    SET IDENTITY_INSERT [TB_TAREFAS] ON;
INSERT INTO [TB_TAREFAS] ([Id], [DataConclusao], [DataCriacao], [Descricao], [Prioridade], [Status], [TempoEstimado], [Titulo])
VALUES (1, '0001-01-01T00:00:00.0000000', '0001-01-01T00:00:00.0000000', 'Realizar atividade de DS', 'Alta', 'Concluído', 8.0, 'Atividade'),
(2, '0001-01-01T00:00:00.0000000', '0001-01-01T00:00:00.0000000', 'Terminar o TCC', 'Alta', 'Em Andamento', 12.0, 'Trabalho'),
(3, '0001-01-01T00:00:00.0000000', '0001-01-01T00:00:00.0000000', 'Fazer a manutenção doméstica', 'Baixa', 'Em Atraso', 9.0, 'Arrumar Coisas'),
(4, '0001-01-01T00:00:00.0000000', '0001-01-01T00:00:00.0000000', 'Organizar tabela pessoal', 'Baixa', 'Em Andamento', 1.0, 'Organizar'),
(5, '0001-01-01T00:00:00.0000000', '0001-01-01T00:00:00.0000000', 'Fazer a separação dos materiais', 'Média', 'Concluído', 2.0, 'Separar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataConclusao', N'DataCriacao', N'Descricao', N'Prioridade', N'Status', N'TempoEstimado', N'Titulo') AND [object_id] = OBJECT_ID(N'[TB_TAREFAS]'))
    SET IDENTITY_INSERT [TB_TAREFAS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240430180250_InitialCreate', N'8.0.4');
GO

COMMIT;
GO

