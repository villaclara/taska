namespace BankSystem.Services.Models.Accounts;

public class BankAccount
{
    public string Number { get; set; }
    public string Balance { get; set; }

    public string CurrencyCode { get; set; }
    public AccountOwner Owner { get; set; }
    public int BonusPoints { get; set; }
    public decimal OverDraft { get; set; }


}

