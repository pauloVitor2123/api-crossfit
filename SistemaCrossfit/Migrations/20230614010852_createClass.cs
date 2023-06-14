using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class createClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    id_class = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_status = table.Column<int>(type: "int", nullable: false),
                    id_professor = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    start_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    end_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.id_class);
                    table.ForeignKey(
                        name: "FK_Class_Professor_id_professor",
                        column: x => x.id_professor,
                        principalTable: "Professor",
                        principalColumn: "id_professor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_id_professor",
                table: "Class",
                column: "id_professor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Class");
        }
    }
}
