-- Skapa Students-tabellen med auto-inkrement på Id
CREATE TABLE Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,   -- Auto-inkrementerande Id
    Name VARCHAR(100),                  -- Studentens namn
    Email VARCHAR(100),                 -- Studentens e-post
    DateOfBirth DATE                    -- Studentens födelsedatum
);

-- Skapa Teachers-tabellen med auto-inkrement på Id
CREATE TABLE Teachers (
    Id INT IDENTITY(1,1) PRIMARY KEY,   -- Auto-inkrementerande Id
    Name VARCHAR(100),                  -- Lärarens namn
    Email VARCHAR(100)                  -- Lärarens e-post
);

-- Skapa Courses-tabellen med auto-inkrement på Id
CREATE TABLE Courses (
    Id INT IDENTITY(1,1) PRIMARY KEY,   -- Auto-inkrementerande Id
    Name VARCHAR(100),            -- Namnet på kursen
    Credits INT,                        -- Antal poäng för kursen
    TeacherId INT                       -- Lärarens Id som håller kursen
);

-- Skapa Enrollments-tabellen (mellanliggande tabell för många-till-många)
CREATE TABLE Enrollments (
    Id INT IDENTITY(1,1) PRIMARY KEY,   -- Auto-inkrementerande Id
    StudentId INT,                      -- Studentens Id
    CourseId INT,                       -- Kursens Id
    EnrollmentDate DATE,                -- Datum för registreringen
    Grade VARCHAR(2)                    -- Betyg för kursen (t.ex. A, B, C...)
);


-- Fyll på Students-tabellen
INSERT INTO Students (Name, Email, DateOfBirth) VALUES
('Anna Svensson', 'anna.svensson@example.com', '1998-03-15'),
('Erik Johansson', 'erik.johansson@example.com', '1997-07-21'),
('Maria Andersson', 'maria.andersson@example.com', '1999-11-02'),
('Ali Mohammed', 'ali.mohammed@example.com', '2000-01-23'),
('Sara Lind', 'sara.lind@example.com', '1998-09-14'),
('Johan Pettersson', 'johan.pettersson@example.com', '1996-12-09'),
('Fatima Ahmed', 'fatima.ahmed@example.com', '1998-06-18'),
('David Nilsson', 'david.nilsson@example.com', '1997-04-30'),
('Lina Berg', 'lina.berg@example.com', '1999-05-08'),
('Mehmet Kaya', 'mehmet.kaya@example.com', '1998-12-12'),
('Anders Eriksson', 'anders.eriksson@example.com', '1995-03-15'),
('Beatrice Andersson', 'beatrice.andersson@example.com', '1994-07-23'),
('Carl Nilsson', 'carl.nilsson@example.com', '1993-12-01'),
('David Johansson', 'david.johansson@example.com', '1996-06-10'),
('Emma Karlsson', 'emma.karlsson@example.com', '1992-09-11'),
('Fredrik Svensson', 'fredrik.svensson@example.com', '1991-02-22'),
('Gustav Lund', 'gustav.lund@example.com', '1997-01-09'),
('Hanna Persson', 'hanna.persson@example.com', '1995-08-14'),
('Isabella Gustavsson', 'isabella.gustavsson@example.com', '1994-04-12'),
('Johan Lind', 'johan.lind@example.com', '1998-11-05'),
('Klara Sandberg', 'klara.sandberg@example.com', '1992-10-10'),
('Lina Axelsson', 'lina.axelsson@example.com', '1996-03-27'),
('Marcus Holm', 'marcus.holm@example.com', '1993-04-03'),
('Nina Larsson', 'nina.larsson@example.com', '1995-05-17'),
('Oscar Berg', 'oscar.berg@example.com', '1991-11-30'),
('Petra Forsberg', 'petra.forsberg@example.com', '1997-12-15'),
('Rickard Östlund', 'rickard.ostlund@example.com', '1993-06-20'),
('Sara Henriksson', 'sara.henriksson@example.com', '1995-01-05'),
('Tobias Mattsson', 'tobias.mattsson@example.com', '1992-07-22'),
('Ulla Holmgren', 'ulla.holmgren@example.com', '1994-09-09'),
('Viktor Hansson', 'viktor.hansson@example.com', '1996-11-11'),
('Wilma Bergström', 'wilma.bergstrom@example.com', '1998-05-25'),
('Xander Johansson', 'xander.johansson@example.com', '1993-02-18'),
('Yasmine Åberg', 'yasmine.aberg@example.com', '1991-04-14'),
('Zara Nyström', 'zara.nystrom@example.com', '1994-03-23'),
('Adam Pettersson', 'adam.pettersson@example.com', '1992-08-19'),
('Benny Sjöberg', 'benny.sjoberg@example.com', '1997-07-30'),
('Cecilia Dahl', 'cecilia.dahl@example.com', '1991-10-05'),
('Daniel Åkesson', 'daniel.akesson@example.com', '1995-06-16'),
('Elin Lindström', 'elin.lindstrom@example.com', '1996-12-27'),
('Felix Norén', 'felix.noren@example.com', '1998-11-01'),
('Greta Blom', 'greta.blom@example.com', '1992-05-13'),
('Hugo Svensson', 'hugo.svensson@example.com', '1994-02-26'),
('Ida Jansson', 'ida.jansson@example.com', '1995-08-20'),
('Jakob Olsson', 'jakob.olsson@example.com', '1993-12-08'),
('Katarina Jonsson', 'katarina.jonsson@example.com', '1997-03-04'),
('Leo Ek', 'leo.ek@example.com', '1996-04-21'),
('Matilda Hedlund', 'matilda.hedlund@example.com', '1992-10-28'),
('Niklas Hermansson', 'niklas.hermansson@example.com', '1993-01-22'),
('Olivia Stenberg', 'olivia.stenberg@example.com', '1997-11-14'),
('Patrik Ågren', 'patrik.agren@example.com', '1991-09-07'),
('Quincy Nordström', 'quincy.nordstrom@example.com', '1995-02-19'),
('Rasmus Lindgren', 'rasmus.lindgren@example.com', '1998-06-23'),
('Sofia Sandberg', 'sofia.sandberg@example.com', '1994-12-12'),
('Tove Westberg', 'tove.westberg@example.com', '1996-07-11'),
('Urban Falk', 'urban.falk@example.com', '1993-03-29'),
('Vera Åkerlund', 'vera.akerlund@example.com', '1995-01-30'),
('William Sjöström', 'william.sjostrom@example.com', '1996-08-25'),
('Zelda Rydberg', 'zelda.rydberg@example.com', '1992-11-02');

