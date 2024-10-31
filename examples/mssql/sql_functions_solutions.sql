-- 1. Hämta medelbetyget för en viss student
-- Detta query beräknar medelvärdet av betygen för en specifik student.
SELECT AVG(CAST(Enrollments.Grade AS FLOAT)) AS AverageGrade
FROM Students
JOIN Enrollments ON Students.Id = Enrollments.StudentId
WHERE Students.Id = 1; -- Ändra "1" till den specifika studentens Id

-- 2. Hämta medelbetyget för en viss kurs
-- Detta query beräknar medelvärdet av betygen för alla studenter i en specifik kurs.
SELECT AVG(CAST(Enrollments.Grade AS FLOAT)) AS AverageGrade
FROM Courses
JOIN Enrollments ON Courses.Id = Enrollments.CourseId
WHERE Courses.Id = 3; -- Ändra "3" till den specifika kursens Id

-- 3. Hämta den totala mängden kurser som en viss student har tagit
-- Detta query räknar antalet kurser som en viss student har tagit.
SELECT COUNT(Enrollments.CourseId) AS TotalCourses
FROM Students
JOIN Enrollments ON Students.Id = Enrollments.StudentId
WHERE Students.Id = 1; -- Ändra "1" till den specifika studentens Id


-- 4. Hämta medelbetyget för alla kurser
-- Detta query beräknar medelvärdet av betygen för alla kurser.
SELECT Courses.Name, AVG(CAST(Enrollments.Grade AS FLOAT)) AS AverageGrade
FROM Courses
JOIN Enrollments ON Courses.Id = Enrollments.CourseId
GROUP BY Courses.Id, Courses.Name;

-- 5. Hämta vilken kurs som har högsta medelbetyget
-- Detta query hämtar den kurs som har högsta genomsnittliga betyget.
SELECT TOP 1 Courses.Name, AVG(CAST(Enrollments.Grade AS FLOAT)) AS AverageGrade
FROM Courses
JOIN Enrollments ON Courses.Id = Enrollments.CourseId
GROUP BY Courses.Id, Courses.Name
ORDER BY AverageGrade DESC;

-- 6. Hämta studenter som har fått underkänt i någon kurs (deras namn och kurs)
-- skolan vill veta vilka som behöver extra stöd
-- Detta query hämtar alla studenter som har fått det betyget.
SELECT Students.Name, Courses.Name
FROM Students
JOIN Enrollments ON Students.Id = Enrollments.StudentId
JOIN Courses ON Enrollments.CourseId = Courses.Id
WHERE Enrollments.Grade = 0; 

-- 7. Hämta alla studenter som har fått högsta betyget i alla sina kurser
-- Detta query hämtar studenter som har fått maxbetyg i alla sina registrerade kurser.
SELECT Students.Name
FROM Students
JOIN Enrollments ON Students.Id = Enrollments.StudentId
GROUP BY Students.Id, Students.Name
HAVING MIN(Enrollments.Grade) = 2; -- Ändra 2 om ett annat maxbetyg gäller

-- 8. Hämta antalet studenter i varje kurs
-- Detta query räknar hur många studenter som är registrerade i varje kurs.
SELECT Courses.Name, COUNT(Enrollments.StudentId) AS TotalStudents
FROM Courses
JOIN Enrollments ON Courses.Id = Enrollments.CourseId
GROUP BY Courses.Id, Courses.Name;

-- 9. Hämta en lista med alla studenter och deras respektive medelsnittsbetyg,
-- sortera på snittet med med högst längst upp
SELECT Students.Name, AVG(CAST(Enrollments.Grade AS FLOAT)) AS AverageGrade
FROM Students
JOIN Enrollments ON Students.Id = Enrollments.StudentId
GROUP BY Students.Id, Students.Name
ORDER BY AverageGrade DESC;

-- 10. Samma som 9 men med top 5
SELECT TOP 5 Students.Name, AVG(CAST(Enrollments.Grade AS FLOAT)) AS AverageGrade
FROM Students
JOIN Enrollments ON Students.Id = Enrollments.StudentId
GROUP BY Students.Id, Students.Name
ORDER BY AverageGrade DESC;
