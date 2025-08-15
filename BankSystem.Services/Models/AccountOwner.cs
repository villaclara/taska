using BankSystem.Services.Helpers;
using BankSystem.Services.Models.Accounts;

namespace BankSystem.Services.Models;

public class AccountOwner
{
    private List<BankAccount> accounts;

    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public AccountOwner(string firstName, string lastName, string email)
    {
        VerifyString(firstName, nameof(firstName));
        VerifyString(lastName, nameof(lastName));
        VerifyString(email, nameof(email));
        if (!ValidatorService.IsEmailValid(email))
        {
            throw new ArgumentException(email);
        }
        this.Email = email;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.accounts = [];
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName}, {this.Email}.";
    }

    public void Add(BankAccount? account)
    {
        ArgumentNullException.ThrowIfNull(account);

        if (this.accounts == null)
        {
            this.accounts = [];
        }

        this.accounts.Add(account);
    }

    public IList<BankAccount> Accounts()
    {
        return this.accounts;
    }

    private static void VerifyString(string value, string paramName) => ArgumentException.ThrowIfNullOrEmpty(value, nameof(paramName));
}

