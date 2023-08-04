using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountManagementSystem.Model
{
    public class BankAccount : BaseModelUserFullName
    {
      
        [Required]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "Account number must be 8 digits.")]
        public int AccountNumber { get; set; }

        [Required]
        public DateTime AccountOpeningDate { get; set; }
        public DateTime AccountClosingDate { get; set;}

        [ForeignKey("AccountType")]
        public Guid AccountType_Id{ get; set; }
        public AccountType AccountType { get; set; }
        public int TotalAmountOfBalance { get; set; }
        public ICollection<BankTransaction> BankTransactions { get; set; }
    }   
}
