using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public class GoldAccount : BankAccount
{
    private const int GoldDepositCostPerPoint = 10;
    private const int GoldWithdrawCostPerPoint = 5;
    private const int GoldBalanceCostPerPoint = 5;
    public override decimal OverDraft
    {
        get => 3 * this.BonusPoints;
        set => throw new NotSupportedException("OverDraft is a calculated value and cannot be set manually.");
    }
    public GoldAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator) : base(owner, currencyCode, uniqueNumberGenerator)
    { }

    public GoldAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator) : base(owner, currencyCode, numberGenerator)
    { }

    public GoldAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
        : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    { }

    public GoldAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
        : base(owner, currencyCode, numberGenerator, initialBalance)
    { }
    protected override int CalculateDepositRewardPoints(decimal amount)
    {
        return (int)Math.Max(decimal.Floor(this.Balance / GoldBalanceCostPerPoint) + decimal.Floor(amount / GoldDepositCostPerPoint), 0);
    }

    protected override int CalculateWithdrawRewardPoints(decimal amount)
    {
        return (int)Math.Max(decimal.Floor(this.Balance / GoldBalanceCostPerPoint) + decimal.Floor(amount / GoldWithdrawCostPerPoint), 0);
    }
}
