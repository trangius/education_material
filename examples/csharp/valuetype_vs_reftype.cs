class MyClass
{
    public int value;
}

class Program
{
    static void Main()
    {
        // Ett heltal är en värdetyp, här illustreras hur det påverkar:
        int a = 5;
        System.Console.WriteLine(a);
        int b = a;
        b = 10;
        System.Console.WriteLine(a);

        // En klass är en referenstyp, här illustreras hur det påverkar:
        MyClass x = new MyClass();
        x.value = 5;
        Console.WriteLine(x.value);
        MyClass y = x;
        y.value = 10;
        Console.WriteLine(x.value);
        // x.Value är nu också 10 eftersom y refererar till samma objekt som x
    }
}
