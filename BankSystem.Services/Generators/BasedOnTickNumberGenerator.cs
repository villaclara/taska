using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

public class BasedOnTickUniqueNumberGenerator : IUniqueNumberGenerator
{
    public DateTime startingPoint { get; init; }

    public BasedOnTickUniqueNumberGenerator(DateTime startingPoint)
    {
        this.startingPoint = startingPoint;
    }

    public string Generate()
    {
        var ticks = DateTime.UtcNow - this.startingPoint;
        return ticks.ToString().GenerateHash();
    }
}
