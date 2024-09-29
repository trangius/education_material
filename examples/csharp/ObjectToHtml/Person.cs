// Enkel klass för att hantera en person
class Person
{
    public string Name{get; set;}
    public string PersonalNr{get; set;}
    public string Address{get; set;}

    public Person(string name, string personalNr, string address)
    {
        Name = name;
        PersonalNr = personalNr;
        Address = address;
    }
}