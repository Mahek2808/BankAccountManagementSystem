using BankAccountManagementSystem.ViewModel;

namespace BankAccountManagementSystem.Interface.IService
{
    public interface IPaymentService
    {
        Task<List<PaymentResponse>> GetPaymentMethod();
        Task<PaymentResponse> GetPaymentMethodById(Guid id);
        Task UpdatePaymentMethod(Guid id, PaymentResponse paymentMethod);
        Task DeletePaymentMethod(Guid id);
    }
}
