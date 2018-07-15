
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/15/2018 00:53:22
-- Generated from EDMX file: F:\Evolent task\ContactFormApplication\ContactFormApplication\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ContactForm];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ContactDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactDetails];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ContactDetails'
CREATE TABLE [dbo].[ContactDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [PhoneNumber] nvarchar(10)  NOT NULL,
    [Status] tinyint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ContactDetails'
ALTER TABLE [dbo].[ContactDetails]
ADD CONSTRAINT [PK_ContactDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------