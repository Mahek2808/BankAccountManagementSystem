using System.ComponentModel.DataAnnotations;

namespace BankAccountManagementSystem.ViewModel
{
    public class BaseModelUseFullNameResponse : BaseModelIdResponse
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}
