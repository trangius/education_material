public class Employee
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime StartDate { get; set; }

    public Employee(int id, string firstName, string lastName, DateTime startDate)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        StartDate = startDate;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"{FirstName} {LastName}, ID: {ID}, Start Date: {StartDate}");
    }
}

public class FullTimeEmployee : Employee
{
    public decimal AnnualSalary { get; set; }

    public FullTimeEmployee(int id, string firstName, string lastName, DateTime startDate, decimal annualSalary)
        : base(id, firstName, lastName, startDate)
    {
        AnnualSalary = annualSalary;
    }

    public decimal CalculateMonthlySalary()
    {
        return AnnualSalary / 12;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Monthly Salary: {CalculateMonthlySalary()}");
    }
}

public class HourlyEmployee : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public HourlyEmployee(int id, string firstName, string lastName, DateTime startDate, decimal hourlyRate, int hoursWorked)
        : base(id, firstName, lastName, startDate)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public decimal CalculateWeeklySalary()
    {
        return HourlyRate * HoursWorked;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Weekly Salary: {CalculateWeeklySalary()}");
    }
}

public class Intern : Employee
{
    public string School { get; set; }
    public string Mentor { get; set; }

    public Intern(int id, string firstName, string lastName, DateTime startDate, string school, string mentor)
        : base(id, firstName, lastName, startDate)
    {
        School = school;
        Mentor = mentor;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"School: {School}, Mentor: {Mentor}");
    }
}
