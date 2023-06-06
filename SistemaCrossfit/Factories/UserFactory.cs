using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class UserFactory
    {
        public static List<User> CreateSeedUsers()
        {
            List<User> users = new List<User>();

            User admin = new()
            {
                IdProfile = 1,
                Name = "Admin Fulano",
                SocialName = "Admin",
                Email = "admin@admin.com",
                Password = "1234"
            };
            users.Add(admin);
            User student = new()
            {
                IdProfile = 1,
                Name = "Estudante Vitor",
                SocialName = "Student",
                Email = "student@student.com",
                Password = "1234"
            };
            users.Add(student);

            User professor = new()
            {
                IdProfile = 1,
                Name = "Professor Girafales",
                SocialName = "Professor",
                Email = "professor@professor.com",
                Password = "1234"
            };
            users.Add(professor);


            return users;
        }
    }
}
