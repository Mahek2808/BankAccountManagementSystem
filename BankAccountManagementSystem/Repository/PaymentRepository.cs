using BankAccountManagementSystem.DBContext;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagementSystem.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ContextClass _ContextClass;
        private readonly List<Payment> _paymentMethods;
        public PaymentRepository(ContextClass contextClass)
        {
            _ContextClass = contextClass;
            _paymentMethods = new List<Payment>
            {
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "Cash"
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheque"
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "NEFT"
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "RTGS"
                },
                new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = "Other"
                }
            };
        }
        public async Task DeletePaymentMethod(Guid id)
        {
            var existingMethod = await GetPaymentMethodById(id);
            if (existingMethod != null)
            {
                _paymentMethods.Remove(existingMethod);
            }
        }

        public async Task<List<Payment>> GetPaymentMethod()
        {
            return await _ContextClass.PaymentDetails.ToListAsync();
        }

        public async Task<Payment> GetPaymentMethodById(Guid id)
        {
            return await _ContextClass.PaymentDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdatePaymentMethod(Guid id, Payment paymentMethod)
        {
            var existingMethod = await GetPaymentMethodById(id);
            if (existingMethod != null)
            {
                existingMethod.Name = paymentMethod.Name;
            }
        }
    }
}
