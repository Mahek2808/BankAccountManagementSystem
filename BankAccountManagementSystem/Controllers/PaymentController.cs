using BankAccountManagementSystem.Interface.IService;
using BankAccountManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentResponse>>> GetPaymentMethods()
        {
            var paymentMethods = await _paymentService.GetPaymentMethod();
            return Ok(paymentMethods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentResponse>> GetPaymentMethodById(Guid id)
        {
            var paymentMethod = await _paymentService.GetPaymentMethodById(id);
            if (paymentMethod != null)
            {
                return Ok(paymentMethod);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePaymentMethod(Guid id, PaymentResponse paymentMethod)
        {
            await _paymentService.UpdatePaymentMethod(id, paymentMethod);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaymentMethod(Guid id)
        {
            await _paymentService.DeletePaymentMethod(id);
            return NoContent();

        }

    }
}
