using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class TelephoneFactory
    {
        public static List<Telephone> CreateSeedTelephones()
        {
            List<Telephone> telephones = new List<Telephone>();

            Telephone telephone1 = new Telephone()
            {
                IdStudent = 2,
                Number = 123456789
            };
            telephones.Add(telephone1);

            return telephones;
        }
    }
}
