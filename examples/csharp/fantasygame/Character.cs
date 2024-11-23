interface ICharacter
{
    string Name { get; set; }
    int Health { get; set; }
    int BaseDamage { get; set; }
    int Armor { get; set; }
    public string? GetInfo();
}

interface IAttacker
{
    int Attack();
}

interface IDefender
{
    void Defend(int damage);
}

interface INPC
{
    void Interact();
}

// En klass för att hålla reda på en lönnmördare
// Denna kan vi sen skapa flera lönnmördare (instanser) av
// Denna ärver av basklassen Enemy
class Assassin : ICharacter, IAttacker, IDefender
{
    // Egenskaper
    public string Name { get; set; }
    public int Health { get; set; }
    public int BaseDamage { get; set; }
    public int Armor { get; set; }

    // Förutom de egenskaper som finns i basklassen Enemy, har lönnmördaren möjligheten
    // att vara osynlig
    bool isVisible;

    // Konstruktor
    public Assassin(string name)
    {
        Random random = new Random();
        Health = 20 + random.Next(0, 80);
        BaseDamage = 20;
        Armor = 15;
        isVisible = false; // TODO: random på/av???
        Name = name;
    }

    // Ger information om lönnmördaren.
    public string? GetInfo()
    {
        if(isVisible)
            return $"Lönnmördaren {Name} smyger runt och har {Health} hälsa."; 
        else
            return null;
    }

    // lönnmördaren attackerar olika beroende på om den är synlig eller inte:
    public int Attack()
    {
        int damage;
        // if it is visible, it will attack
        Random random = new Random();
        
        if(isVisible)
        {
            damage = BaseDamage + random.Next(0, 30);
            Console.WriteLine($"{Name} hugger dig med sin vassa kniv och gör {damage} skada");
            isVisible = false;
            return damage;
        }
        else
        {
            damage = BaseDamage + random.Next(0, 10);
            Console.WriteLine($"någonstans ifrån kommer en pil som ger dig {damage} skada");
            isVisible = true;
            return damage;
        }
    }

    // lönnmördaren försvarar sig men bara om den är synlig, annars tar den ingen skada 
    public void Defend(int damage)
    {
        if(isVisible)
        {
            int totalDamage = damage - Armor;
            System.Console.WriteLine($"{Name} tar {totalDamage} skada");
            Health -= totalDamage;
        }
    }
}

// En klass för att hålla reda på en magiker.
// Denna kan vi sen skapa flera magiker (instanser) av
class Mage : ICharacter, IAttacker, IDefender
{
    // Egenskaper
    public string Name { get; set; }
    public int Health { get; set; }
    public int BaseDamage { get; set; }
    public int Armor { get; set; }
    public int Mana { get; set; }

    // konstruktor för att skapa magikern:
    public Mage(string name)
    {
        BaseDamage = 10;
        Random random = new Random();
        Health = 20 + random.Next(0, 80);
        Mana = 20 + random.Next(0, 80);
        Armor = 5;
        Name = name;
    }
    
    // Ger information om magikern.
    public string? GetInfo()
    {
        return $"Magikern {Name} står och mumlar för sig själv och har {Health} hälsa.";
    }
    
    // Magikern attackerar
    // return value - denna metod returnerar ett heltal som är skadan som magikern gör
    public int Attack()
    {
        int damage; // hur mycket skada ska magikern göra?

        // om magikern har mer än 10 mana, kan den kasta en eldboll
        // TODO: Lägg till fler attacker som vi slumpar emellan
        if(Mana > 10)
        {
            Random random = new Random();
            damage = BaseDamage + random.Next(0, 30);
            Console.WriteLine($"{Name} kastar en eldboll som gör {damage} skada");
            Mana -= 10;
        }
        else // magikern har inte tillräckligt med mana för att kasta en eldboll
        {
            Console.WriteLine($"{Name} har för lite mana för att kunna attackera");
            Mana += 5;
            damage = 0;
        }
        return damage;
    }

    // Magikern försvarar sig
    public void Defend(int damage)
    {
        Console.WriteLine("magikern kanstar ut en eldsköld ");
        int totalDamage = damage - Armor;
        System.Console.WriteLine($"{Name} tar {totalDamage} skada");
        Health -= totalDamage;
    }
}

class Item
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
    public int Health { get; set; }
}

class Merchant : ICharacter, INPC
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int BaseDamage { get; set; }
    public int Armor { get; set; }
    public List<Item> Inventory { get; set; }

    public Merchant(string name)
    {
        Name = name;
        Health = 100;
        BaseDamage = 0;
        Armor = 10;
        Inventory = new List<Item>();
    }

    public string? GetInfo()
    {
        return $"{Name} är en snäll handlare";
    }

    public void Interact()
    {
        Console.WriteLine("Hej! vad fint att du vill handla av mig!");
        for(int i = 0; i < Inventory.Count; i++)
        {
            Console.WriteLine($"{i+1}. {Inventory[i].Name} - {Inventory[i].Price} guld");
        }
        Console.Write("Ange vad du vill köpa:");
        int choice = int.Parse(Console.ReadLine())-1;
    }
}