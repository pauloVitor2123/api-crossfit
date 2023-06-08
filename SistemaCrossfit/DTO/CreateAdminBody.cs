using SistemaCrossfit.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaCrossfit.DTO
{
    public class CreateAdminBody : BaseModel
    {
        public CreateAdminBody() { }
        public CreateAdminBody(User user, int IdAdmin)
        {
            this.IdAdmin = IdAdmin;
            this.Email = user.Email;
            this.Password = user.Password;
            this.Name = user.Name;
            this.SocialName = user.SocialName;
            this.CreatedAt = user.CreatedAt;
            this.UpdatedAt = user.UpdatedAt;
            this.DeletedAt = user.DeletedAt;

        }
        public int IdAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? SocialName { get; set; }

    }
}
