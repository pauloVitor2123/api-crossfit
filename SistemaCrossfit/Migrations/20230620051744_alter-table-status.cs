using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class altertablestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_profile",
                table: "Status",
                newName: "id_status");

            migrationBuilder.CreateTable(
                name: "StudentCheckInClass",
                columns: table => new
                {
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_student = table.Column<int>(type: "int", nullable: false),
                    id_class = table.Column<int>(type: "int", nullable: false),
                    id_class1 = table.Column<int>(type: "int", nullable: false),
                    id_student1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCheckInClass", x => new { x.id_student, x.id_class });
                    table.ForeignKey(
                        name: "FK_StudentCheckInClass_Class_id_class",
                        column: x => x.id_class,
                        principalTable: "Class",
                        principalColumn: "id_class",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCheckInClass_Student_id_student",
                        column: x => x.id_student,
                        principalTable: "Student",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheckInClass_id_class",
                table: "StudentCheckInClass",
                column: "id_class");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCheckInClass");

            migrationBuilder.RenameColumn(
                name: "id_status",
                table: "Status",
                newName: "id_profile");
        }
    }
}
