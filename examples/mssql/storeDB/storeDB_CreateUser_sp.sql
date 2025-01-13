SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- En stored procedure för att skapa en användare
CREATE PROCEDURE CreateCustomer
    @FullName NVARCHAR(255),
    @Address NVARCHAR(255),
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;  -- liten liten prestandaförbättring på SQL-servern

    -- Kontrollera om en användare med samma e-post redan finns
    IF EXISTS (SELECT 1 FROM Customer WHERE Email = @Email)
    BEGIN
        PRINT 'User with this email already exists.';
        RETURN;
    END

    -- Skapa användaren
    INSERT INTO Customer (FullName, Address, Email) VALUES (@FullName, @Address, @Email);

    PRINT 'User created successfully.';
END;

GO -- batchseparator, körs av klienten och säkerställer att kommandona ovan faktiskt har körts. EJ en del av SQL

-- testa den:
EXEC CreateUser 'John Doe', '123 Elm Street, Springfield', 'john.doe@example.com';

    EXEC CreateUser 
    @FullName = 'Kalle Anka',
    @Address = '123 Elm Street, Springfield',
    @Email = 'kalle.anka@example.com';