-- Fyll på Teachers-tabellen med 5 lärare
INSERT INTO Teachers (Name, Email) VALUES
('Gustav Bodell', 'gustav@example.com'),
('Krister Trangius', 'krister@example.com'),
('Karin Andersson', 'karin.andersson@example.com'),
('Lisa Nilsson', 'lisa.nilsson@example.com'),
('Olof Johansson', 'olof.johansson@example.com');

-- Fyll på Courses-tabellen med kurser
INSERT INTO Courses (Name, Credits, TeacherId) VALUES
('OOP med C# del 1', 7.5, 1),
('Databaser SQL', 7.5, 2),
('Testning', 7.5, 1),
('OOP med C# del 2', 7.5, 1),
('Webbdesign', 7.5, 4),
('LIA', 15, 5),
('Apputveckling', 7.5, 2),
('Systemutveckling', 7.5, 3);

-- Fyll på Enrollments-tabellen med studenter som är registrerade på kurser och har betyg
INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDate, Grade) VALUES
(1, 1, '2022-04-01', 'VG'),
(1, 2, '2022-09-05', 'G'),
(1, 3, '2022-04-18', 'VG'),
(10, 5, '2023-04-01', 'G'),
(8, 6, '2022-09-05', 'G'),
(13, 1, '2022-04-18', 'G'),
(17, 1, '2022-04-19', 'VG'),
(7, 8, '2022-09-20', 'G'),
(10, 2, '2023-03-05', 'IG'),
(20, 2, '2023-10-06', 'G'),
(29, 4, '2022-03-16', 'G'),
(8, 8, '2022-04-14', 'G'),
(25, 2, '2023-05-16', 'VG'),
(12, 6, '2022-12-29', 'VG'),
(14, 5, '2023-01-10', 'IG'),
(6, 6, '2022-03-25', 'IG'),
(26, 1, '2022-08-26', 'VG'),
(18, 2, '2022-09-05', 'G'),
(19, 4, '2022-03-04', 'G'),
(4, 7, '2022-01-08', 'VG'),
(24, 4, '2023-11-01', 'G'),
(28, 6, '2023-08-22', 'G'),
(27, 4, '2023-08-01', 'VG'),
(18, 8, '2022-04-13', 'VG'),
(10, 7, '2022-11-30', 'VG'),
(3, 7, '2023-08-15', 'G'),
(13, 4, '2023-08-30', 'IG'),
(18, 8, '2022-05-21', 'G'),
(23, 2, '2022-11-03', 'VG'),
(19, 7, '2022-03-29', 'IG'),
(6, 4, '2023-08-01', 'VG'),
(14, 4, '2023-08-26', 'G'),
(8, 7, '2022-03-19', 'G'),
(29, 7, '2022-08-27', 'G'),
(27, 4, '2022-09-26', 'G'),
(9, 3, '2023-03-13', 'G'),
(19, 8, '2023-09-02', 'G'),
(2, 1, '2022-12-24', 'G'),
(3, 7, '2022-03-22', 'VG'),
(16, 6, '2023-11-13', 'G'),
(22, 2, '2022-10-21', 'G'),
(15, 3, '2022-02-12', 'VG'),
(7, 4, '2022-05-26', 'VG'),
(23, 8, '2022-08-18', 'G'),
(11, 8, '2022-05-12', 'G'),
(28, 5, '2023-09-17', 'G'),
(17, 3, '2023-04-29', 'IG'),
(4, 6, '2023-05-23', 'G'),
(14, 3, '2023-01-27', 'G'),
(1, 6, '2022-12-20', 'G'),
(10, 4, '2022-10-28', 'G'),
(25, 5, '2023-04-02', 'VG'),
(12, 2, '2022-10-25', 'IG'),
(7, 5, '2023-08-15', 'G'),
(6, 1, '2022-02-06', 'G'),
(4, 4, '2022-08-11', 'G'),
(4, 4, '2023-02-06', 'G'),
(27, 8, '2022-11-06', 'G'),
(16, 6, '2022-06-04', 'VG'),
(18, 7, '2022-08-21', 'G'),
(3, 6, '2022-09-15', 'IG'),
(28, 8, '2023-08-30', 'G'),
(13, 4, '2023-10-08', 'G'),
(2, 3, '2023-12-08', 'G'),
(19, 1, '2023-11-19', 'VG'),
(9, 2, '2023-01-23', 'G'),
(23, 8, '2022-01-17', 'G'),
(25, 1, '2023-05-21', 'VG'),
(29, 5, '2023-03-15', 'G'),
(24, 6, '2023-08-03', 'IG'),
(13, 6, '2023-05-30', 'IG'),
(9, 6, '2023-11-30', 'G'),
(17, 3, '2023-05-21', 'VG'),
(27, 5, '2022-09-05', 'VG'),
(10, 5, '2023-04-01', 'VG'),
(24, 5, '2022-05-01', 'G'),
(28, 8, '2022-11-02', 'IG'),
(22, 1, '2022-04-17', 'G'),
(11, 3, '2022-12-18', 'G'),
(26, 8, '2023-11-14', 'VG'),
(5, 6, '2023-01-29', 'IG'),
(22, 6, '2022-02-13', 'G'),
(16, 3, '2022-01-12', 'G'),
(14, 1, '2022-04-19', 'VG'),
(10, 5, '2022-02-10', 'VG'),
(6, 6, '2023-04-10', 'G'),
(25, 3, '2022-11-09', 'VG'),
(5, 1, '2023-08-22', 'G'),
(21, 7, '2022-11-20', 'G'),
(24, 6, '2022-06-02', 'G'),
(26, 3, '2022-11-17', 'VG'),
(27, 5, '2022-06-28', 'VG'),
(8, 5, '2022-05-09', 'G'),
(3, 6, '2022-08-15', 'G'),
(21, 5, '2023-12-09', 'IG'),
(27, 1, '2023-09-21', 'G'),
(17, 3, '2022-07-29', 'VG'),
(9, 3, '2023-07-15', 'VG'),
(26, 4, '2023-01-31', 'VG'),
(12, 4, '2023-05-10', 'VG'),
(12, 2, '2023-11-18', 'G'),
(9, 5, '2022-07-22', 'VG'),
(6, 6, '2023-04-23', 'VG');

