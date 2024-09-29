// Används för att generera HTML-kod till allt i programmet.
// Just nu finns bara kod för en person, men man kan såklart fylla på med alla
// möjliga objekt.
static class GenerateHTML
{
    public static string GeneratePerson(Person person)
    {
        string html = "<h1>Info about the person.</h1>";
        html += $"<p>Name: {person.Name}</p>";
        html += $"<p>Personal nr: {person.PersonalNr}</p>";
        html +=  $"<p>Address: {person.Address}</p>";
        return html;
    }
}