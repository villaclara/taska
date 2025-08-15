namespace BankSystem.Services.Generators;

internal class SimpleGenerator : IUniqueNumberGenerator
{
    private int lastNumber;

    public static SimpleGenerator Instance { get; private set; }

    private SimpleGenerator()
    {
        Instance ??= new SimpleGenerator();
    }

    static SimpleGenerator()
    {
        Instance = new SimpleGenerator();
    }

    public string Generate()
    {
        throw new NotImplementedException();
    }
}
