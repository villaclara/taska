using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

public abstract class BankAccount
{
    private readonly List<AccountCashOperation> _operations = [];
    public string Number { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyCode { get; set; }
    public AccountOwner AccountOwner { get; set; }
    public int BonusPoints { get; set; }
    public abstract decimal OverDraft { get; set; }

    protected BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator)
    {
        ArgumentNullException.ThrowIfNull(uniqueNumberGenerator);

        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Number = uniqueNumberGenerator.Generate();
    }
    protected BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
    {
        ArgumentNullException.ThrowIfNull(numberGenerator);

        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Number = numberGenerator();
    }
    protected BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
    {
        ArgumentNullException.ThrowIfNull(uniqueNumberGenerator);

        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Deposit(initialBalance, DateTime.Now, "Initial deposit");
        this.Number = uniqueNumberGenerator.Generate();
    }

    protected BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
    {
        ArgumentNullException.ThrowIfNull(numberGenerator);

        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Deposit(initialBalance, DateTime.Now, "Initial deposit");
        this.Number = numberGenerator();
    }
    public IList<AccountCashOperation> GetAllOperations() => this._operations;

    public void Deposit(decimal amount, DateTime dateTime, string message)
    {
        this.Balance += amount;
        this.BonusPoints += this.CalculateDepositRewardPoints(amount);
        this._operations.Add(new AccountCashOperation(amount, dateTime, message));
    }

    public void Withdraw(decimal amount, DateTime dateTime, string message)
    {
        if (this.Balance < amount)
        {
            throw new InvalidOperationException();
        }
        this.Balance -= amount;
        this.BonusPoints += this.CalculateWithdrawRewardPoints(amount);
        this._operations.Add(new AccountCashOperation(amount, dateTime, message));
    }

    protected abstract int CalculateDepositRewardPoints(decimal amount);
    protected abstract int CalculateWithdrawRewardPoints(decimal amount);

}

