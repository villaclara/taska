using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public class StandardAccount : BankAccount
{
    private const int StandardBalanceCostPerPoint = 100;
    public override decimal OverDraft
    {
        get { return 0; }
        set { }
    }

    public StandardAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator) : base(owner, currencyCode, uniqueNumberGenerator)
    { }

    public StandardAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator) : base(owner, currencyCode, numberGenerator)
    { }

    public StandardAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
        : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    { }

    public StandardAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
        : base(owner, currencyCode, numberGenerator, initialBalance)
    { }

    public override int CalculateDepositRewardPoints(decimal amount)
    {
        return (int)Math.Max(decimal.Floor(this.Balance / StandardBalanceCostPerPoint), 0);
    }

    public override int CalculateWithdrawRewardPoints(decimal amount)
    {
        return (int)Math.Max(decimal.Floor(this.Balance / StandardBalanceCostPerPoint), 0);
    }
}
