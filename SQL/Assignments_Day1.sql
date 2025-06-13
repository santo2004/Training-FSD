--1.Create a stored procedure that takes a customer ID and returns the total amount they have ordered 
CREATE PROCEDURE CalculateTotalAmount
    @CustomerID INT,
    @TotalAmount DECIMAL(18, 2) OUTPUT
AS
BEGIN
    SELECT @TotalAmount = SUM(oi.quantity * oi.list_price * (1 - oi.discount))
    FROM sales.orders o
    JOIN sales.order_items oi ON o.order_id = oi.order_id
    WHERE o.customer_id = @CustomerID;
END;
GO

DECLARE @Total DECIMAL(18,2);
EXEC CalculateTotalAmount @CustomerID = 259, @TotalAmount = @Total OUTPUT;
SELECT @Total AS TotalAmountOrdered;

--2. Create a procedure that returns all orders placed for a specific store between two dates.
CREATE PROCEDURE GetOrdersByStoreAndDate
    @StoreID INT,
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT *
    FROM sales.orders
    WHERE store_id = @StoreID
      AND order_date BETWEEN @StartDate AND @EndDate;
END;
GO
EXEC GetOrdersByStoreAndDate @StoreID = 2, @StartDate = '2016-01-01', @EndDate = '2016-01-05';

--3.Create a stored procedure to insert a new product into production.products.
CREATE PROCEDURE InsertNewProduct
    (@ProductName NVARCHAR(255),
    @BrandID INT,
    @CategoryID INT,
    @ModelYear INT,
    @ListPrice DECIMAL(10, 2))
AS
BEGIN
    INSERT INTO production.products (product_name, brand_id, category_id, model_year, list_price)
    VALUES (@ProductName, @BrandID, @CategoryID, @ModelYear, @ListPrice);
END;
GO
 SELECT * FROM production.products;

EXEC InsertNewProduct 
    @ProductName = 'Speedster Pro Bike',
    @BrandID = 1,
    @CategoryID = 5,
    @ModelYear = 2025,
    @ListPrice = 1499.99;
GO

--4. Create a procedure that lists products with stock quantity less than a threshold in a specific store.
CREATE PROCEDURE GetLowStockProducts
    @StoreID INT,
    @Threshold INT
AS
BEGIN
    SELECT 
        p.product_id,
        p.product_name,
        s.store_id,
        s.quantity
    FROM production.stocks s
    JOIN production.products p ON s.product_id = p.product_id
    WHERE s.store_id = @StoreID
      AND s.quantity < @Threshold;
END;
GO

EXEC GetLowStockProducts 
    @StoreID = 1, 
    @Threshold = 10;
GO

--Assignment non User Defiined Function
--1.Create a scalar function that takes price and discount % and returns the discount amount.
CREATE FUNCTION dbo.CalculateDiscountAmount
(
    @Price DECIMAL(10, 2),
    @DiscountPercent DECIMAL(5, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @DiscountAmount DECIMAL(10, 2);
    SET @DiscountAmount = @Price * (@DiscountPercent / 100.0);
    RETURN @DiscountAmount;
END;
GO

SELECT order_id,quantity,list_price,discount,dbo.CalculateDiscountAmount(list_price, discount * 100) AS DiscountAmount FROM sales.order_items

--2. Create a function to return the Full_name name of the staff
CREATE FUNCTION dbo.GetStaffFullName
(
    @StaffID INT
)
RETURNS NVARCHAR(255)
AS
BEGIN
    DECLARE @FullName NVARCHAR(255);

    SELECT @FullName = first_name + ' ' + last_name
    FROM sales.staffs
    WHERE staff_id = @StaffID;

    RETURN @FullName;
END;
GO

SELECT dbo.GetStaffFullName(3) AS FullName;

--3.Create function to listout all orders placed by customer(id)
CREATE FUNCTION dbo.GetOrdersByCustomerID
(
    @CustomerID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT o.order_id, o.order_date, o.order_status, o.store_id
    FROM sales.orders o
    WHERE o.customer_id = @CustomerID
)
GO

SELECT * FROM dbo.GetOrdersByCustomerID(259);

-- 4.Create a function to display all product_name and quantity available from the given storeid (refer product,stocks table)
CREATE FUNCTION dbo.GetProductsByStoreID
(
    @StoreID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT p.product_name, s.quantity
    FROM production.products p
    JOIN production.stocks s ON p.product_id = s.product_id
    WHERE s.store_id = @StoreID
)
GO
SELECT * FROM dbo.GetProductsByStoreID(1);

--
CREATE FUNCTION dbo.StoreOrderSummary
(
    @StoreID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        o.order_id,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS TotalAmount
    FROM sales.orders o
    JOIN sales.order_items oi ON o.order_id = oi.order_id
    WHERE o.store_id = @StoreID
    GROUP BY o.order_id
)
GO
SELECT * FROM dbo.StoreOrderSummary(1);