using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaCrossfit.Models
{
	public class StudentPoints : BaseModel
	{
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
