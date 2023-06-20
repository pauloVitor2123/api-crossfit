using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Request;
using SistemaCrossfit.Services;

namespace SistemaCrossfit.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("invoice")]
        [Authorize]
        public async Task<ActionResult<PaymentDto>> GetOpenInvoice(int IdPayment)
        {
            try
            {
                PaymentDto paymentDto = await _paymentService.GetOpenInvoice(IdPayment);
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
                var paymentDto = await _paymentService.GetPaymentByStudentId(IdStudent);
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
                await _paymentService.CreatePayment(createPaymentRequest);
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
                var payment = await _paymentService.GetPaymentById(id);
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
                var payment = await _paymentService.GetAll();
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
                await _paymentService.UpdatePayment(payment);
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
                await _paymentService.UpdatePayment(updatePaymentRequest);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}