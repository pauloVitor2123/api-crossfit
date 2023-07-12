using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaCrossfit.Models
{
	public class StudentPoints : BaseModel
	{
		[Key]
		[Column("id_student_points")]
		public int IdStudentPoints { get; set; }

		[Column("id_student")]
		[ForeignKey("Student")]
		public int IdStudent { get; set; }

		[JsonIgnore]
		public virtual Student Student { get; set; } = null!;

		[Column("id_exercise")]
		[ForeignKey("Exercise")]
		public int IdExercise { get; set; }

		[JsonIgnore]
		public virtual Exercise Exercise { get; set; } = null!;

		[Column("points")]
		public int Points { get; set; }
	}
}
