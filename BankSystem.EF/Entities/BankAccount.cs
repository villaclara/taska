using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities;

public class BankAccount
{
    [Key]
    [Column("bank_account_id")]
    public int Id { get; set; }

    [ForeignKey(nameof(AccountOwner))]
    [Column("account_owner_id")]
    public int AccountOwnerId { get; set; }

    [Column("account_number", TypeName = "char(20)")]
    public string Number { get; set; }

    [Column("balance", TypeName = "real")]
    public decimal Balance { get; set; }

    [ForeignKey(nameof(CurrencyCode))]
    [Column("currency_code_id")]
    public int CurrencyCodeId { get; set; }

    [Column("bonus_points")]
    public int BonusPoints { get; set; }

    [Column("overdraft", TypeName = "real")]
    public decimal Overdraft { get; set; }

    public AccountOwner AccountOwner { get; set; }
    public CurrencyCode CurrencyCode { get; set; }
}

