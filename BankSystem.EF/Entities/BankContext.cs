using Microsoft.EntityFrameworkCore;

namespace BankSystem.EF.Entities;

public class BankContext : DbContext
{
    public DbSet<AccountCashOperation> accountCashOperations { get; set; }
    public DbSet<AccountOwner> AccountOwners { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<CurrencyCode> CurrencyCodes { get; set; }

    public BankContext(DbContextOptions<BankContext> options) : base(options) { }
}
