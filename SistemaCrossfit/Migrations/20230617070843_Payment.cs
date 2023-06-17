using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class Payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    IdPayment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAdmin = table.Column<int>(type: "int", nullable: true),
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    IdPaymentType = table.Column<int>(type: "int", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Invoice = table.Column<double>(type: "float", nullable: true),
                    DatePayment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.IdPayment);
                    table.ForeignKey(
                        name: "FK_Payment_Admin_IdAdmin",
                        column: x => x.IdAdmin,
                        principalTable: "Admin",
                        principalColumn: "id_admin");
                    table.ForeignKey(
                        name: "FK_Payment_PaymentType_IdPaymentType",
                        column: x => x.IdPaymentType,
                        principalTable: "PaymentType",
                        principalColumn: "id_payment_type");
                    table.ForeignKey(
                        name: "FK_Payment_Status_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "id_profile",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdAdmin",
                table: "Payment",
                column: "IdAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdPaymentType",
                table: "Payment",
                column: "IdPaymentType");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdStatus",
                table: "Payment",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdStudent",
                table: "Payment",
                column: "IdStudent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
