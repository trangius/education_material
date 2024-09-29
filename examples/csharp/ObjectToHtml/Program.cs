class Program
{
    static void Main(string[] args)
    {
        // Vi skapar en lista med personer och fyller på innehåll.
        // I verkligheten så skulle denna lista kanske matas in av användare och
        // troligen sparas i en databas eller så.
        // Vi vill återanvända denna person i helt valfria användargränssnitt.
        List<Person> plist = new List<Person>();
        Person p = new Person("Kalle", "9009121234", "Storgatan 5. 41455 Goteborg");
        plist.Add(p);
        p = new Person("Lisa", "13412341234", "Strumpgatan 3. 33055 Boras");
        plist.Add(p);
        
        // LAGER. Här kör vi med consolen som user interface
        for(int i = 0; i < plist.Count; i++)
        {
            ConsoleUI.PrintPerson(plist[i]);
        }
        
        // LAGER. Här genererar vi en html-fil som man kan titta på i webbläsare
        string html = "<html><body>";
        for(int i = 0; i < plist.Count; i++)
        {
            html += GenerateHTML.GeneratePerson(p);
        }
        html += "</body></html>";
        File.WriteAllText("hemsida.html", html);
    }
}