using BankAccountManagementSystem.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountManagementSystem.Model
{
    public class BankTransaction : BaseModelUserFullName
    {
        public TransactionType TypeOfTransaction { get; set; }
        public CatagoryOptionsForBankAccount CatagoryOptions { get; set; }

        [MaxLength(6,ErrorMessage = "You only add upto 6 decimal places.")]
        public decimal Amount { get; set; }
        public DateTime DateOfTransaction { get; set; }

        [ForeignKey("Payment")]
        [Required]
        public Guid Payment_Id { get; set; }
        public Payment Payment { get; set; }

        [Required]
        [ForeignKey("BankAccount")]
        public Guid BankAccount_Id { get; set; }
        public BankAccount BankAccount { get; set; }
        public ICollection<BankAccountPostingDetail> BankAccountPostingDetails { get; set; }

    }
}   
