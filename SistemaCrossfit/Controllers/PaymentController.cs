using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
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
        [Authorize]
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
        [Authorize]
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
        [Authorize(Roles = "ADMIN")]
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
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<PaymentDto>> GetPaymentById(int id)
        {
            try
            {
                var payment = await paymentService.GetPaymentById(id);
                if (payment == null)
                {
                    return StatusCode(404, "Payment not found");
                }
                return Ok(payment);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<List<PaymentDto>>> GetPayments()
        {
            try
            {
                var payment = await paymentService.GetAll();
                if (payment == null)
                {
                    return StatusCode(404, "Payment not found");
                }
                return Ok(payment);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> UpdatePayment(int id, [FromBody] UpdatePaymentRequest payment)
        {
            try
            {
                payment.IdPayment = id;
                await paymentService.UpdatePayment(payment);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
