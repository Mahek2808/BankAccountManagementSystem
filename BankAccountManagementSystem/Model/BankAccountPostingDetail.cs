using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountManagementSystem.Model
{
    public class BankAccountPostingDetail : BaseModelId
    {
        [ForeignKey("BankTransaction")]
        [Required]
        public Guid BankTransaction_Id { get; set; }
        public BankTransaction BankTransaction { get; set; }
    }
}
