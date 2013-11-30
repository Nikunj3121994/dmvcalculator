USE [ps.dmv.db]
GO

-- Dropping constraints

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FK_DmvCalculation_MobileDeCar]') AND type in (N'F'))
ALTER TABLE [dbo].[DmvCalculation] DROP CONSTRAINT FK_DmvCalculation_MobileDeCar
GO

-- Dropping tables

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MobileDeCar]') AND type in (N'U'))
DROP TABLE [dbo].[MobileDeCar]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DmvCalculation]') AND type in (N'U'))
DROP TABLE [dbo].[DmvCalculation]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleType]') AND type in (N'U'))
DROP TABLE [dbo].[VehicleType]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FuelType]') AND type in (N'U'))
DROP TABLE [dbo].[FuelType]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EuroExhaustType]') AND type in (N'U'))
DROP TABLE [dbo].[EuroExhaustType]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EngineType]') AND type in (N'U'))
DROP TABLE [dbo].[EngineType]
GO

