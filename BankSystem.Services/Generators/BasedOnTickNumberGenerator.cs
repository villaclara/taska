namespace BankSystem.Services.Generators;

internal class BasedOnTickUniqueNumberGenerator : IUniqueNumberGenerator
{
    public DateTime startingPoint { get; init; }

    public BasedOnTickUniqueNumberGenerator(DateTime startingPoint)
    {
        this.startingPoint = startingPoint;
    }

    public string Generate()
    {
        throw new NotImplementedException();
    }
}
