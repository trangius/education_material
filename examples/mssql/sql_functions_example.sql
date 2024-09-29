-- COUNT(): Räknar antalet rader i en kolumn eller grupp
SELECT COUNT(*) AS TotalStudents
FROM Students;


-- SUM(): Summerar värdena i en kolumn
SELECT Students.Name, SUM(Courses.Credits) AS TotalCredits
FROM Students
JOIN Enrollments ON Students.Id = Enrollments.StudentId
JOIN Courses ON Enrollments.CourseId = Courses.Id
WHERE Students.Id = 1 -- Ändra "1" till den specifika studentens Id
GROUP BY Students.Name;


-- AVG(): Beräknar medelvärdet av en kolumns värden
SELECT Students.Name, AVG(Courses.Credits) AS AverageCredits
FROM Students
JOIN Enrollments ON Students.Id = Enrollments.StudentId
JOIN Courses ON Enrollments.CourseId = Courses.Id
GROUP BY Students.Name; -- grupperar resultatet per student för att visa medelvärdet för den valda studenten.


-- MIN(): Returnerar det minsta värdet i en kolumn
SELECT MIN(Credits) AS MinCredits
FROM Courses;


-- MAX(): Returnerar det största värdet i en kolumn
SELECT MAX(Credits) AS MaxCredits
FROM Courses;


-- UPPER(): Konverterar text i en kolumn till stora bokstäver
SELECT UPPER(Name) AS UpperCaseName
FROM Students;


-- UPPER(): Konverterar text i en kolumn till små bokstäver
SELECT LOWER(Name) AS UpperCaseName
FROM Students;


-- ROUND(): Avrundar ett numeriskt värde till ett specifikt antal decimaler
SELECT ROUND(AVG(Credits), 2) AS RoundedAverageCredits
FROM Courses;


-- GETDATE(): Returnerar aktuell datum och tid
SELECT GETDATE() AS CurrentDateTime;


-- CAST()+GETDATE() för att hämta endast datum
SELECT CAST(GETDATE() AS DATE) AS CurrentDate;


-- CAST()+GETDATE() för att hämta endast tid
SELECT CAST(GETDATE() AS TIME) AS CurrentTime;
