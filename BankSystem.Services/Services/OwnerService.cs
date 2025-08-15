using BankSystem.EF.Entities;
using BankSystem.Services.Models;
namespace BankSystem.Services.Services;

public class OwnerService : IDisposable
{
    private readonly BankContext context;

    public OwnerService(BankContext context)
    {
        this.context = context;
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        this.context.Dispose();
    }

    public IReadOnlyList<AccountOwnerTotalBalanceModel> GetAccountOwnersTotalBalance()
    {
        var query = this.context.AccountOwners
            .SelectMany(owner => owner.BankAccounts, (owner, account) => new
            {
                owner.Id,
                owner.FirstName,
                owner.LastName,
                CurrencyCode = account.CurrencyCode.CurrenciesCode,
                Balance = (double)account.Balance
            })
            .GroupBy(x => new { x.Id, x.FirstName, x.LastName, x.CurrencyCode })
            .Select(g => new AccountOwnerTotalBalanceModel
            {
                AccountOwnerId = g.Key.Id,
                FirstName = g.Key.FirstName,
                LastName = g.Key.LastName,
                CurrencyCode = g.Key.CurrencyCode,
                Total = (decimal)g.Sum(x => x.Balance)
            })
            .ToList();

        var result = query
            .OrderByDescending(x => (double)x.Total)
            .ToList();

        return result;
    }
}
