using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
	public class ExerciseMap : BaseMap<Exercise>
	{
		public override void Configure(EntityTypeBuilder<Exercise> builder)
		{
			builder.HasKey(x => x.IdExercise);
			builder.Property(x => x.IdExercise).HasColumnName("id_exercise").ValueGeneratedOnAdd();
			builder.Property(x => x.Description).IsRequired().HasMaxLength(255).HasColumnName("description");
			base.Configure(builder);
		}
	}
}
