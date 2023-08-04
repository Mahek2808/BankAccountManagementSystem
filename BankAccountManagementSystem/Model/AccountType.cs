using BankAccountManagementSystem.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountManagementSystem.Model
{
    public class AccountType : BaseModelName
    {
        public ICollection<BankAccount> BankAccounts { get; set; }
    }
}
