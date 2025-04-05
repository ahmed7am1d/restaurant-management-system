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


-- Product table and data insertion
CREATE TABLE products (
    pID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    pName VARCHAR(50) NOT NULL,
    pPrice DECIMAL(10,2) NOT NULL,
    pDescription VARCHAR(255) NULL,
    catID INT NOT NULL,
    CONSTRAINT FK_products_category FOREIGN KEY (catID) REFERENCES category(catID)
)
GO

INSERT INTO products (pName, pPrice, pDescription, catID)
VALUES
    ('Scrambled Eggs', 5.99, 'Fresh scrambled eggs with toast', 1),
    ('Pancakes', 7.99, 'Fluffy pancakes with maple syrup', 1),
    ('Chicken Sandwich', 8.99, 'Grilled chicken with lettuce and mayo', 2),
    ('Caesar Salad', 6.99, 'Fresh romaine lettuce with Caesar dressing', 2),
    ('Steak Dinner', 19.99, 'Grilled ribeye with mashed potatoes', 3),
    ('Grilled Salmon', 16.99, 'Fresh salmon with seasonal vegetables', 3)
GO

-- Table table and data insertion
CREATE TABLE tables (
    tableID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    tableNumber VARCHAR(10) NOT NULL,          -- Table identifier (e.g., "T1", "Table 5")
    capacity INT NOT NULL,                     -- How many people can sit at this table
    [location] VARCHAR(50) NULL,                 -- Section/area of restaurant (e.g., "Patio", "Main Floor")
    [status] VARCHAR(20) DEFAULT 'Available',    -- Current status: Available, Occupied, Reserved, Out of Service
    notes VARCHAR(255) NULL                    -- Any special notes about the table
)
GO

INSERT INTO tables (tableNumber, capacity, location, status, notes)
VALUES
('T1', 2, 'Main Floor', 'Available', 'Near window'),
('T2', 4, 'Main Floor', 'Available', 'Center area'),
('T3', 6, 'Patio', 'Available', 'Umbrella table'),
('T4', 8, 'Private Room', 'Available', 'Reservation required'),
('T5', 2, 'Bar Area', 'Available', 'High chairs')
GO