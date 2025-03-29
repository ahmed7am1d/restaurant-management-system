CREATE DATABASE RM
GO

USE RM;
GO

-- USER table and data insertion
CREATE TABLE users (
    userID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    username VARCHAR(50) NOT NULL,
    upass VARCHAR(10) NOT NULL,
	uName VARCHAR(50) NOT NULL,
	uphone VARCHAR(20) NULL,
)
GO


INSERT INTO users (username, upass, uName, uphone)
VALUES ('admin', '123', 'Admin user', '1234567')
GO

-- Category table and data insertion
CREATE TABLE category (
    catID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	catName VARCHAR(50) NOT NULL
)
GO

INSERT INTO category (catName)
VALUES ('Breakfast'), ('Lunch'), ('Dinner')