-- Utvecklad version som skapar en utgående order:

DROP TRIGGER IF EXISTS UpdateProductQuantity; -- ta bort den ovan först

CREATE TRIGGER UpdateProductQuantity
ON OrderDetails
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON; -- Förbättrar prestandan genom att ignorera meddelanden om antalet påverkade rader

    -- Uppdatera quantity i Products-tabellen baserat på insatta rader
    UPDATE p
    SET p.quantity = p.quantity - i.quantity
    FROM Products p
    INNER JOIN inserted i
    ON p.id = i.ProductId;
    
    -- Skapa en utgående order till underleverantör om det sjunker under 5
    INSERT INTO OutgoingOrders (OrderDate, ProductId)
    SELECT GETDATE(), P.id
    FROM Products P
    WHERE P.quantity < 5;
END
