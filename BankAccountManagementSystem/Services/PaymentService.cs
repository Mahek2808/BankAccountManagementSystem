using AutoMapper;
using BankAccountManagementSystem.Interface.IRepository;
using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.ViewModel;

namespace BankAccountManagementSystem.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }
        public async Task DeletePaymentMethod(Guid id)
        {
            var existingMethod = await _paymentRepository.GetPaymentMethodById(id);
            if (existingMethod == null)
            {
                await _paymentRepository.DeletePaymentMethod(id);
            }
            throw new Exception("Payment method not found.");
        }

        public async Task<List<PaymentResponse>> GetPaymentMethod()
        {
            var paymentMethods = await _paymentRepository.GetPaymentMethod();
            return _mapper.Map<List<PaymentResponse>>(paymentMethods);
        }

        public async Task<PaymentResponse> GetPaymentMethodById(Guid id)
        {
            var paymentMethod = await _paymentRepository.GetPaymentMethodById(id);
            return _mapper.Map<PaymentResponse>(paymentMethod);
        }

        public async Task UpdatePaymentMethod(Guid id, PaymentResponse paymentMethod)
        {
            var existingMethod = await _paymentRepository.GetPaymentMethodById(id);
            if (existingMethod == null)
            {
                throw new Exception("Payment method not found.");
            }
            _mapper.Map(paymentMethod, existingMethod);
            await _paymentRepository.UpdatePaymentMethod(id, existingMethod);
        }
    }
}
