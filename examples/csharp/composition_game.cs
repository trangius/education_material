// C# exempel på komposition
// En klass för karaktärer
class Character
{
    public string Name { get; set; }
    public int Health { get; set; }

    // Lista med attacker. Denna kan fyllas på med olika typer av attacker för olika klasser/raser t.ex:
    public List<IAttack> Attacks { get; set; } = new List<IAttack>(); 
    private static Random random = new Random(); // Slumpgenerator

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    // Utför en slumpmässig attack från IAttack-listan
    public void ExecuteRandomAttack()
    {
        if (Attacks.Count == 0)
        {
            Console.WriteLine($"{Name} har inga attacker tillgängliga!");
            return;
        }

        int index = random.Next(Attacks.Count); // Välj ett slumpmässigt index
        Console.Write($"{Name} ");
        Attacks[index].ExecuteAttack();
    }
}

// Ett interface för attacker. Denna kan implementeras av olika attacker och säger bara
// att de måste ha en metod ExecuteAttack().
interface IAttack
{
    void ExecuteAttack();
}

// Exempel på fem olika attacker som implementerar interfacet IAttack
class Fireball : IAttack
{
    public void ExecuteAttack()
    {
        Console.WriteLine("kastar en eldklot! 🔥");
    }
}

class IceBlast : IAttack
{
    public void ExecuteAttack()
    {
        Console.WriteLine("slungar iväg en isexplosion! ❄️");
    }
}

class SwordSlash : IAttack
{
    public void ExecuteAttack()
    {
        Console.WriteLine("hugger med ett svärd! 🗡️");
    }
}

class SwordStab : IAttack
{
    public void ExecuteAttack()
    {
        Console.WriteLine("sticker med ett svärd! 🗡️");
    }
}

class Kick : IAttack
{
    public void ExecuteAttack()
    {
        Console.WriteLine("levererar en kraftig spark! 🦵");
    }
}

// Exempel på två olika karaktärstyper
class Mage : Character
{
    public Mage(string name) : base(name, health: 70)
    {
        // Mage har följande olika attacker:
        Attacks.Add(new Fireball());
        Attacks.Add(new IceBlast());
        Attacks.Add(new SwordSlash());
    }
}

class Warrior : Character
{
    public Warrior(string name) : base(name, health: 100)
    {
        // Warrior har också olika attacker:
        Attacks.Add(new SwordSlash());
        Attacks.Add(new SwordStab());
        Attacks.Add(new Kick());
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Skapa olika typer av karaktärer och lägg i en lista:
        var characters = new List<Character>
        {
            new Mage("Gandalf"),
            new Warrior("Aragorn")
        };
        
        foreach(var c in characters)
        {
            Console.WriteLine($"{c.Name} har {c.Health} hälsa.");
            c.ExecuteRandomAttack();
        }
    }
}
