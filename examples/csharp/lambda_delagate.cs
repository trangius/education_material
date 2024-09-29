class Program
{
    public static void RegularMethod(int x)
    {
        Console.WriteLine("RegularMethod: " + x);
    }
    static void Main()
    {
        MyMethod(RegularMethod);
        
        MyMethod(delegate(int x){Console.WriteLine("delegate: " + x);});

        MyMethod(x=>Console.WriteLine("lambda: " + x));
    }

    static void MyMethod(Action<int> yourMethod)
    {
        yourMethod(100);
    }
}
