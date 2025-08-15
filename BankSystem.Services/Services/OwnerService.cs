using BankSystem.EF.Entities;
using BankSystem.Services.Models;
namespace BankSystem.Services.Services;

public class OwnerService
{
    private readonly BankContext context;

    public OwnerService(BankContext context)
    {
        this.context = context;
    }
    public IReadOnlyList<AccountOwnerTotalBalanceModel> GetAccountOwnersTotalBalance()
    {
        throw new NotImplementedException();
    }
}
