CREATE TABLE Customer
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE Product
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Quantity INT NOT NULL -- lagerstatus
);

CREATE TABLE IncomingOrder -- order som kunderna lägger
(    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    CustomerId INT NOT NULL,
    IsSent BIT DEFAULT 0,
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
);

CREATE TABLE OrderDetail -- rader i en order
(
    IncomingOrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    PRIMARY KEY (IncomingOrderId, ProductId), -- Sammansatt primärnyckel
    FOREIGN KEY (IncomingOrderId) REFERENCES IncomingOrder(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

CREATE TABLE OutgoingOrder -- för företaget ska kunna skapa automatiska ordrar till underleverantörer
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    ProductId INT NOT NULL,
    IsPlaced BIT DEFAULT 0,
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);


GO -- batchseparator, körs av klienten och säkerställer att kommandona ovan faktiskt har körts. EJ en del av SQL

INSERT INTO Customer (FullName, Address, Email)
VALUES 
('John Doe', '123 Elm Street, Springfield', 'john.doe@example.com'),
('Jane Smith', '456 Oak Avenue, Metropolis', 'jane.smith@example.com'),
('Alice Johnson', '789 Pine Road, Gotham', 'alice.johnson@example.com'),
('Bob Brown', '101 Maple Lane, Smallville', 'bob.brown@example.com'),
('Charlie Davis', '202 Birch Boulevard, Star City', 'charlie.davis@example.com'),
('Diana Evans', '303 Cedar Street, Central City', 'diana.evans@example.com'),
('Evan Harris', '404 Walnut Drive, Coast City', 'evan.harris@example.com'),
('Fiona Green', '505 Aspen Court, Keystone City', 'fiona.green@example.com'),
('George Hill', '606 Cherry Circle, Fawcett City', 'george.hill@example.com'),
('Helen Carter', '707 Willow Way, National City', 'helen.carter@example.com');


INSERT INTO Product (Name, Quantity)
VALUES 
('Laptop Pro 15"', 15),
('Wireless Mouse', 150),
('Mechanical Keyboard', 75),
('Gaming Headset', 50),
('4K Monitor', 30),
('External SSD 1TB', 60),
('USB-C Hub', 120),
('Ergonomic Office Chair', 20),
('Smartphone Case', 200),
('Noise Cancelling Headphones', 45),
('Graphics Card RTX 4090', 10),
('Power Bank 20,000mAh', 100),
('Gaming Chair', 15),
('Wi-Fi Router', 40),
('Portable Projector', 18),
('Bluetooth Speaker', 85),
('Drone with Camera', 12),
('Smartwatch', 35),
('LED Desk Lamp', 70),
('Digital Drawing Tablet', 25);

INSERT INTO IncomingOrder (CustomerId, IsSent)
VALUES
(1, 0),
(2, 1),
(3, 0),
(4, 0),
(1, 1); 

INSERT INTO OrderDetail (IncomingOrderId, ProductId, Quantity)
VALUES
(1, 2, 1),
(1, 3, 3),
(1, 7, 2),
(2, 1, 1),
(2, 5, 2),
(3, 2, 1),
(4, 7, 1),
(4, 1, 2),
(5, 2, 2);
