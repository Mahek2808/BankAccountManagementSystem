using System.Text.Json.Serialization;

namespace BankAccountManagementSystem.ViewModel
{
    public class Error
    {
        [JsonIgnore]
        public int StatusCode { get; protected set; }
        public string Description { get; protected set; }

        public Error(int statusCode)
        {
            StatusCode = statusCode;
        }

        public Error(int statusCode, string description)
            : this(statusCode)
        {
            Description = description;
        }
    }
}
