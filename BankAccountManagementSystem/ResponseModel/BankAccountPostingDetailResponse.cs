using BankAccountManagementSystem.Model;

namespace BankAccountManagementSystem.ViewModel
{
    public class BankAccountPostingDetailResponse : BaseModelIdResponse
    {
        public BankTransaction PostingDetails { get; set; }
    }
}
