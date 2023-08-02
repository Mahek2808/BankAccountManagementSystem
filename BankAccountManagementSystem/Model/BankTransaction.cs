using BankAccountManagementSystem.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountManagementSystem.Model
{
    public class BankTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransactionId { get; set; }
        [Required]
        public string? FirstNameOfTransactionPerson { get; set; }
        public string MiddleNameOfTransactionPerson { get; set; }
        [Required]
        public string? LastNameOfTransactionPerson { get; set; }
        public TransactionType TypeOfTransaction { get; set; }
        public CatagoryOptionsForBankAccount CatagoryOptions { get; set; }

        [MaxLength(6,ErrorMessage = "You only add upto 6 decimal places.")]
        public decimal Amount { get; set; }
        public DateTime DateOfTransaction { get; set; }

        [ForeignKey("PaymentId")]
        public Payment PaymentMethod { get; set; }    

        [ForeignKey("BankAccountId")]
        public BankAccount BankAccount { get; set; }     
    }
}
