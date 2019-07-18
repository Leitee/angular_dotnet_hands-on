USE [master]
GO

CREATE DATABASE [PrismaDemo]

IF OBJECT_ID(N'[EFConfig].[Migrations]') IS NULL
BEGIN
    IF SCHEMA_ID(N'EFConfig') IS NULL EXEC(N'CREATE SCHEMA [EFConfig];');
    CREATE TABLE [EFConfig].[Migrations] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK_Migrations] PRIMARY KEY ([MigrationId])
    );
END;

GO

USE [PrismaDemo]
GO


IF SCHEMA_ID(N'Prisma') IS NULL EXEC(N'CREATE SCHEMA [Prisma];');

GO

CREATE TABLE [Prisma].[Marcas] (
    [Id] int NOT NULL IDENTITY,
    [Codigo] nvarchar(max) NULL,
    [Nombre] nvarchar(max) NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Prisma].[ZonasDePrecio] (
    [Id] int NOT NULL IDENTITY,
    [Codigo] nvarchar(max) NULL,
    [Nombre] nvarchar(max) NULL,
    CONSTRAINT [PK_ZonasDePrecio] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Prisma].[Competidores] (
    [Id] int NOT NULL IDENTITY,
    [Codigo] nvarchar(max) NULL,
    [Nombre] nvarchar(max) NULL,
    [Calle] nvarchar(max) NULL,
    [Latitud] decimal(18,2) NOT NULL,
    [Longitud] decimal(18,2) NOT NULL,
    [Marcador] bit NOT NULL,
    [Observar] bit NOT NULL,
    [MarcaId] int NOT NULL,
    [ZonaDePrecioId] int NOT NULL,
    CONSTRAINT [PK_Competidores] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Competidores_Marcas_MarcaId] FOREIGN KEY ([MarcaId]) REFERENCES [Prisma].[Marcas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Competidores_ZonasDePrecio_ZonaDePrecioId] FOREIGN KEY ([ZonaDePrecioId]) REFERENCES [Prisma].[ZonasDePrecio] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Codigo', N'Nombre') AND [object_id] = OBJECT_ID(N'[Prisma].[Marcas]'))
    SET IDENTITY_INSERT [Prisma].[Marcas] ON;
INSERT INTO [Prisma].[Marcas] ([Id], [Codigo], [Nombre])
VALUES (1, N'marca_codigo1', N'marca_nombre1'),
(2, N'marca_codigo2', N'marca_nombre2'),
(3, N'marca_codigo3', N'marca_nombre3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Codigo', N'Nombre') AND [object_id] = OBJECT_ID(N'[Prisma].[Marcas]'))
    SET IDENTITY_INSERT [Prisma].[Marcas] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Codigo', N'Nombre') AND [object_id] = OBJECT_ID(N'[Prisma].[ZonasDePrecio]'))
    SET IDENTITY_INSERT [Prisma].[ZonasDePrecio] ON;
INSERT INTO [Prisma].[ZonasDePrecio] ([Id], [Codigo], [Nombre])
VALUES (1, N'zona_codigo1', N'zona_nombre1'),
(2, N'zona_codigo2', N'zona_nombre2'),
(3, N'zona_codigo3', N'zona_nombre3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Codigo', N'Nombre') AND [object_id] = OBJECT_ID(N'[Prisma].[ZonasDePrecio]'))
    SET IDENTITY_INSERT [Prisma].[ZonasDePrecio] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Calle', N'Codigo', N'Latitud', N'Longitud', N'MarcaId', N'Marcador', N'Nombre', N'Observar', N'ZonaDePrecioId') AND [object_id] = OBJECT_ID(N'[Prisma].[Competidores]'))
    SET IDENTITY_INSERT [Prisma].[Competidores] ON;
INSERT INTO [Prisma].[Competidores] ([Id], [Calle], [Codigo], [Latitud], [Longitud], [MarcaId], [Marcador], [Nombre], [Observar], [ZonaDePrecioId])
VALUES (1, N'calle1', N'codigo1', 0.0, 0.0, 1, 0, N'nombre1', 0, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Calle', N'Codigo', N'Latitud', N'Longitud', N'MarcaId', N'Marcador', N'Nombre', N'Observar', N'ZonaDePrecioId') AND [object_id] = OBJECT_ID(N'[Prisma].[Competidores]'))
    SET IDENTITY_INSERT [Prisma].[Competidores] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Calle', N'Codigo', N'Latitud', N'Longitud', N'MarcaId', N'Marcador', N'Nombre', N'Observar', N'ZonaDePrecioId') AND [object_id] = OBJECT_ID(N'[Prisma].[Competidores]'))
    SET IDENTITY_INSERT [Prisma].[Competidores] ON;
INSERT INTO [Prisma].[Competidores] ([Id], [Calle], [Codigo], [Latitud], [Longitud], [MarcaId], [Marcador], [Nombre], [Observar], [ZonaDePrecioId])
VALUES (2, N'calle2', N'codigo2', 0.0, 0.0, 2, 0, N'nombre2', 0, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Calle', N'Codigo', N'Latitud', N'Longitud', N'MarcaId', N'Marcador', N'Nombre', N'Observar', N'ZonaDePrecioId') AND [object_id] = OBJECT_ID(N'[Prisma].[Competidores]'))
    SET IDENTITY_INSERT [Prisma].[Competidores] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Calle', N'Codigo', N'Latitud', N'Longitud', N'MarcaId', N'Marcador', N'Nombre', N'Observar', N'ZonaDePrecioId') AND [object_id] = OBJECT_ID(N'[Prisma].[Competidores]'))
    SET IDENTITY_INSERT [Prisma].[Competidores] ON;
INSERT INTO [Prisma].[Competidores] ([Id], [Calle], [Codigo], [Latitud], [Longitud], [MarcaId], [Marcador], [Nombre], [Observar], [ZonaDePrecioId])
VALUES (3, N'calle3', N'codigo3', 0.0, 0.0, 3, 0, N'nombre3', 0, 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Calle', N'Codigo', N'Latitud', N'Longitud', N'MarcaId', N'Marcador', N'Nombre', N'Observar', N'ZonaDePrecioId') AND [object_id] = OBJECT_ID(N'[Prisma].[Competidores]'))
    SET IDENTITY_INSERT [Prisma].[Competidores] OFF;

GO

CREATE INDEX [IX_Competidores_MarcaId] ON [Prisma].[Competidores] ([MarcaId]);

GO

CREATE INDEX [IX_Competidores_ZonaDePrecioId] ON [Prisma].[Competidores] ([ZonaDePrecioId]);

GO

INSERT INTO [EFConfig].[Migrations] ([MigrationId], [ProductVersion])
VALUES (N'20190717024516_initialMigration', N'2.2.6-servicing-10079');

GO

