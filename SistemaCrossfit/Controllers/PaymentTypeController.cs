using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
	[Route("api/paymentType")]
	[ApiController]
	public class PaymentTypeController : ControllerBase
	{
		private readonly IPaymentTypeRepository _paymentTypeRepository;

		public PaymentTypeController(IPaymentTypeRepository paymentTypeRepository)
		{
			_paymentTypeRepository = paymentTypeRepository;
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<List<PaymentType>>> GetPaymentTypes()
		{
			try
			{
				List<PaymentType> paymentTypes = await _paymentTypeRepository.GetAll();
				return Ok(paymentTypes);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<PaymentType>> GetPaymentTypeById(int id)
		{
			try
			{
				PaymentType paymentType = await _paymentTypeRepository.GetById(id);
				return Ok(paymentType);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpPost]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult<PaymentType>> CreatePaymentType([FromBody] PaymentType paymentType)
		{
			try
			{
				PaymentType p = await _paymentTypeRepository.Create(paymentType);
				return Ok(p);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpPut("{id}")]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult<PaymentType>> UpdatePaymentType(int id, [FromBody] PaymentType paymentType)
		{
			try
			{
				PaymentType p = await _paymentTypeRepository.Update(paymentType, id);
				return Ok(p);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "ADMIN")]
		public async Task<ActionResult<PaymentType>> DeletePaymentTypeById(int id)
		{
			try
			{
				Boolean deleted = await _paymentTypeRepository.Delete(id);
				return Ok(deleted);
			}
			catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
		}
	}
}
