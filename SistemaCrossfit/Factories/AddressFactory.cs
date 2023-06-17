using SistemaCrossfit.Models;
using System.Collections.Generic;

namespace SistemaCrossfit.Factories
{
    public class AddressFactory
    {
        public static List<Address> CreateSeedAddresses()
        {
            List<Address> addresses = new List<Address>();

            Address address1 = new Address()
            {
                PostalCode = "12345-678",
                Country = "Brazil",
                City = "Sao Paulo",
                Street = "Rua Exemplo",
                Number = 123,
                Neighborhood = "Bairro Exemplo",
                Complement = "Apto 123"
            };
            addresses.Add(address1);

            // Adicione mais Address aqui se necessário

            return addresses;
        }
    }
}
