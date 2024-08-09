CREATE DATABASE CarMgmtsystem
Go;

USE [CarMgmtsystem]
Go;

Create Table Car
(
	Id bigint primary Key identity(1,1),
	Brand varchar(50) NOT NULL,
	Class varchar(50) NOT NULL,
	ModelName varchar(50) NOT NULL,
	ModelCode varchar(50) NOT NULL,
	[Description] varchar(50) NOT NULL,
	Feature varchar(max) NOT NULL,
	Price numeric(18,2) NOT NULL,
	DateofManufacturing datetime NOT NULL,
	Active bit DEfault(1),
	SortOrder int Default(0)
)

CREATE TABLE CatImage
(
	Id bigint Primary key Identity(1,1),
	CarId bigint references car(id),
	ImageName varchar(max)
)
Go;

CREATE PROCEDURE CreateCar
	@Brand varchar(50),
	@Class varchar(50),
	@ModelName varchar(50),
	@ModelCode varchar(50),
	@Description varchar(50),
	@Feature varchar(max),
	@Price numeric(18,2),
	@DateofManufacturing Datetime,
	@Active bit,
	@SortOrder int
AS
BEGIN
SET NOCOUNT ON;
BEGIN TRY
	INSERT INTO Car
	(Brand, Class, ModelName, ModelCode,	[Description],	Feature, Price, DateofManufacturing, Active, SortOrder)
	VALUES
	( @Brand, @Class, @ModelName, @ModelCode,	@Description,	@Feature, @Price, @DateofManufacturing, @Active, @SortOrder)
	DECLARE @NewCarID As bigint = SCOPE_Identity();
	SELECT @NewCarID As Id, 'Car Created Successfully.' As msg
END TRY
BEGIN CATCH
	SELECT 0 as Id, @@ERROR As Msg
END CATCH
END
Go;

CREATE PROCEDURE UpdateCar
    @Id bigint,
	@Brand varchar(50),
	@Class varchar(50),
	@ModelName varchar(50),
	@ModelCode varchar(50),
	@Description varchar(50),
	@Feature varchar(max),
	@Price numeric(18,2),
	@DateofManufacturing Datetime,
	@Active bit,
	@SortOrder int
AS
BEGIN
SET NOCOUNT ON;
BEGIN TRY
	UPDATE Car SET
		Brand = @Brand, 
		Class = @Class, 
		ModelName = @ModelName, 
		ModelCode = @ModelCode,	
		[Description] = @Description,	
		Feature = @Feature, 
		Price = @Price, 
		DateofManufacturing = @DateofManufacturing, 
		SortOrder = @SortOrder
	WHERE Id = @Id

	
	SELECT @id As id, 'Car Updated Successfully.' As msg
END TRY
BEGIN CATCH
	SELECT @@ERROR As Msg
END CATCH
END
Go;

CREATE PROCEDURE ActiveInActiveCar
    @Id bigint
AS
BEGIN
SET NOCOUNT ON;
BEGIN TRY
	UPDATE Car SET
		Active = ~Active
	WHERE Id = @Id
	
	SELECT @id As id, 'Car Status Updated Successfully.' As msg
END TRY
BEGIN CATCH
	SELECT @@ERROR As Msg
END CATCH
END
Go;

CREATE PROCEDURE ListCar
    @Id bigint = NULL
AS
BEGIN
SET NOCOUNT ON;
	
	SELECT 
		Id, Brand, Class, ModelName, ModelCode,	[Description],	Feature, Price, DateofManufacturing, Active, SortOrder
	From Car
	WHERE  Id = ISNULL(@Id, car.Id)
	Order By Id DESC
END

Create Procedure SaveCarImage
 @CarId bigint,
 @ImageName varchar(max),
AS
BEGIN
SET NOCOUNT ON;
BEGIN TRY
	INSERT INTO CatImage
	(CarID, ImageName)
	Values(@CarId, @ImageName)
	SELECT "Car Image Save Successfully." as msg
END TRY
BEGIN CATCH
	SELECT @@ERROR As Msg
END CATCH


Create Procedure UpdateCarImage
 @ID bigint,
 @CarId bigint,
 @ImageName varchar(max),
AS
BEGIN
SET NOCOUNT ON;
BEGIN TRY
	Update CatImage SET
		ImageName = @ImageName
	WHERE ID = @Id and CarId = @CarId
	SELECT "Car Image Updated Successfully." as msg
END TRY
BEGIN CATCH
	SELECT @@ERROR As Msg
END CATCH


Create Procedure DeleteCarImage
 @ID bigint,
 @CarId bigint
AS
BEGIN
SET NOCOUNT ON;
BEGIN TRY
	Delete From CatImage WHERE ID = @Id and CarId = @CarId
	SELECT "Car Image Deleted Successfully." as msg
END TRY
BEGIN CATCH
	SELECT @@ERROR As Msg
END CATCH