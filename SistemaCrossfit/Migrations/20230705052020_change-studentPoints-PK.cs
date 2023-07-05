using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class changestudentPointsPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPoints",
                table: "StudentPoints");

            migrationBuilder.AddColumn<int>(
                name: "id_student_points",
                table: "StudentPoints",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPoints",
                table: "StudentPoints",
                column: "id_student_points");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPoints_id_student",
                table: "StudentPoints",
                column: "id_student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentPoints",
                table: "StudentPoints");

            migrationBuilder.DropIndex(
                name: "IX_StudentPoints_id_student",
                table: "StudentPoints");

            migrationBuilder.DropColumn(
                name: "id_student_points",
                table: "StudentPoints");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentPoints",
                table: "StudentPoints",
                columns: new[] { "id_student", "id_exercise" });
        }
    }
}
