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
        throw new NotImplementedException();
    }
}
