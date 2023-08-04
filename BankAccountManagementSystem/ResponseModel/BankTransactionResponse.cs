using BankAccountManagementSystem.Enum;
using BankAccountManagementSystem.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAccountManagementSystem.ViewModel
{
    public class BankTransactionResponse : BaseModelUseFullNameResponse
    {
        public TransactionType TypeOfTransaction { get; set; }
        public CatagoryOptionsForBankAccount CatagoryOptions { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public Payment PaymentMethod { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
