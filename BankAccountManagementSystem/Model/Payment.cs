using BankAccountManagementSystem.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountManagementSystem.Model
{
    public class Payment : BaseModelName
    {
        public ICollection<BankTransaction> BankTransactions { get; set; }
    }
}
