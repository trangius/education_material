using Microsoft.EntityFrameworkCore;	 // Innehåller klasser för Entity Framework Core
using Microsoft.Extensions.Logging;

public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    static void LogWithColor(string output)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(output);
        Console.ResetColor();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = File.ReadAllText("connectionString.txt");
        // Ange din anslutningssträng här
        // logga ut SQL-queryn som EF genererar till konsolen
        optionsBuilder.UseSqlServer(connectionString).EnableSensitiveDataLogging(true).LogTo(LogWithColor, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definiera RELATIONER och BEGRÄNSNINGAR om det behövs
        // EF gissar ofta rätt men ibland blir det fel, då kan vi ställa in här.
        // se: https://learn.microsoft.com/en-us/ef/core/modeling/relationships/conventions
        //
        // Här kommer lite exempel:
        //
        // RELATIONS
        // modelBuilder.Entity<Student>()
        //    .HasMany(s => s.Enrollments)
        //    .WithOne(e => e.Student);
        //
        //
        // KEYS
        // MANY TO MANY KEYS
        // eftersom studenterna ska kunna gå en kurs flera gånger och då få olika betyg
        // så har vi ett id  iden tabellen. Annars skulle man kunna göra såhär:
        // modelBuilder.Entity<Enrollment>()
        //     .HasKey(e => new { e.StudentId, e.CourseId });
        // Detta om vi har två id-fält som utgör en nyckel.
        //
        // 
        // UNIQUE
        // modelBuilder.Entity<Student>()
        //     .HasIndex(s => s.Email)
        //     .IsUnique();
        //
        //
        // DEFAULT VALUE
        // modelBuilder.Entity<Course>()
        //     .Property(c => c.Credits)
        //     .HasDefaultValue(0);
        //
        //
        // IGNORE PROPERTY
        // den här propertyn kommer inte att mappas i databasen utan bara finnas i klassen:
        // modelBuilder.Entity<Student>()
        //     .Ignore(s => s.SomeUnmappedProperty);
        //
        //
        // ETC...
        // Det finns såklart många fler inställningar man kan göra
    }

}
