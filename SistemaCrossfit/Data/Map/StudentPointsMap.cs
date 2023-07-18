using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCrossfit.Models;

namespace SistemaCrossfit.Data.Map
{
	public class StudentPointsMap : BaseMap<StudentPoints>
	{
		public override void Configure(EntityTypeBuilder<StudentPoints> builder)
		{
			builder.HasKey(x => x.IdStudentPoints);
			builder.HasOne<Student>(x => x.Student).WithMany().HasForeignKey(x => x.IdStudent).IsRequired();
			builder.HasOne<Exercise>(x => x.Exercise).WithMany().HasForeignKey(x => x.IdExercise).IsRequired();
			builder.Property(x => x.Points).IsRequired().HasColumnName("points");
			builder.Navigation(x => x.Student).AutoInclude();
			builder.Navigation(x => x.Exercise).AutoInclude();
			base.Configure(builder);
		}
	}
}
