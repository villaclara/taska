using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public class SilverAccount : BankAccount
{
    public override decimal OverDraft
    {
        get => 2 * this.BonusPoints;
        set => throw new NotSupportedException("OverDraft is a calculated value and cannot be set manually.");
    }


    private const int SilverDepositCostPerPoint = 5;
    private const int SilverWithdrawCostPerPoint = 2;
    private const int SilverBalanceCostPerPoint = 100;

    public SilverAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator) : base(owner, currencyCode, uniqueNumberGenerator)
    { }

    public SilverAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator) : base(owner, currencyCode, numberGenerator)
    { }

    public SilverAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
        : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    { }

    public SilverAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
        : base(owner, currencyCode, numberGenerator, initialBalance)
    { }

    protected override int CalculateDepositRewardPoints(decimal amount)
    {
        return (int)Math.Max(decimal.Floor(this.Balance / SilverBalanceCostPerPoint) + decimal.Floor(amount / SilverDepositCostPerPoint), 0);
    }

    protected override int CalculateWithdrawRewardPoints(decimal amount)
    {
        return (int)Math.Max(decimal.Floor(this.Balance / SilverBalanceCostPerPoint) + decimal.Floor(amount / SilverWithdrawCostPerPoint), 0);
    }
}
