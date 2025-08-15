using BankSystem.EF.Entities;
using BankSystem.Services.Models;

namespace BankSystem.Services.Services;
public class AccountService
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
}
