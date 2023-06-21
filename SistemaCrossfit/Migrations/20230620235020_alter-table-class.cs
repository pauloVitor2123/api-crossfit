using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class altertableclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "id_admin1",
                table: "AdminClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_class1",
                table: "AdminClass",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_class1",
                table: "StudentCheckInClass");

            migrationBuilder.DropColumn(
                name: "id_student1",
                table: "StudentCheckInClass");

            migrationBuilder.DropColumn(
                name: "id_admin1",
                table: "AdminClass");

            migrationBuilder.DropColumn(
                name: "id_class1",
                table: "AdminClass");
        }
    }
}
