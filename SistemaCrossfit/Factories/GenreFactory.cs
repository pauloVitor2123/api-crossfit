using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class GenreFactory
    {
        public static List<Genre> CreateSeedGenres()
        {
            List<Genre> Genres = new List<Genre>();

            Genre male = new()
            {
                Name = "Male",
                NormalizedName = "MALE",
                Active = true
            };
            Genres.Add(male);

            Genre female = new()
            {
                Name = "Female",
                NormalizedName = "FEMALE",
                Active = true
            };
            Genres.Add(female);


            Genre other = new()
            {
                Name = "Other",
                NormalizedName = "OTHER",
                Active = true
            };
            Genres.Add(other);


            return Genres;
        }
    }
}
