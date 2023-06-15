using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class studentPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentPoints",
                columns: table => new
                {
                    id_student = table.Column<int>(type: "int", nullable: false),
                    id_exercise = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPoints", x => new { x.id_student, x.id_exercise });
                    table.ForeignKey(
                        name: "FK_StudentPoints_Exercise_id_exercise",
                        column: x => x.id_exercise,
                        principalTable: "Exercise",
                        principalColumn: "id_exercise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPoints_Student_id_student",
                        column: x => x.id_student,
                        principalTable: "Student",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentPoints_id_exercise",
                table: "StudentPoints",
                column: "id_exercise");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentPoints");
        }
    }
}
