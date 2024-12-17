-- EXEMEPEL för att byta från en tabell med en id-kolumn till en tabell med en composite primary key


-- hämta ut namnet på den prmary key constraint som redan finns
SELECT 
    name AS ConstraintName
FROM 
    sys.key_constraints
WHERE 
    type = 'PK' 
    AND OBJECT_NAME(parent_object_id) = 'Enrollments';

-- ta bort PK-constrainten
ALTER TABLE Enrollments
DROP CONSTRAINT PK__Enrollme__7F6877FB11E8DC2E; -- byt ut här till vad du får ut av selecten ovan

-- ta bort kolumnen för id
ALTER TABLE Enrollments DROP COLUMN EnrollmentID;

-- gör så de kolumner som ska bli id inte är nullbara
ALTER TABLE Enrollments
ALTER COLUMN StudentId INT NOT NULL;

ALTER TABLE Enrollments
ALTER COLUMN CourseId INT NOT NULL;

-- lägg till den nya constrainten
ALTER TABLE Enrollments
ADD CONSTRAINT PK_Enrollment PRIMARY KEY (StudentId, CourseId);
