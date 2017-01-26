
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/26/2017 00:13:25
-- Generated from EDMX file: C:\Users\dev\Source\Repos\SpendingReport\SpendingReportEntity4\SpendingContext.edmx
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

IF OBJECT_ID(N'[dbo].[FK_dbo_AmountInfos_dbo_Types_TypeId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AmountInfos] DROP CONSTRAINT [FK_dbo_AmountInfos_dbo_Types_TypeId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Entries_dbo_AmountInfos_AmountInfoId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [FK_dbo_Entries_dbo_AmountInfos_AmountInfoId];
GO
IF OBJECT_ID(N'[dbo].[FK_Entries_AmountInfos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [FK_Entries_AmountInfos];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_BankAccounts_dbo_Banks_BankId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankAccounts] DROP CONSTRAINT [FK_dbo_BankAccounts_dbo_Banks_BankId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_BankAccounts_dbo_Users_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankAccounts] DROP CONSTRAINT [FK_dbo_BankAccounts_dbo_Users_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Entries_dbo_BankAccounts_BankAccountID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [FK_dbo_Entries_dbo_BankAccounts_BankAccountID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Entries_dbo_BankAccounts_DestinationAccountId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [FK_dbo_Entries_dbo_BankAccounts_DestinationAccountId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Entries_dbo_PaymentTypes_PaymentTypeId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [FK_dbo_Entries_dbo_PaymentTypes_PaymentTypeId];
GO
IF OBJECT_ID(N'[dbo].[FK_EntryTansactionCategory_Entry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntryTansactionCategory] DROP CONSTRAINT [FK_EntryTansactionCategory_Entry];
GO
IF OBJECT_ID(N'[dbo].[FK_EntryTansactionCategory_TransactionCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntryTansactionCategory] DROP CONSTRAINT [FK_EntryTansactionCategory_TransactionCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryNames_TransactionDescription]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CategoryNames] DROP CONSTRAINT [FK_CategoryNames_TransactionDescription];
GO
IF OBJECT_ID(N'[dbo].[FK_Cars_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Cars_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Trips_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trips] DROP CONSTRAINT [FK_Trips_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_Purchases_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [FK_Purchases_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_Fuelings_ToTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fuelings] DROP CONSTRAINT [FK_Fuelings_ToTable];
GO
IF OBJECT_ID(N'[dbo].[FK_Fuelings_FuelStations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchases] DROP CONSTRAINT [FK_Fuelings_FuelStations];
GO
IF OBJECT_ID(N'[dbo].[FK_TankStatuses_Cars]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TankStatuses] DROP CONSTRAINT [FK_TankStatuses_Cars];
GO
IF OBJECT_ID(N'[dbo].[FK_Fuelings_TankStatuses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fuelings] DROP CONSTRAINT [FK_Fuelings_TankStatuses];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingSavingTransactions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingTransactions] DROP CONSTRAINT [FK_SavingSavingTransactions];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[C__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[C__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AmountInfos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AmountInfos];
GO
IF OBJECT_ID(N'[dbo].[BankAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankAccounts];
GO
IF OBJECT_ID(N'[dbo].[Banks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Banks];
GO
IF OBJECT_ID(N'[dbo].[Entries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Entries];
GO
IF OBJECT_ID(N'[dbo].[PaymentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentTypes];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[CategoryNames]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryNames];
GO
IF OBJECT_ID(N'[dbo].[TransactionCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionCategories];
GO
IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[FuelStations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuelStations];
GO
IF OBJECT_ID(N'[dbo].[Trips]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trips];
GO
IF OBJECT_ID(N'[dbo].[Fuelings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fuelings];
GO
IF OBJECT_ID(N'[dbo].[Purchases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchases];
GO
IF OBJECT_ID(N'[dbo].[TankStatuses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TankStatuses];
GO
IF OBJECT_ID(N'[dbo].[Savings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Savings];
GO
IF OBJECT_ID(N'[dbo].[SavingTransactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavingTransactions];
GO
IF OBJECT_ID(N'[dbo].[EntryTansactionCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntryTansactionCategory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
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

-- Creating table 'BankAccounts'
CREATE TABLE [dbo].[BankAccounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccountNumber] bigint  NULL,
    [IBAN] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [BankId] int  NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'Banks'
CREATE TABLE [dbo].[Banks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [BankCode] smallint  NOT NULL
);
GO

-- Creating table 'Entries'
CREATE TABLE [dbo].[Entries] (
    [ID] int IDENTITY(1,1) NOT NULL,
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
    [AmountInfoId] int  NOT NULL,
    [SourceAccountId] int  NULL,
    [DestinationAccountId] int  NULL
);
GO

-- Creating table 'PaymentTypes'
CREATE TABLE [dbo].[PaymentTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategoryNames'
CREATE TABLE [dbo].[CategoryNames] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TransactionDescriptionId] int  NOT NULL,
    [Description] varchar(50)  NOT NULL
);
GO

-- Creating table 'TransactionCategories'
CREATE TABLE [dbo].[TransactionCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [UserId] int  NOT NULL,
    [TankSize] int  NULL,
    [Color] nvarchar(50)  NULL,
    [Description] nchar(10)  NULL
);
GO

-- Creating table 'FuelStations'
CREATE TABLE [dbo].[FuelStations] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Address] nvarchar(50)  NULL,
    [Description] nvarchar(50)  NULL
);
GO

-- Creating table 'Trips'
CREATE TABLE [dbo].[Trips] (
    [Id] int  NOT NULL,
    [Distance] int  NOT NULL,
    [From] nvarchar(50)  NULL,
    [To] nvarchar(50)  NULL,
    [Date] datetime  NOT NULL,
    [CarId] int  NOT NULL,
    [DistanceStart] int  NULL,
    [DistanceEnd] int  NULL
);
GO

-- Creating table 'Fuelings'
CREATE TABLE [dbo].[Fuelings] (
    [Id] int  NOT NULL,
    [Value] float  NOT NULL,
    [FuelPrice] float  NOT NULL
);
GO

-- Creating table 'Purchases'
CREATE TABLE [dbo].[Purchases] (
    [Id] int  NOT NULL,
    [Price] float  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [CarId] int  NULL,
    [Description] nvarchar(50)  NULL,
    [StationId] int  NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'TankStatuses'
CREATE TABLE [dbo].[TankStatuses] (
    [Id] int  NOT NULL,
    [TotalDistance] int  NOT NULL,
    [Empty] bit  NOT NULL,
    [CarId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Percentage] int  NULL
);
GO

-- Creating table 'Savings'
CREATE TABLE [dbo].[Savings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SavingTransactions'
CREATE TABLE [dbo].[SavingTransactions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [Price] float  NOT NULL,
    [HighestPrice] float  NOT NULL,
    [PayedPrice] float  NOT NULL,
    [Date] datetime  NOT NULL,
    [Saving_Id] int  NOT NULL
);
GO

-- Creating table 'EntryTansactionCategory'
CREATE TABLE [dbo].[EntryTansactionCategory] (
    [Entries_ID] int  NOT NULL,
    [TransactionCategories_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AmountInfos'
ALTER TABLE [dbo].[AmountInfos]
ADD CONSTRAINT [PK_AmountInfos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BankAccounts'
ALTER TABLE [dbo].[BankAccounts]
ADD CONSTRAINT [PK_BankAccounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Banks'
ALTER TABLE [dbo].[Banks]
ADD CONSTRAINT [PK_Banks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [PK_Entries]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentTypes'
ALTER TABLE [dbo].[PaymentTypes]
ADD CONSTRAINT [PK_PaymentTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoryNames'
ALTER TABLE [dbo].[CategoryNames]
ADD CONSTRAINT [PK_CategoryNames]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionCategories'
ALTER TABLE [dbo].[TransactionCategories]
ADD CONSTRAINT [PK_TransactionCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FuelStations'
ALTER TABLE [dbo].[FuelStations]
ADD CONSTRAINT [PK_FuelStations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Trips'
ALTER TABLE [dbo].[Trips]
ADD CONSTRAINT [PK_Trips]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fuelings'
ALTER TABLE [dbo].[Fuelings]
ADD CONSTRAINT [PK_Fuelings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [PK_Purchases]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TankStatuses'
ALTER TABLE [dbo].[TankStatuses]
ADD CONSTRAINT [PK_TankStatuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Savings'
ALTER TABLE [dbo].[Savings]
ADD CONSTRAINT [PK_Savings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SavingTransactions'
ALTER TABLE [dbo].[SavingTransactions]
ADD CONSTRAINT [PK_SavingTransactions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Entries_ID], [TransactionCategories_Id] in table 'EntryTansactionCategory'
ALTER TABLE [dbo].[EntryTansactionCategory]
ADD CONSTRAINT [PK_EntryTansactionCategory]
    PRIMARY KEY CLUSTERED ([Entries_ID], [TransactionCategories_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TypeId] in table 'AmountInfos'
ALTER TABLE [dbo].[AmountInfos]
ADD CONSTRAINT [FK_dbo_AmountInfos_dbo_Types_TypeId]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[Types]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AmountInfos_dbo_Types_TypeId'
CREATE INDEX [IX_FK_dbo_AmountInfos_dbo_Types_TypeId]
ON [dbo].[AmountInfos]
    ([TypeId]);
GO

-- Creating foreign key on [AmountInfoId] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [FK_dbo_Entries_dbo_AmountInfos_AmountInfoId]
    FOREIGN KEY ([AmountInfoId])
    REFERENCES [dbo].[AmountInfos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Entries_dbo_AmountInfos_AmountInfoId'
CREATE INDEX [IX_FK_dbo_Entries_dbo_AmountInfos_AmountInfoId]
ON [dbo].[Entries]
    ([AmountInfoId]);
GO

-- Creating foreign key on [AmountInfoId] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [FK_Entries_AmountInfos]
    FOREIGN KEY ([AmountInfoId])
    REFERENCES [dbo].[AmountInfos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Entries_AmountInfos'
CREATE INDEX [IX_FK_Entries_AmountInfos]
ON [dbo].[Entries]
    ([AmountInfoId]);
GO

-- Creating foreign key on [BankId] in table 'BankAccounts'
ALTER TABLE [dbo].[BankAccounts]
ADD CONSTRAINT [FK_dbo_BankAccounts_dbo_Banks_BankId]
    FOREIGN KEY ([BankId])
    REFERENCES [dbo].[Banks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_BankAccounts_dbo_Banks_BankId'
CREATE INDEX [IX_FK_dbo_BankAccounts_dbo_Banks_BankId]
ON [dbo].[BankAccounts]
    ([BankId]);
GO

-- Creating foreign key on [UserId] in table 'BankAccounts'
ALTER TABLE [dbo].[BankAccounts]
ADD CONSTRAINT [FK_dbo_BankAccounts_dbo_Users_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_BankAccounts_dbo_Users_UserId'
CREATE INDEX [IX_FK_dbo_BankAccounts_dbo_Users_UserId]
ON [dbo].[BankAccounts]
    ([UserId]);
GO

-- Creating foreign key on [SourceAccountId] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [FK_dbo_Entries_dbo_BankAccounts_BankAccountID]
    FOREIGN KEY ([SourceAccountId])
    REFERENCES [dbo].[BankAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Entries_dbo_BankAccounts_BankAccountID'
CREATE INDEX [IX_FK_dbo_Entries_dbo_BankAccounts_BankAccountID]
ON [dbo].[Entries]
    ([SourceAccountId]);
GO

-- Creating foreign key on [DestinationAccountId] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [FK_dbo_Entries_dbo_BankAccounts_DestinationAccountId]
    FOREIGN KEY ([DestinationAccountId])
    REFERENCES [dbo].[BankAccounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Entries_dbo_BankAccounts_DestinationAccountId'
CREATE INDEX [IX_FK_dbo_Entries_dbo_BankAccounts_DestinationAccountId]
ON [dbo].[Entries]
    ([DestinationAccountId]);
GO

-- Creating foreign key on [PaymentTypeId] in table 'Entries'
ALTER TABLE [dbo].[Entries]
ADD CONSTRAINT [FK_dbo_Entries_dbo_PaymentTypes_PaymentTypeId]
    FOREIGN KEY ([PaymentTypeId])
    REFERENCES [dbo].[PaymentTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Entries_dbo_PaymentTypes_PaymentTypeId'
CREATE INDEX [IX_FK_dbo_Entries_dbo_PaymentTypes_PaymentTypeId]
ON [dbo].[Entries]
    ([PaymentTypeId]);
GO

-- Creating foreign key on [Entries_ID] in table 'EntryTansactionCategory'
ALTER TABLE [dbo].[EntryTansactionCategory]
ADD CONSTRAINT [FK_EntryTansactionCategory_Entry]
    FOREIGN KEY ([Entries_ID])
    REFERENCES [dbo].[Entries]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TransactionCategories_Id] in table 'EntryTansactionCategory'
ALTER TABLE [dbo].[EntryTansactionCategory]
ADD CONSTRAINT [FK_EntryTansactionCategory_TransactionCategory]
    FOREIGN KEY ([TransactionCategories_Id])
    REFERENCES [dbo].[TransactionCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntryTansactionCategory_TransactionCategory'
CREATE INDEX [IX_FK_EntryTansactionCategory_TransactionCategory]
ON [dbo].[EntryTansactionCategory]
    ([TransactionCategories_Id]);
GO

-- Creating foreign key on [TransactionDescriptionId] in table 'CategoryNames'
ALTER TABLE [dbo].[CategoryNames]
ADD CONSTRAINT [FK_CategoryNames_TransactionDescription]
    FOREIGN KEY ([TransactionDescriptionId])
    REFERENCES [dbo].[TransactionCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryNames_TransactionDescription'
CREATE INDEX [IX_FK_CategoryNames_TransactionDescription]
ON [dbo].[CategoryNames]
    ([TransactionDescriptionId]);
GO

-- Creating foreign key on [UserId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_Cars_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cars_Users'
CREATE INDEX [IX_FK_Cars_Users]
ON [dbo].[Cars]
    ([UserId]);
GO

-- Creating foreign key on [CarId] in table 'Trips'
ALTER TABLE [dbo].[Trips]
ADD CONSTRAINT [FK_Trips_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trips_Cars'
CREATE INDEX [IX_FK_Trips_Cars]
ON [dbo].[Trips]
    ([CarId]);
GO

-- Creating foreign key on [CarId] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_Purchases_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Purchases_Cars'
CREATE INDEX [IX_FK_Purchases_Cars]
ON [dbo].[Purchases]
    ([CarId]);
GO

-- Creating foreign key on [Id] in table 'Fuelings'
ALTER TABLE [dbo].[Fuelings]
ADD CONSTRAINT [FK_Fuelings_ToTable]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Purchases]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [StationId] in table 'Purchases'
ALTER TABLE [dbo].[Purchases]
ADD CONSTRAINT [FK_Fuelings_FuelStations]
    FOREIGN KEY ([StationId])
    REFERENCES [dbo].[FuelStations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Fuelings_FuelStations'
CREATE INDEX [IX_FK_Fuelings_FuelStations]
ON [dbo].[Purchases]
    ([StationId]);
GO

-- Creating foreign key on [CarId] in table 'TankStatuses'
ALTER TABLE [dbo].[TankStatuses]
ADD CONSTRAINT [FK_TankStatuses_Cars]
    FOREIGN KEY ([CarId])
    REFERENCES [dbo].[Cars]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TankStatuses_Cars'
CREATE INDEX [IX_FK_TankStatuses_Cars]
ON [dbo].[TankStatuses]
    ([CarId]);
GO

-- Creating foreign key on [Id] in table 'Fuelings'
ALTER TABLE [dbo].[Fuelings]
ADD CONSTRAINT [FK_Fuelings_TankStatuses]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[TankStatuses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Saving_Id] in table 'SavingTransactions'
ALTER TABLE [dbo].[SavingTransactions]
ADD CONSTRAINT [FK_SavingSavingTransactions]
    FOREIGN KEY ([Saving_Id])
    REFERENCES [dbo].[Savings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SavingSavingTransactions'
CREATE INDEX [IX_FK_SavingSavingTransactions]
ON [dbo].[SavingTransactions]
    ([Saving_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------