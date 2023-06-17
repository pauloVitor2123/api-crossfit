using SistemaCrossfit.Models;
using System.Text.RegularExpressions;
using System.Text;
using Newtonsoft.Json;

namespace SistemaCrossfit.DTO
{
    public class CreateProfessorBody : BaseModel
    {
        public CreateProfessorBody() { }
        public CreateProfessorBody(User user, int IdProfessor)
        {
            this.IdProfessor = IdProfessor;
            this.Email = this.convertNameToEmail(user.Name);
            this.Password = "1234";
            this.Name = user.Name;
            this.SocialName = user.SocialName;
            this.CreatedAt = user.CreatedAt;
            this.UpdatedAt = user.UpdatedAt;
            this.DeletedAt = user.DeletedAt;
        }

        public int IdProfessor { get; set; }
        [JsonIgnore]
        public string? Email;
        [JsonIgnore]
        public string? Password;
        public string Name { get; set; }
        public string? SocialName { get; set; }
        private string convertNameToEmail(string name)
        {
            string semEspacos = name.Replace(" ", ".");

            string minusculo = semEspacos.ToLower();
            string semEspeciais = Encoding.ASCII.GetString(
                Encoding.GetEncoding("Cyrillic").GetBytes(minusculo));

            string email = Regex.Replace(semEspeciais, @"[^0-9a-zA-Z]+", "");

            return email + "@crossfit.com";
        }

        public string getEmail()
        {
            if (this.Email != null)
            {
                return this.Email;
            }
            return this.convertNameToEmail(this.Name);
        }
        public void setEmail(string email)
        {
            this.Email = email;
        }
        public string getPassword()
        {
            if (this.Password != null)
            {
                return this.Password;
            }
            return "1234";
        }
        public void setPassword(string password)
        {
            this.Password = password;
        }

    }
}
