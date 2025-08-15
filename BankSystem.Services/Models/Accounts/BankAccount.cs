using BankSystem.Services.Generators;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BankSystem.Services.Models.Accounts;

public abstract class BankAccount
{
    private List<AccountCashOperation> _operations = [];
    public string Number { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyCode { get; set; }
    public AccountOwner AccountOwner { get; set; }
    public int BonusPoints { get; set; }
    public abstract decimal OverDraft { get; set; }

    public BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator)
    {
        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
    }
    public BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
    {
        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
    }
    public BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
    {
        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Balance = initialBalance;
    }

    public BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
    {
        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Balance = initialBalance;
    }

    public IList<AccountCashOperation> GetAllOperations()
    {
        return this._operations;
    }

    public void Deposit(decimal amount, DateTime dateTime, string message)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount, DateTime dateTime, string message)
    {
        this.Balance -= amount;
    }

    public abstract int CalculateDepositRewardPoints(decimal amount);
    public abstract int CalculateWithdrawRewardPoints(decimal amount);

}

