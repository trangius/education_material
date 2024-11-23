-- En stored procedure för att skapa en användare
CREATE PROCEDURE CreateUser
    @FullName NVARCHAR(255),
    @Address NVARCHAR(255),
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kontrollera om en användare med samma e-post redan finns
    IF EXISTS (SELECT 1 FROM Users WHERE Email = @Email)
    BEGIN
        PRINT 'User with this email already exists.';
        RETURN;
    END

    -- Skapa användaren
    INSERT INTO Users (FullName, Address, Email)
    VALUES (@FullName, @Address, @Email);

    PRINT 'User created successfully.';
END;

GO -- batchseparator, körs av klienten och säkerställer att kommandona ovan faktiskt har körts. EJ en del av SQL

-- testa den:
EXEC CreateUser 
    @FullName = 'John Doe',
    @Address = '123 Elm Street, Springfield',
    @Email = 'john.doe@example.com';

    EXEC CreateUser 
    @FullName = 'Kalle Anka',
    @Address = '123 Elm Street, Springfield',
    @Email = 'kalle.anka@example.com';
