// C# exempel på komposition
// Klass som representerar en dokumentbehandlare som kan utföra olika operationer på ett dokument
class DocumentProcessor
{
    public string DocumentName { get; set; }
    // Lista med operations. Denna kan fyllas på med olika typer av operationer som vi vill utföra på olika dokument etc:
    public List<IFileOperation> Operations { get; set; } = new List<IFileOperation>();

    public DocumentProcessor(string documentName)
    {
        DocumentName = documentName;
    }

    // Utför alla filoperationer i listan på dokumentet
    public void ProcessDocument()
    {
        Console.WriteLine($"Bearbetar dokument: {DocumentName}");
        foreach (var operation in Operations)
        {
            operation.Execute(DocumentName);
        }
    }
}

// Interface för filoperationer som kan utföras på ett dokument
// Ett interface för filoperationer. Dnna kan implementeras av olika faktiska oereationer
// (se nedan) och säger bara att de måste ha en metod Execute().
interface IFileOperation
{
    void Execute(string documentName);
}

// Exempel på fyra olika filoperationer
class PdfExport : IFileOperation
{
    public void Execute(string documentName)
    {
        Console.WriteLine($"Exporterar {documentName} som PDF 📝");
    }
}

class ImageCompression : IFileOperation
{
    public void Execute(string documentName)
    {
        Console.WriteLine($"Komprimerar bilder i {documentName} 📷");
    }
}

class TextConversion : IFileOperation
{
    public void Execute(string documentName)
    {
        Console.WriteLine($"Konverterar text i {documentName} till enklare format 📄");
    }
}

class SpellCheck : IFileOperation
{
    public void Execute(string documentName)
    {
        Console.WriteLine($"Utför stavningskontroll på {documentName} ✏️");
    }
}

// Huvudprogram
class Program
{
    static void Main(string[] args)
    {
        // Skapa en dokumentbehandlare för en rapport och lägg till operationer
        DocumentProcessor reportProcessor = new DocumentProcessor("Årsrapport 2023");
        reportProcessor.Operations.Add(new PdfExport());
        reportProcessor.Operations.Add(new SpellCheck());
        reportProcessor.Operations.Add(new TextConversion());

        // Bearbeta dokumentet med alla valda operationer
        reportProcessor.ProcessDocument();

        // Skapa en dokumentbehandlare för en presentation och lägg till operationer
        DocumentProcessor presentationProcessor = new DocumentProcessor("Marknadsplan");
        presentationProcessor.Operations.Add(new PdfExport());
        presentationProcessor.Operations.Add(new ImageCompression());

        // Bearbeta dokumentet med alla valda operationer
        presentationProcessor.ProcessDocument();
    }
}
