-- 1️⃣ Create the database
CREATE DATABASE TasksAPI;
GO

-- 2️⃣ Use the database
USE TasksAPI;
GO

-- 3️⃣ Create Users table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Role NVARCHAR(20) NOT NULL -- e.g. Admin, Manager, Employee
);
GO

-- 4️⃣ Create Tasks table
CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    DueDate DATETIME,
    Status NVARCHAR(50),
    AssignedTo INT,
    FOREIGN KEY (AssignedTo) REFERENCES Users(Id)
);
GO

SELECT * FROM Users;
SELECT * FROM Tasks;

DELETE FROM Users;
