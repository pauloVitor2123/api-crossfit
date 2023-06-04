using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class ProfileFactory
    {
        public static List<Profile> CreateSeedProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            Profile admin = new()
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Active = true
            };
            profiles.Add(admin);

            Profile student = new()
            {
                Name = "Student",
                NormalizedName = "STUDENT",
                Active = true
            };
            profiles.Add(student);

            Profile professor = new()
            {
                Name = "Professor",
                NormalizedName = "PROFESSOR",
                Active = true
            };
            profiles.Add(professor);


            return profiles;
        }
    }
}
