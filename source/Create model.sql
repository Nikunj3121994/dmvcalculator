USE [ps.dmv.db]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

-- [VehicleType]
CREATE TABLE [dbo].[VehicleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	PRIMARY KEY([Id])
)
GO

-- [FuelType]
CREATE TABLE [dbo].[FuelType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	PRIMARY KEY([Id])
)
GO

-- [EuroExhaustType]
CREATE TABLE [dbo].[EuroExhaustType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	PRIMARY KEY([Id])
)
GO

-- [EngineType]
CREATE TABLE [dbo].[EngineType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	PRIMARY KEY([Id])
)
GO

-- [DmvCalculation]
CREATE TABLE [dbo].[DmvCalculation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateOfCalculation] [datetime] NOT NULL,
	[VehicleTypeId] [int] NOT NULL,
	[FuelTypeId] [int] NOT NULL,
	[Co2EmissionsValue] [smallint] NOT NULL,
	[EuroExhaustTypeId] [int] NOT NULL,
	[AtLeastEightSeatsVehicle] [bit] NOT NULL,
	[DieselParticlesAbove005Limit] [bit] NOT NULL,
	[EnginePowerKw] [int] NOT NULL,
	[EngineDisplacementCcm] [int] NOT NULL,
	[EngineTypeId] [int] NOT NULL,
	[VehicleValue] [int] NOT NULL,
	[BaseTaxRate] [int] NOT NULL,
	[BaseTaxRateValue] [float] NOT NULL,
	[AdditionalTaxRate] [int] NOT NULL,
	[AdditionalTaxRateValue] [float] NOT NULL,
	[TaxTotalValue] [float] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[UserId] [nvarchar](128) NULL,
	PRIMARY KEY([Id])
)
GO

ALTER TABLE [dbo].[DmvCalculation]  WITH CHECK ADD CONSTRAINT FK_DmvCalculation_VehicleType FOREIGN KEY([VehicleTypeId]) REFERENCES [dbo].[VehicleType] ([Id])
GO

ALTER TABLE [dbo].[DmvCalculation]  WITH CHECK ADD CONSTRAINT FK_DmvCalculation_FuelType FOREIGN KEY([FuelTypeId]) REFERENCES [dbo].[FuelType] ([Id])
GO

ALTER TABLE [dbo].[DmvCalculation]  WITH CHECK ADD CONSTRAINT FK_DmvCalculation_EuroExhaustType FOREIGN KEY([EuroExhaustTypeId]) REFERENCES [dbo].[EuroExhaustType] ([Id])
GO

ALTER TABLE [dbo].[DmvCalculation]  WITH CHECK ADD CONSTRAINT FK_DmvCalculation_EngineType FOREIGN KEY([EngineTypeId]) REFERENCES [dbo].[EngineType] ([Id])
GO

ALTER TABLE [dbo].[DmvCalculation]  WITH CHECK ADD CONSTRAINT FK_DmvCalculation_AspNetUsers FOREIGN KEY([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
GO


-- [MobileDeCheckHistory]
CREATE TABLE [dbo].[MobileDeCar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](250) NOT NULL,
	[DmvCalculationId] [int] NOT NULL,
	[Maker] [nvarchar](30) NULL,
	[Model] [nvarchar](30) NULL,
	[IsDeleted] [bit] NOT NULL,
	[UserId] [nvarchar](128) NULL,
	PRIMARY KEY([Id])
)
GO

ALTER TABLE [dbo].[MobileDeImport]  WITH CHECK ADD CONSTRAINT FK_MobileDeImport_DmvCalculation FOREIGN KEY([DmvCalculationId]) REFERENCES [dbo].[DmvCalculation] ([Id])
GO

ALTER TABLE [dbo].[MobileDeImport]  WITH CHECK ADD CONSTRAINT FK_MobileDeImport_AspNetUsers FOREIGN KEY([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
GO

--

SET ANSI_PADDING OFF
GO


