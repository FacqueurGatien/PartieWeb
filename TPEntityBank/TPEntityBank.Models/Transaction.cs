using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPEntityBank.Models
{
    [Table("transactions")]
    public class Transaction
    {
        [Key]
        [Column("transactionId")]
        public int Id { get; set; }

        [Required]
        [Column("transactionDate")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column("transactionCompteDebit")]
        [Range(10000000000,99999999999)]
        public long CompteDebiteur { get; set; }

        [Required]
        [Column("transactionCompteCredit")]
        [Range(10000000000 , 99999999999)]
        public long CompteCrediteur { get; set; }

        [Required]
        [Column("transactionMontant")]
        [Range(0.01 , 99000)]
        [Precision(7, 2)]
        public Decimal Montant { get; set; }

    }
}