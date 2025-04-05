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


-- Staff table and data insertion
CREATE TABLE staff (
    staffID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    phone VARCHAR(20) NULL,
    email VARCHAR(100) NULL,
    position VARCHAR(50) NOT NULL,  -- Manager, Waiter, Chef, etc.
    salary DECIMAL(10,2) NULL,
    hireDate DATE NOT NULL,
    active BIT DEFAULT 1 -- 1 for active, 0 for inactive
)
GO


INSERT INTO staff (firstName, lastName, phone, email, position, salary, hireDate, active)
VALUES 
('John', 'Smith', '123-456-7890', 'john.smith@email.com', 'Manager', 5000.00, '2020-01-15', 1),
('Maria', 'Rodriguez', '234-567-8901', 'maria.rodriguez@email.com', 'Head Chef', 4500.00, '2020-03-10', 1),
('David', 'Johnson', '345-678-9012', 'david.johnson@email.com', 'Waiter', 2500.00, '2021-06-20', 1),
('Sarah', 'Williams', '456-789-0123', 'sarah.williams@email.com', 'Hostess', 2300.00, '2021-08-05', 1),
('James', 'Brown', '567-890-1234', 'james.brown@email.com', 'Bartender', 2800.00, '2022-01-12', 1)
GO

-- Order table and data insertion
CREATE TABLE orders (
    orderID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    tableID INT NOT NULL,  
    employeeID INT NOT NULL, -- Staff member who took the order
    orderDate DATETIME NOT NULL DEFAULT GETDATE(),
    status VARCHAR(20) NOT NULL DEFAULT 'New', -- New, Completed, Paid
    totalAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    notes VARCHAR(255) NULL,
    FOREIGN KEY (tableID) REFERENCES [tables](tableID),
    FOREIGN KEY (employeeID) REFERENCES staff(staffID)
)
GO

-- Insert sample orders in different statuses
INSERT INTO orders (tableID, employeeID, orderDate, status, totalAmount)
VALUES 
(1, 3, DATEADD(HOUR, -5, GETDATE()), 'New', 19.97),         -- New order for kitchen
(2, 3, DATEADD(HOUR, -4, GETDATE()), 'New', 26.97),         -- New order for kitchen
(3, 3, DATEADD(HOUR, -3, GETDATE()), 'Completed', 32.98),   -- Completed but not paid
(4, 3, DATEADD(HOUR, -2, GETDATE()), 'Completed', 16.99),   -- Completed but not paid
(5, 3, DATEADD(HOUR, -1, GETDATE()), 'Paid', 27.98)         -- Fully paid order
GO

-- Order items table and data insertion
CREATE TABLE orderItems (
    orderItemID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    orderID INT NOT NULL,
    productID INT NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    unitPrice DECIMAL(10,2) NOT NULL,
    subTotal DECIMAL(10,2) NOT NULL, -- unitPrice * quantity
    notes VARCHAR(255) NULL, -- Special instructions for the item
    FOREIGN KEY (orderID) REFERENCES orders(orderID),
    FOREIGN KEY (productID) REFERENCES products(pID)
)
GO

-- Insert sample order items for all orders
-- Order 1 items (New)
INSERT INTO orderItems (orderID, productID, quantity, unitPrice, subTotal)
VALUES 
(1, 1, 2, 5.99, 11.98), -- 2 Scrambled Eggs
(1, 4, 1, 7.99, 7.99);  -- 1 Pancakes

-- Order 2 items (New)
INSERT INTO orderItems (orderID, productID, quantity, unitPrice, subTotal)
VALUES 
(2, 3, 2, 8.99, 17.98), -- 2 Chicken Sandwich
(2, 4, 1, 6.99, 6.99),  -- 1 Caesar Salad
(2, 1, 1, 5.99, 5.99);  -- 1 Scrambled Eggs

-- Order 3 items (Completed)
INSERT INTO orderItems (orderID, productID, quantity, unitPrice, subTotal)
VALUES 
(3, 5, 1, 19.99, 19.99), -- 1 Steak Dinner
(3, 4, 1, 6.99, 6.99),   -- 1 Caesar Salad
(3, 1, 1, 5.99, 5.99);   -- 1 Scrambled Eggs

-- Order 4 items (Completed)
INSERT INTO orderItems (orderID, productID, quantity, unitPrice, subTotal)
VALUES 
(4, 6, 1, 16.99, 16.99); -- 1 Grilled Salmon

-- Order 5 items (Paid)
INSERT INTO orderItems (orderID, productID, quantity, unitPrice, subTotal)
VALUES 
(5, 3, 2, 8.99, 17.98), -- 2 Chicken Sandwich
(5, 4, 1, 6.99, 6.99),  -- 1 Caesar Salad
(5, 2, 1, 7.99, 7.99);  -- 1 Pancakes
GO