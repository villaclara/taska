namespace BankSystem.Services.Models;

public class AccountOwnerTotalBalanceModel
{
    public int AccountOwner { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CurrencyCode { get; set; }
    public decimal Total { get; set; }
}

