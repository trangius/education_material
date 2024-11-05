class Program
{
    static void Main(string[] args)
    {
        // Definiera en delegat som tar två indata: en Product och en int, och returnerar en decimal
        Func<Product, int, decimal> calculateTotalCost = delegate(Product p, int quantity)
        {
            return p.Price * quantity;
        };

        // Skapa en produkt
        Product laptop = new Product { Name = "Laptop", Price = 1499.99m };
        Product headphones = new Product { Name = "Headphones", Price = 199.99m };

        // Anropa delegaten och spara resultatet
        decimal laptopTotal = calculateTotalCost(laptop, 3);
        decimal headphonesTotal = calculateTotalCost(headphones, 5);

        // Skriv ut totalkostnaderna
        Console.WriteLine($"Total cost for 3 Laptops: ${laptopTotal}");
        Console.WriteLine($"Total cost for 5 Headphones: ${headphonesTotal}");
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
