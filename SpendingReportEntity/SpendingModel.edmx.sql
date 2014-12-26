
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/26/2014 16:36:07
-- Generated from EDMX file: C:\Users\kubo\Source\Repos\SpendingReport\SpendingReportEntity\SpendingModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SpendingReport];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BankAccountEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [FK_BankAccountEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_EntryAmountInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [FK_EntryAmountInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentTypeEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [FK_PaymentTypeEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_BankBankAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankAccounts] DROP CONSTRAINT [FK_BankBankAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_TypeAmountInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AmountInfos] DROP CONSTRAINT [FK_TypeAmountInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_PurposeEntry_Purpose]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurposeEntry] DROP CONSTRAINT [FK_PurposeEntry_Purpose];
GO
IF OBJECT_ID(N'[dbo].[FK_PurposeEntry_Entry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurposeEntry] DROP CONSTRAINT [FK_PurposeEntry_Entry];
GO
IF OBJECT_ID(N'[dbo].[FK_UserBankAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankAccounts] DROP CONSTRAINT [FK_UserBankAccount];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Entries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Entries];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[BankAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankAccounts];
GO
IF OBJECT_ID(N'[dbo].[AmountInfos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AmountInfos];
GO
IF OBJECT_ID(N'[dbo].[Banks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Banks];
GO
IF OBJECT_ID(N'[dbo].[Purposes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purposes];
GO
IF OBJECT_ID(N'[dbo].[PaymentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentTypes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[PurposeEntry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurposeEntry];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Entries'
CREATE TABLE [dbo].[Entries] (
    [EntryId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [DatePosted] datetime  NULL,
    [Memo] nvarchar(max)  NULL,
    [DateAvailable] datetime  NULL,
    [VariableSymbol] bigint  NULL,
    [ConstantSymbol] smallint  NULL,
    [SpecificSymbol] bigint  NULL,
    [Reference] nvarchar(max)  NULL,
    [PaymentTypeId] int  NULL,
    [BankId] int  NOT NULL,
    [DateAdded] datetime  NOT NULL,
    [BankAccountId] int  NOT NULL,
    [AmountInfo_Id] int  NOT NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BankAccounts'
CREATE TABLE [dbo].[BankAccounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccountNumber] bigint  NULL,
    [IBAN] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [BankId] int  NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'AmountInfos'
CREATE TABLE [dbo].[AmountInfos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] decimal(8,2)  NOT NULL,
    [Currency] nvarchar(max)  NOT NULL,
    [TypeId] int  NOT NULL
);
GO

-- Creating table 'Banks'
CREATE TABLE [dbo].[Banks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [BankCode] smallint  NOT NULL
);
GO

-- Creating table 'Purposes'
CREATE TABLE [dbo].[Purposes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PaymentTypes'
CREATE TABLE [dbo].[PaymentTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'PurposeEntry'
CREATE TABLE [dbo].[PurposeEntry] (
    [Purposes_Id] int  NOT NULL,
    [Entries_EntryId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EntryId] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [PK_Entries]
    PRIMARY KEY CLUSTERED ([EntryId] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BankAccounts'
ALTER TABLE [dbo].[BankAccounts]
ADD CONSTRAINT [PK_BankAccounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AmountInfos'
ALTER TABLE [dbo].[AmountInfos]
ADD CONSTRAINT [PK_AmountInfos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Banks'
ALTER TABLE [dbo].[Banks]
ADD CONSTRAINT [PK_Banks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Purposes'
ALTER TABLE [dbo].[Purposes]
ADD CONSTRAINT [PK_Purposes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentTypes'
ALTER TABLE [dbo].[PaymentTypes]
ADD CONSTRAINT [PK_PaymentTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Purposes_Id], [Entries_EntryId] in table 'PurposeEntry'
ALTER TABLE [dbo].[PurposeEntry]
ADD CONSTRAINT [PK_PurposeEntry]
    PRIMARY KEY CLUSTERED ([Purposes_Id], [Entries_EntryId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AmountInfo_Id] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [FK_EntryAmountInfo]
    FOREIGN KEY ([AmountInfo_Id])
    REFERENCES [dbo].[AmountInfos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntryAmountInfo'
CREATE INDEX [IX_FK_EntryAmountInfo]
ON [dbo].[Entries]
    ([AmountInfo_Id]);
GO

-- Creating foreign key on [PaymentTypeId] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [FK_PaymentTypeEntry]
    FOREIGN KEY ([PaymentTypeId])
    REFERENCES [dbo].[PaymentTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentTypeEntry'
CREATE INDEX [IX_FK_PaymentTypeEntry]
ON [dbo].[Entries]
    ([PaymentTypeId]);
GO

-- Creating foreign key on [BankId] in table 'BankAccounts'
ALTER TABLE [dbo].[BankAccounts]
ADD CONSTRAINT [FK_BankBankAccount]
    FOREIGN KEY ([BankId])
    REFERENCES [dbo].[Banks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBankAccount'
CREATE INDEX [IX_FK_BankBankAccount]
ON [dbo].[BankAccounts]
    ([BankId]);
GO

-- Creating foreign key on [TypeId] in table 'AmountInfos'
ALTER TABLE [dbo].[AmountInfos]
ADD CONSTRAINT [FK_TypeAmountInfo]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[Types]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeAmountInfo'
CREATE INDEX [IX_FK_TypeAmountInfo]
ON [dbo].[AmountInfos]
    ([TypeId]);
GO

-- Creating foreign key on [Purposes_Id] in table 'PurposeEntry'
ALTER TABLE [dbo].[PurposeEntry]
ADD CONSTRAINT [FK_PurposeEntry_Purpose]
    FOREIGN KEY ([Purposes_Id])
    REFERENCES [dbo].[Purposes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Entries_EntryId] in table 'PurposeEntry'
ALTER TABLE [dbo].[PurposeEntry]
ADD CONSTRAINT [FK_PurposeEntry_Entry]
    FOREIGN KEY ([Entries_EntryId])
    REFERENCES [dbo].[Entries]
        ([EntryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurposeEntry_Entry'
CREATE INDEX [IX_FK_PurposeEntry_Entry]
ON [dbo].[PurposeEntry]
    ([Entries_EntryId]);
GO

-- Creating foreign key on [UserId] in table 'BankAccounts'
ALTER TABLE [dbo].[BankAccounts]
ADD CONSTRAINT [FK_UserBankAccount]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBankAccount'
CREATE INDEX [IX_FK_UserBankAccount]
ON [dbo].[BankAccounts]
    ([UserId]);
GO

-- Creating foreign key on [BankAccountId] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [FK_BankAccountEntry]
    FOREIGN KEY ([BankAccountId])
    REFERENCES [dbo].[BankAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankAccountEntry'
CREATE INDEX [IX_FK_BankAccountEntry]
ON [dbo].[Entries]
    ([BankAccountId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------