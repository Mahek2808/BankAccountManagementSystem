using System.ComponentModel.DataAnnotations;

namespace BankAccountManagementSystem.Model
{
    public class BaseModelUserFullName : BaseModelId
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
