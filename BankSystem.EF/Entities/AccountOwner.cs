using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities;

[Table("account_owner")]
public class AccountOwner
{
    [Key]
    [Column("account_owner_id")]
    public int Id { get; set; }

    [Column("email", TypeName = "text")]
    public string Email { get; set; }

    [Column("first_name", TypeName = "text")]
    public string FirstName { get; set; }

    [Column("last_name", TypeName = "text")]
    public string LastName { get; set; }

    public IList<BankAccount> BankAccounts { get; set; }
}
