using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class UpdateNaTabelaDeAdminClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminClass_Admin_id_admin",
                table: "AdminClass");

            migrationBuilder.DropColumn(
                name: "id_admin1",
                table: "AdminClass");

            migrationBuilder.DropColumn(
                name: "id_class1",
                table: "AdminClass");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminClass_Admin_id_admin",
                table: "AdminClass",
                column: "id_admin",
                principalTable: "Admin",
                principalColumn: "id_admin",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminClass_Admin_id_admin",
                table: "AdminClass");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AdminClass_Admin_id_admin",
                table: "AdminClass",
                column: "id_admin",
                principalTable: "Admin",
                principalColumn: "id_admin",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
