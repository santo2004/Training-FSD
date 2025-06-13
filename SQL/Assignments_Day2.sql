CREATE TRIGGER update_inventory_after_sale
ON sales.order_items
AFTER INSERT
AS
BEGIN
    UPDATE p
    SET p.quantity = p.quantity - i.quantity
    FROM production.stocks p
    INNER JOIN inserted i
        ON p.product_id = i.product_id
    INNER JOIN sales.orders o
        ON o.order_id = i.order_id
       AND p.store_id = o.store_id;
END;
INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
VALUES (2, 101, 21, 1, 599.99, 0.10);  
GO

--1

CREATE TRIGGER trg_UpdateProductInventory_AfterSale
ON sales.order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE p
    SET p.quantity = p.quantity - i.quantity
    FROM production.products p
    INNER JOIN inserted i
        ON p.product_id = i.product_id;
END;
GO

--2
CREATE TRIGGER update_inventory_after_sale
ON sales.order_items
AFTER INSERT
AS
BEGIN
    UPDATE p
    SET p.quantity = p.quantity - i.quantity
    FROM production.stocks p
    INNER JOIN inserted i
        ON p.product_id = i.product_id
    INNER JOIN sales.orders o
        ON o.order_id = i.order_id
       AND p.store_id = o.store_id;
END;
INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
VALUES (1, 100, 20, 1, 599.99, 0.10);  
GO
--3
SELECT*FROM production.products;
GO

CREATE TRIGGER trg_PreventOversell
ON sales.order_items
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN production.stocks p ON i.product_id = p.product_id
        WHERE i.quantity > p.quantity
    )
    BEGIN
        RAISERROR (
            'Cannot insert sale: quantity sold exceeds available stock.',
            16, 1
        );
        ROLLBACK TRANSACTION;
        RETURN;
    END
    INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
    SELECT order_id, item_id, product_id, quantity, list_price, discount
    FROM inserted;
END;