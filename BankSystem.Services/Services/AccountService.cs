using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;
public class AccountService : IDisposable
{
    private readonly BankContext context;

    public AccountService(BankContext context)
    {
        this.context = context;
    }
    public IReadOnlyList<BankAccountFullInfoModel> GetBankAccountsFullInfo()
    {
        var result = this.context.BankAccounts
            .Select(account => new BankAccountFullInfoModel
            {
                BankAccountId = account.Id,
                FirstName = account.AccountOwner.FirstName,
                LastName = account.AccountOwner.LastName,
                AccountNumber = account.Number,
                Balance = account.Balance,
                CurrencyCode = account.CurrencyCode.CurrenciesCode,
                BonusPoints = account.BonusPoints
            })
            .ToList();

        return result;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }
    //comment

    protected virtual void Dispose(bool disposing)
    {
        this.context.Dispose();
    }
}
