namespace BankAccountManagementSystem.ViewModel
{
    public class ErrorResult
    {
        public Error Error { get; set; }

        public ErrorResult(Error error)
        {
            Error = error;
        }
    }
}
