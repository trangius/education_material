-- COUNT(): Räknar antalet rader i en kolumn eller grupp
SELECT COUNT(*) AS TotalStudent
FROM Student;

-- SUM(): Summerar värdena i en kolumn
SELECT Student.Name, SUM(Course.Credits) AS TotalCredit
FROM Student
JOIN Enrollment ON Student.Id = Enrollment.StudentId
JOIN Course ON Enrollment.CourseId = Course.Id
WHERE Student.Id = 1
GROUP BY Student.Name;

-- AVG(): Beräknar medelvärdet av en kolumns värden
SELECT Student.Name, AVG(Enrollment.Grade) AS AverageGrade
FROM Student
JOIN Enrollment ON Student.Id = Enrollment.StudentId
JOIN Course ON Enrollment.CourseId = Course.Id
GROUP BY Student.Name;

-- MIN(): Returnerar det minsta värdet i en kolumn
SELECT MIN(Credits) AS MinCredit
FROM Course;

-- MAX(): Returnerar det största värdet i en kolumn
SELECT MAX(Credits) AS MaxCredit
FROM Course;

-- UPPER(): Konverterar text i en kolumn till stora bokstäver
SELECT UPPER(Name) AS UpperCaseName
FROM Student;

-- LOWER(): Konverterar text i en kolumn till små bokstäver
SELECT LOWER(Name) AS LowerCaseName
FROM Student;

-- ROUND(): Avrundar ett numeriskt värde till ett specifikt antal decimaler
SELECT ROUND(AVG(Credits), 2) AS RoundedAverageCredit
FROM Course;

-- Aktuellt datum och tid
SELECT NOW() AS CurrentDateTime;

-- Endast datum
SELECT CURDATE() AS CurrentDate;

-- Endast tid
SELECT CURTIME() AS CurrentTime;
