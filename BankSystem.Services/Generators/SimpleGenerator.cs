using System.Globalization;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

public class SimpleGenerator : IUniqueNumberGenerator
{
    private int lastNumber = 1234567890;

    public static SimpleGenerator Instance { get; private set; }

    private SimpleGenerator()
    {
    }

    static SimpleGenerator()
    {
        Instance = new SimpleGenerator();
    }

    public string Generate()
    {
        var hashed = this.lastNumber.ToString(CultureInfo.InvariantCulture).GenerateHash();
        this.lastNumber++;
        return hashed;
    }
}
