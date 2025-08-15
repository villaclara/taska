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
        throw new NotImplementedException();
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
}
