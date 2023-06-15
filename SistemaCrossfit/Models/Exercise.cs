using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCrossfit.Models
{
	public class Exercise : BaseModel
	{
		[Key]
		[Column("id_exercise")]
		public int IdExercise { get; set; }
		public string Description { get; set; } = null!;
	}
}
