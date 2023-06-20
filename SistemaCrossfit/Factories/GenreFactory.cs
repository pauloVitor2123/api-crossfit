using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class GenderFactory
    {
        public static List<Gender> CreateSeedGenders()
        {
            List<Gender> Genders = new List<Gender>();

            Gender male = new()
            {
                Name = "Masculino",
                NormalizedName = "MALE",
                Active = true
            };
            Genders.Add(male);

            Gender female = new()
            {
                Name = "Feminino",
                NormalizedName = "FEMALE",
                Active = true
            };
            Genders.Add(female);


            Gender other = new()
            {
                Name = "Outro",
                NormalizedName = "OTHER",
                Active = true
            };
            Genders.Add(other);


            return Genders;
        }
    }
}
