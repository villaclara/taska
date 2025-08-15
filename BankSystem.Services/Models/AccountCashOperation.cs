namespace BankSystem.Services.Models;

public class AccountCashOperation
{
    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public string Note { get; set; }

    public AccountCashOperation(decimal amount, DateTime date, string note)
    {
        this.Amount = amount;
        this.Date = date;
        this.Note = note;
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }
}
