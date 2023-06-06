using Microsoft.AspNetCore.Mvc;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly IBaseRepository<Address> _addressRepository;
        public AddressController(IBaseRepository<Address> addressRepository)
        {
            this._addressRepository = addressRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAddresses()
        {
            List<Address> addresss = await _addressRepository.GetAll();
            return Ok(addresss);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddressById(int id)
        {
            Address address = await _addressRepository.GetById(id);
            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress([FromBody] Address address)
        {
            Address a = await _addressRepository.Create(address);
            return Ok(a);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> UpdatedAddress(int id, [FromBody] Address address)
        {
            Address a = await _addressRepository.Update(address, id);
            return Ok(a);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddressById(int id)
        {
            Boolean deleted = await _addressRepository.Delete(id);
            return Ok(deleted);
        }

    }
}
