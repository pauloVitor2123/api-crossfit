using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;

namespace SistemaCrossfit.Repositories
{
    public class AddressRepository : IBaseRepository<Address>
    {
        private readonly AppDBContext _dbContext;
        public AddressRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<Address>> GetAll()
        {
            return await _dbContext.Address.ToListAsync();
        }

        public async Task<Address> GetById(int id)
        {
            Address Address = await _dbContext.Address.FirstOrDefaultAsync(Address => Address.IdAddress == id);
            if (Address == null)
            {
                throw new Exception("User not found!");
            }

            return Address;
        }

        public async Task<Address> Create(Address address)
        {
            await _dbContext.Address.AddAsync(address);
            await _dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<Address> Update(Address address, int id)
        {
            Address addressUpdated = await _dbContext.Address.FirstOrDefaultAsync(p => p.IdAddress == id);
            if (addressUpdated == null)
            {
                throw new Exception("User not found!");
            }

            addressUpdated.PostalCode = address.PostalCode;
            addressUpdated.Country = address.Country;
            addressUpdated.City = address.City;
            addressUpdated.Street = address.Street;
            addressUpdated.Number = address.Number;
            addressUpdated.Neighborhood = address.Neighborhood;
            addressUpdated.Complement = address.Complement;

            await _dbContext.SaveChangesAsync();

            return addressUpdated;
        }

        public async Task<Boolean> Delete(int id)
        {
            Address address = await _dbContext.Address.FirstOrDefaultAsync(address => address.IdAddress == id);
            if (address == null)
            {
                throw new Exception("User not found!");
            }

            _dbContext.Address.Remove(address);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
