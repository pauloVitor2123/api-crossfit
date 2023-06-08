using SistemaCrossfit.Models;

namespace SistemaCrossfit.Factories
{
    public class AdminFactory
    {
        public static List<Admin> CreateSeedAdmins()
        {
            List<Admin> admins = new List<Admin>();

            Admin admin = new()
            {
                IdUser = 1
            };
            admins.Add(admin);
            

            return admins;
        }
    }
}
