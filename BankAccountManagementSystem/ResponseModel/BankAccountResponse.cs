using BankAccountManagementSystem.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAccountManagementSystem.ViewModel
{
    public class BankAccountResponse : BaseModelUseFullNameResponse
    {
        public int AccountNumber { get; set; }
        public DateTime AccountOpeningDate { get; set; }
        public DateTime AccountClosingDate { get; set; }
        public AccountType AccountType { get; set; }
        public int TotalAmountOfBalance { get; set; }

    }
}
