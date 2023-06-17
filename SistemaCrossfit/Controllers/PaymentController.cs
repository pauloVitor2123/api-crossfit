using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Repositories.Interface;
using SistemaCrossfit.Request;
using SistemaCrossfit.Services;

namespace SistemaCrossfit.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService paymentService;

        public PaymentController(PaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        //public async Task<PaymentDto> GetOpenInvoice(int IdPayment)
        //public async Task<List<PaymentDto>> GetPaymentByStudentId(int IdStudent)
        //public async Task CreatePayment(CreatePaymentRequest createPaymentRequest)
        //public async Task UpdatePayment(UpdatePaymentRequest updatePaymentRequest)

        [HttpGet("invoice")]
        public async Task<ActionResult<PaymentDto>> GetOpenInvoice(int IdPayment)
        {
            try
            {
                PaymentDto paymentDto = await paymentService.GetOpenInvoice(IdPayment);
                return Ok(paymentDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("invoices-by-student")]
        public async Task<ActionResult<List<PaymentDto>>> GetPaymentByStudentId(int IdStudent)
        {
            try
            {
                var paymentDto = await paymentService.GetPaymentByStudentId(IdStudent);
                return Ok(paymentDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreatePayment(CreatePaymentRequest createPaymentRequest)
        {
            try
            {
                await paymentService.CreatePayment(createPaymentRequest);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("update-payment")]
        public async Task<ActionResult> UpdatePayment(UpdatePaymentRequest updatePaymentRequest)
        {
            try
            {
                await paymentService.UpdatePayment(updatePaymentRequest);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
