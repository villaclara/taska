using System;
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
        this.Number = uniqueNumberGenerator.Generate();
    }
    public BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
    {
        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Number = numberGenerator();
    }
    public BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
    {
        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Balance = initialBalance;
        this.BonusPoints = this.CalculateDepositRewardPoints(initialBalance);
        this._operations.Add(new AccountCashOperation(initialBalance, DateTime.Now, "Initial operation"));
        this.Number = uniqueNumberGenerator.Generate();
    }

    public BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
    {
        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Balance = initialBalance;
        this.BonusPoints = this.CalculateDepositRewardPoints(initialBalance);
        this._operations.Add(new AccountCashOperation(initialBalance, DateTime.Now, "Initial operation"));
        this.Number = numberGenerator();
    }

    public IList<AccountCashOperation> GetAllOperations()
    {
        return this._operations;
    }

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

