using BankSystem.Services.Generators;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BankSystem.Services.Models.Accounts;

public class BankAccount
{
    public string Number { get; set; }
    public string Balance { get; set; }

    public string CurrencyCode { get; set; }
    public AccountOwner Owner { get; set; }
    public int BonusPoints { get; set; }
    public decimal OverDraft { get; set; }

    public BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator)
    {
        this.Owner = owner;
        this.CurrencyCode = currencyCode;
    }
    public BankAccount(AccountOwner owner, string currencyCode, Func<string> )
    {
        this.Owner = owner;
        this.CurrencyCode = currencyCode;
    }

}

