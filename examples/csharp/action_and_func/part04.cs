class Program
{
    static void Main(string[] args)
    {
        // Definiera en delegat som tar två indata: en Product och en int
        Action<Product, int> stockAction = delegate(Product p, int stock)
        {
            Console.WriteLine($"Product: {p.Name}");
            Console.WriteLine($"Price: ${p.Price}");
            Console.WriteLine($"In Stock: {stock} units");
        };

        // Anropa delegaten med två argument
        stockAction(new Product { Name = "Laptop", Price = 1499.99m }, 25);
        stockAction(new Product { Name = "Headphones", Price = 199.99m }, 50);
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
