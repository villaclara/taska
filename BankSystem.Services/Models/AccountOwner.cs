using System.Text;
using BankSystem.Services.Models.Accounts;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BankSystem.Services.Models;

public class AccountOwner
{
    private string firstName;
    private string lastName;
    private List<BankAccount> accounts;
    private string email;

    public string Email { get => this.email; set => this.email = value; }
    public string FirstName { get => this.firstName; set => this.firstName = value; }
    public string LastName { get => this.lastName; set => this.lastName = value; }

    public AccountOwner(string firstName, string lastName, string email)
    {
        this.Email = email;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName}, Email: {this.Email}";
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
}

