// Värde-typ
struct MyStruct
{
    public int value;
}

// Referens-typ
class MyClass
{
    public int value;
}

class Program
{
    static void Main()
    {
        MyStruct a;
        a.value = 5;
        Console.WriteLine(a.value);
        MyStruct b = a;
        b.value = 10;
        Console.WriteLine(a.value); // a.Value är fortfarande 5 eftersom b är en separat kopia

	MyClass x = new MyClass();
        x.value = 5;
        Console.WriteLine(x.value);
        MyClass y = x;
        y.value = 10;
        Console.WriteLine(x.value);
        // x.Value är nu också 10 eftersom y refererar till samma objekt som x
    }
}
