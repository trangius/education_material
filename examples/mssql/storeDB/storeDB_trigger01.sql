-- Skapar en trigger som uppdaterar quantity i Products-tabellen baserat på insatta rader i OrderDetails-tabellen.
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
END
