using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class UpdateNaTabelaDeStudentCheckInClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheckInClass_Student_id_student",
                table: "StudentCheckInClass");

            migrationBuilder.DropColumn(
                name: "id_class1",
                table: "StudentCheckInClass");

            migrationBuilder.DropColumn(
                name: "id_student1",
                table: "StudentCheckInClass");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheckInClass_Student_id_student",
                table: "StudentCheckInClass",
                column: "id_student",
                principalTable: "Student",
                principalColumn: "id_student",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCheckInClass_Student_id_student",
                table: "StudentCheckInClass");

            migrationBuilder.AddColumn<int>(
                name: "id_class1",
                table: "StudentCheckInClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_student1",
                table: "StudentCheckInClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCheckInClass_Student_id_student",
                table: "StudentCheckInClass",
                column: "id_student",
                principalTable: "Student",
                principalColumn: "id_student",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
