-- Desas är bättre som heltal än strängar. Börja med att uppdatera Grade-kolumnen...
UPDATE Enrollments
SET Grade = CASE
   WHEN Grade = 'IG' THEN '0'
   WHEN Grade = 'G' THEN '1'
   WHEN Grade = 'VG' THEN '2'
   ELSE NULL  -- Hanterar eventuell NULL eller okända betyg.
              -- Dubbelkolla så kolumnen tillåter NULL-värde.
END;

-- konvertera till heltal, vi behåller de satta värdena från ovan. Fiffigt
ALTER TABLE Enrollments
ALTER COLUMN Grade INT;
