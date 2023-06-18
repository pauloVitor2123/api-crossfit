using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class AdminClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminClass",
                columns: table => new
                {
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_admin = table.Column<int>(type: "int", nullable: false),
                    id_class = table.Column<int>(type: "int", nullable: false),
                    id_admin1 = table.Column<int>(type: "int", nullable: false),
                    id_class1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminClass", x => new { x.id_admin, x.id_class });
                    table.ForeignKey(
                        name: "FK_AdminClass_Admin_id_admin",
                        column: x => x.id_admin,
                        principalTable: "Admin",
                        principalColumn: "id_admin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminClass_Class_id_class",
                        column: x => x.id_class,
                        principalTable: "Class",
                        principalColumn: "id_class",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminClass_id_class",
                table: "AdminClass",
                column: "id_class");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminClass");
        }
    }
}
