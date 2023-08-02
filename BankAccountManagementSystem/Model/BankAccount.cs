using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountManagementSystem.Model
{
    public class BankAccount
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BankAccountId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "Account number must be 8 digits.")]
        public int AccountNumber { get; set; }

        [Required]
        public DateTime AccountOpeningDate { get; set; }

        public DateTime AccountClosingDate { get; set;}

        [Required]
        [ForeignKey("AccountTypeId")]
        public AccountType AccountType { get; set; } 

        public int TotalAmountOfBalance { get; set; }

    }
}
