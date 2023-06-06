namespace SistemaCrossfit.DTO.Student
{
    public class CreateStudent
    {
        /*-------- Student Props ----------*/
        public int? IdAddress { get; set; }
        public int IdGenre { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsBlocked { get; set; }
        public string? BlockDescription { get; set; }

        /*-------- User Props ----------*/
        public int IdProfile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? SocialName { get; set; }
    }
}
