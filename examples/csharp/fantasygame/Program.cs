// Huvudprogrammet
static class Program
{
    static void Main(string[] args)
    {
        int playerHealth = 500; // sätt spelarens starthälsa

        // skapa en lista med magiker (fiender)
        // TODO: denna lista ska innehålla alla möjliga typer av fiender
        List<ICharacter> characters = new List<ICharacter>();
        characters.Add(new Mage("Saruman"));
        characters.Add(new Assassin("Hitman"));
        characters.Add(new Mage("Sauron"));
        characters.Add(new Assassin("James Bond"));
        
        Merchant merchant = new Merchant("Kjell");
        merchant.Inventory.Add(new Item { Name = "Hälsopotion", Price = 50, Damage = 0, Armor = 0, Health = 50 });
        merchant.Inventory.Add(new Item { Name = "Eldpotion", Price = 50, Damage = 50, Armor = 0, Health = 0 });
        characters.Add(merchant);
        
        merchant = new Merchant("Clas");
        merchant.Inventory.Add(new Item { Name = "Svärd", Price = 100, Damage = 10, Armor = 0, Health = 0 });
        merchant.Inventory.Add(new Item { Name = "Sköld", Price = 100, Damage = 0, Armor = 10, Health = 0 });
        characters.Add(merchant);

        // spelloop - spelet körs så länge spelaren har hälsa kvar
        while(playerHealth > 0)
        {
            // Skriv ut en meny
            Console.WriteLine("========================================");
            Console.WriteLine($"Du har {playerHealth} hälsa");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Det finns följande fiender:");
            List<int> invisibleEnemyIndexes = new List<int>();
            for(int i = 0; i < characters.Count; i++)
            {
                if(characters[i].GetInfo() != null) // kontrolerar så att fienden är synlig
                {
                    Console.WriteLine($"{(i+1)}.  {characters[i].GetInfo()}"); // skriv ut den synliga fienden
                }
                else // detta är en osynlig fiende (den returnerade "")
                { 
                    // Ingen utskrift här...
                    invisibleEnemyIndexes.Add(i); // lägg till indexet i listan med osynliga fiender
                }
            }
            Console.WriteLine("---------------------------");
            Console.WriteLine("Välj vad du vill göra:");
            Console.WriteLine("1. Attackera");
            Console.WriteLine("2. Heala");
            Console.WriteLine("3. Interagera med NPC");
            Console.WriteLine("4. Avsluta");
            Console.Write("Ange alternativ 1-3:");
            string input = Console.ReadLine();

            Random random = new Random(); // används för att slumpa skada och häloregenerering
            switch(input)
            {
                case "1": // Attackera en viss fiende
                    Console.Write("Vilken fiende vill du attackera:");
                    // läs in vem spelaren vill attackera,
                    // tag värde -1 för att få rätt index i listan
                    int enemyIndex = int.Parse(Console.ReadLine())-1;
                    // om spelaren valt en osynlig fiende, skriv ut felmeddelande och hoppa ur switchen
                    if(invisibleEnemyIndexes.Contains(enemyIndex))
                    {
                        Console.WriteLine("Du kan inte attackera en osynlig fiende");
                        break;
                    }
                    // ge fienden skada:
                    int damage = 20 + random.Next(0, 20);
                    Console.WriteLine($"Du attackerar {characters[enemyIndex].Name} för {damage} skada");
                    if(characters[enemyIndex] is IDefender defender)
                        defender.Defend(damage); // polymorfi, kallar på Defender-metoden som är olika i olika fiender
                    break;

                case "2": // Heala sig själv
                    Console.WriteLine("Du healar dig själv");
                    playerHealth += 50 + random.Next(0, 50);
                    break;

                case "3": // Interagera med NPC
                    Console.WriteLine("Vilken NPC vill du interagera med");
                    // skriv ut alla characters som är av typen NPC
                    for(int i = 0; i < characters.Count; i++)
                    {
                        if(characters[i] is INPC npcx)
                            Console.WriteLine($"{(i+1)}. {characters[i].Name}");
                    }
                    // och låt spelaren ange vilken hen vill interagera med
                    int npcIndex = int.Parse(Console.ReadLine())-1;

                    // kontrollera att det fakiskt är en NPC
                    if(characters[npcIndex] is INPC npc)
                        npc.Interact(); // interagera!
                    else
                        Console.WriteLine("Detta är ingen NPC");

                    break;

                case "4": // Avsluta spelet
                    Console.WriteLine("Du avslutar spelet");
                    return;

                default:
                    Console.WriteLine("Felaktig input");
                    break;
            }

            // ---------------------------------------------
            // Gå igenom alla fiender, en efter en och:
            //
            // OM:      en fiende har 0 eller mindre hälsa, skriv att den är död
            //          och ta bort den ur listan
            // 
            // ANNARS   låt fienden attackera spelaren 
            // ---------------------------------------------
            for(int i = 0; i < characters.Count; i++)
            {
                // om fienden har 0 eller mindre hälsa, döda den
                if(characters[i].Health <= 0)
                {
                    Console.WriteLine($"{characters[i].Name} dog");
                    // ta bort fienden från listan utifrån dess index
                    characters.RemoveAt(i);

                    // i och med att denna fiende tas bort från listan så kommer 
                    // alla andra fiender att flyttas ett steg uppåt i listan
                    // Därför måste vi minska i med 1 för att inte hoppa över en fiende
                    i--;
                    // Vi hoppar över resten av loopen och går till nästa iteration.
                    continue;
                }
                // om vi inte kör continue ovan, riskerar vi att hamna out of bounds
                // , på sista elementet

                // Fienden gör sin attack på spelaren:
                if(characters[i] is IAttacker attacker)
                    playerHealth -= attacker.Attack(); // polymorfism, kallar på Attack-metoden som är olika i olika fiender
            }

            // ---------------------------------------------
            // Kontrollera om spelaren har dött, isf avsluta mainloopen
            if(playerHealth <= 0)
            {
                Console.WriteLine("Du dog.");
                break;
            }

            // Vänta på att användaren ska trycka på en tangent och rensa skärmen
            Console.ReadKey();
            Console.Clear();
        }
        Console.WriteLine("Spelet är slut");
    }
}