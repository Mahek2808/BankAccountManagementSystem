using BankAccountManagementSystem.Model;

namespace BankAccountManagementSystem.Interface.IRepository
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetPaymentMethod();
        Task<Payment> GetPaymentMethodById(Guid id);
        Task UpdatePaymentMethod(Guid id, Payment paymentMethod);
        Task DeletePaymentMethod(Guid id);
    }
}
