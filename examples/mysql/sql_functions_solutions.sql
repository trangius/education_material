-- 1. Hämta medelbetyget för en viss student
-- Detta query beräknar medelvärdet av betygen för en specifik student.
SELECT AVG(Enrollment.Grade) AS AverageGrade
FROM Student
JOIN Enrollment ON Student.Id = Enrollment.StudentId
WHERE Student.Id = 5; -- Ändra 5 till den specifika studentens Id

-- 2. Hämta medelbetyget för en viss kurs
-- Detta query beräknar medelvärdet av betygen för alla studenter i en specifik kurs.
SELECT AVG(Enrollment.Grade) AS AverageGrade
FROM Course
JOIN Enrollment ON Course.Id = Enrollment.CourseId
WHERE Course.Id = 3; -- Ändra "3" till den specifika kursens Id


-- 3. Hämta den totala mängden kurser som en viss student har tagit
-- Detta query räknar antalet kurser som en viss student har tagit.
SELECT COUNT(Enrollment.CourseId) AS TotalCourse
FROM Student
JOIN Enrollment ON Student.Id = Enrollment.StudentId
WHERE Student.Id = 1; -- Ändra "1" till den specifika studentens Id


-- 4. Hämta medelbetyget för alla kurser
-- Detta query beräknar medelvärdet av betygen för alla kurser.
SELECT Course.Name, AVG(Enrollment.Grade) AS AverageGrade
FROM Course
JOIN Enrollment ON Course.Id = Enrollment.CourseId
GROUP BY Course.Id, Course.Name;

-- 5. Hämta vilken kurs som har högsta medelbetyget
-- Detta query hämtar den kurs som har högsta genomsnittliga betyget.
SELECT Course.Name, AVG(Enrollment.Grade) AS AverageGrade
FROM Course
JOIN Enrollment ON Course.Id = Enrollment.CourseId
GROUP BY Course.Id, Course.Name
ORDER BY AverageGrade DESC
LIMIT 1;

-- 6. Hämta studenter som har fått underkänt i någon kurs (deras namn och kurs)
-- skolan vill veta vilka som behöver extra stöd
-- Detta query hämtar alla studenter som har fått det betyget.
SELECT Student.Name, Course.Name
FROM Student
JOIN Enrollment ON Student.Id = Enrollment.StudentId
JOIN Course ON Enrollment.CourseId = Course.Id
WHERE Enrollment.Grade = 0; 

-- 7. Hämta alla studenter som har fått högsta betyget i alla sina kurser
-- Detta query hämtar studenter som har fått maxbetyg i alla sina registrerade kurser.
SELECT Student.Name
FROM Student
JOIN Enrollment ON Student.Id = Enrollment.StudentId
GROUP BY Student.Id, Student.Name
HAVING MIN(Enrollment.Grade) = 2; -- Ändra 2 om ett annat maxbetyg gäller

-- 8. Hämta antalet studenter i varje kurs
-- Detta query räknar hur många studenter som är registrerade i varje kurs.
SELECT Course.Name, COUNT(Enrollment.StudentId) AS TotalStudent
FROM Course
JOIN Enrollment ON Course.Id = Enrollment.CourseId
GROUP BY Course.Id, Course.Name;

-- 9. Hämta en lista med alla studenter och deras respektive medelsnittsbetyg,
-- sortera på snittet med med högst längst upp
SELECT Student.Name, AVG(Enrollment.Grade) AS AverageGrade
FROM Student
JOIN Enrollment ON Student.Id = Enrollment.StudentId
GROUP BY Student.Id, Student.Name
ORDER BY AverageGrade DESC;

-- 10. Samma som 9 men med top 5
SELECT Student.Name, AVG(Enrollment.Grade) AS AverageGrade
FROM Student
JOIN Enrollment ON Student.Id = Enrollment.StudentId
GROUP BY Student.Id, Student.Name
ORDER BY AverageGrade DESC
LIMIT 5;
