
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/24/2019 23:28:54
-- Generated from EDMX file: D:\Вышка\II курс\Практика\TechnologicalPracticeApp\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EcolabelDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CompanyEcolabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EcolabelSet] DROP CONSTRAINT [FK_CompanyEcolabel];
GO
IF OBJECT_ID(N'[dbo].[FK_EcolabelCountry_Ecolabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Country_EcolabelSet] DROP CONSTRAINT [FK_EcolabelCountry_Ecolabel];
GO
IF OBJECT_ID(N'[dbo].[FK_EcolabelDemand_Ecolabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Demand_EcolabelSet] DROP CONSTRAINT [FK_EcolabelDemand_Ecolabel];
GO
IF OBJECT_ID(N'[dbo].[FK_EcolabelPersonalCabinet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonalCabinetSet] DROP CONSTRAINT [FK_EcolabelPersonalCabinet];
GO
IF OBJECT_ID(N'[dbo].[FK_EcolabelEcoType_Ecolabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EcoType_EcolabelSet] DROP CONSTRAINT [FK_EcolabelEcoType_Ecolabel];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryCountry_Ecolabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Country_EcolabelSet] DROP CONSTRAINT [FK_CountryCountry_Ecolabel];
GO
IF OBJECT_ID(N'[dbo].[FK_EcoTypeEcoType_Ecolabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EcoType_EcolabelSet] DROP CONSTRAINT [FK_EcoTypeEcoType_Ecolabel];
GO
IF OBJECT_ID(N'[dbo].[FK_DemandDemand_Ecolabel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Demand_EcolabelSet] DROP CONSTRAINT [FK_DemandDemand_Ecolabel];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPersonalCabinet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonalCabinetSet] DROP CONSTRAINT [FK_PersonPersonalCabinet];
GO
IF OBJECT_ID(N'[dbo].[FK_AccessLevelPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet] DROP CONSTRAINT [FK_AccessLevelPerson];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EcolabelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EcolabelSet];
GO
IF OBJECT_ID(N'[dbo].[CompanySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanySet];
GO
IF OBJECT_ID(N'[dbo].[CountrySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CountrySet];
GO
IF OBJECT_ID(N'[dbo].[Country_EcolabelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Country_EcolabelSet];
GO
IF OBJECT_ID(N'[dbo].[EcoTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EcoTypeSet];
GO
IF OBJECT_ID(N'[dbo].[EcoType_EcolabelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EcoType_EcolabelSet];
GO
IF OBJECT_ID(N'[dbo].[DemandSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DemandSet];
GO
IF OBJECT_ID(N'[dbo].[Demand_EcolabelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Demand_EcolabelSet];
GO
IF OBJECT_ID(N'[dbo].[PersonalCabinetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonalCabinetSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[AccessLevelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccessLevelSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EcolabelSet'
CREATE TABLE [dbo].[EcolabelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Image] varbinary(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CompanyID] int  NOT NULL
);
GO

-- Creating table 'CompanySet'
CREATE TABLE [dbo].[CompanySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CountrySet'
CREATE TABLE [dbo].[CountrySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Country_EcolabelSet'
CREATE TABLE [dbo].[Country_EcolabelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CountryID] int  NOT NULL,
    [EcolabelID] int  NOT NULL
);
GO

-- Creating table 'EcoTypeSet'
CREATE TABLE [dbo].[EcoTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EcoType_EcolabelSet'
CREATE TABLE [dbo].[EcoType_EcolabelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EcoTypeID] int  NOT NULL,
    [EcolabelID] int  NOT NULL
);
GO

-- Creating table 'DemandSet'
CREATE TABLE [dbo].[DemandSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rule] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Demand_EcolabelSet'
CREATE TABLE [dbo].[Demand_EcolabelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EcolabelID] int  NOT NULL,
    [DemandID] int  NOT NULL
);
GO

-- Creating table 'PersonalCabinetSet'
CREATE TABLE [dbo].[PersonalCabinetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mark] int  NOT NULL,
    [EcolabelID] int  NOT NULL,
    [PersonID] int  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [FatherName] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [EmailAddress] nvarchar(max)  NOT NULL,
    [AccessLevelID] int  NOT NULL
);
GO

-- Creating table 'AccessLevelSet'
CREATE TABLE [dbo].[AccessLevelSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EcolabelSet'
ALTER TABLE [dbo].[EcolabelSet]
ADD CONSTRAINT [PK_EcolabelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompanySet'
ALTER TABLE [dbo].[CompanySet]
ADD CONSTRAINT [PK_CompanySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CountrySet'
ALTER TABLE [dbo].[CountrySet]
ADD CONSTRAINT [PK_CountrySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Country_EcolabelSet'
ALTER TABLE [dbo].[Country_EcolabelSet]
ADD CONSTRAINT [PK_Country_EcolabelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EcoTypeSet'
ALTER TABLE [dbo].[EcoTypeSet]
ADD CONSTRAINT [PK_EcoTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EcoType_EcolabelSet'
ALTER TABLE [dbo].[EcoType_EcolabelSet]
ADD CONSTRAINT [PK_EcoType_EcolabelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DemandSet'
ALTER TABLE [dbo].[DemandSet]
ADD CONSTRAINT [PK_DemandSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Demand_EcolabelSet'
ALTER TABLE [dbo].[Demand_EcolabelSet]
ADD CONSTRAINT [PK_Demand_EcolabelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonalCabinetSet'
ALTER TABLE [dbo].[PersonalCabinetSet]
ADD CONSTRAINT [PK_PersonalCabinetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AccessLevelSet'
ALTER TABLE [dbo].[AccessLevelSet]
ADD CONSTRAINT [PK_AccessLevelSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CompanyID] in table 'EcolabelSet'
ALTER TABLE [dbo].[EcolabelSet]
ADD CONSTRAINT [FK_CompanyEcolabel]
    FOREIGN KEY ([CompanyID])
    REFERENCES [dbo].[CompanySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyEcolabel'
CREATE INDEX [IX_FK_CompanyEcolabel]
ON [dbo].[EcolabelSet]
    ([CompanyID]);
GO

-- Creating foreign key on [EcolabelID] in table 'Country_EcolabelSet'
ALTER TABLE [dbo].[Country_EcolabelSet]
ADD CONSTRAINT [FK_EcolabelCountry_Ecolabel]
    FOREIGN KEY ([EcolabelID])
    REFERENCES [dbo].[EcolabelSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EcolabelCountry_Ecolabel'
CREATE INDEX [IX_FK_EcolabelCountry_Ecolabel]
ON [dbo].[Country_EcolabelSet]
    ([EcolabelID]);
GO

-- Creating foreign key on [EcolabelID] in table 'Demand_EcolabelSet'
ALTER TABLE [dbo].[Demand_EcolabelSet]
ADD CONSTRAINT [FK_EcolabelDemand_Ecolabel]
    FOREIGN KEY ([EcolabelID])
    REFERENCES [dbo].[EcolabelSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EcolabelDemand_Ecolabel'
CREATE INDEX [IX_FK_EcolabelDemand_Ecolabel]
ON [dbo].[Demand_EcolabelSet]
    ([EcolabelID]);
GO

-- Creating foreign key on [EcolabelID] in table 'PersonalCabinetSet'
ALTER TABLE [dbo].[PersonalCabinetSet]
ADD CONSTRAINT [FK_EcolabelPersonalCabinet]
    FOREIGN KEY ([EcolabelID])
    REFERENCES [dbo].[EcolabelSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EcolabelPersonalCabinet'
CREATE INDEX [IX_FK_EcolabelPersonalCabinet]
ON [dbo].[PersonalCabinetSet]
    ([EcolabelID]);
GO

-- Creating foreign key on [EcolabelID] in table 'EcoType_EcolabelSet'
ALTER TABLE [dbo].[EcoType_EcolabelSet]
ADD CONSTRAINT [FK_EcolabelEcoType_Ecolabel]
    FOREIGN KEY ([EcolabelID])
    REFERENCES [dbo].[EcolabelSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EcolabelEcoType_Ecolabel'
CREATE INDEX [IX_FK_EcolabelEcoType_Ecolabel]
ON [dbo].[EcoType_EcolabelSet]
    ([EcolabelID]);
GO

-- Creating foreign key on [CountryID] in table 'Country_EcolabelSet'
ALTER TABLE [dbo].[Country_EcolabelSet]
ADD CONSTRAINT [FK_CountryCountry_Ecolabel]
    FOREIGN KEY ([CountryID])
    REFERENCES [dbo].[CountrySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryCountry_Ecolabel'
CREATE INDEX [IX_FK_CountryCountry_Ecolabel]
ON [dbo].[Country_EcolabelSet]
    ([CountryID]);
GO

-- Creating foreign key on [EcoTypeID] in table 'EcoType_EcolabelSet'
ALTER TABLE [dbo].[EcoType_EcolabelSet]
ADD CONSTRAINT [FK_EcoTypeEcoType_Ecolabel]
    FOREIGN KEY ([EcoTypeID])
    REFERENCES [dbo].[EcoTypeSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EcoTypeEcoType_Ecolabel'
CREATE INDEX [IX_FK_EcoTypeEcoType_Ecolabel]
ON [dbo].[EcoType_EcolabelSet]
    ([EcoTypeID]);
GO

-- Creating foreign key on [DemandID] in table 'Demand_EcolabelSet'
ALTER TABLE [dbo].[Demand_EcolabelSet]
ADD CONSTRAINT [FK_DemandDemand_Ecolabel]
    FOREIGN KEY ([DemandID])
    REFERENCES [dbo].[DemandSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DemandDemand_Ecolabel'
CREATE INDEX [IX_FK_DemandDemand_Ecolabel]
ON [dbo].[Demand_EcolabelSet]
    ([DemandID]);
GO

-- Creating foreign key on [PersonID] in table 'PersonalCabinetSet'
ALTER TABLE [dbo].[PersonalCabinetSet]
ADD CONSTRAINT [FK_PersonPersonalCabinet]
    FOREIGN KEY ([PersonID])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonalCabinet'
CREATE INDEX [IX_FK_PersonPersonalCabinet]
ON [dbo].[PersonalCabinetSet]
    ([PersonID]);
GO

-- Creating foreign key on [AccessLevelID] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [FK_AccessLevelPerson]
    FOREIGN KEY ([AccessLevelID])
    REFERENCES [dbo].[AccessLevelSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccessLevelPerson'
CREATE INDEX [IX_FK_AccessLevelPerson]
ON [dbo].[PersonSet]
    ([AccessLevelID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------