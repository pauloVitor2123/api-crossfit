using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id_address = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postal_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    number = table.Column<int>(type: "int", nullable: true),
                    neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    complement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id_address);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    id_exercise = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.id_exercise);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    id_gender = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    normalized_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.id_gender);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    id_payment_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.id_payment_type);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    id_profile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    normalized_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.id_profile);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    normalized_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id_status);
                });

            migrationBuilder.CreateTable(
                name: "Telephone",
                columns: table => new
                {
                    id_telephone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_student = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephone", x => x.id_telephone);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_profile = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    social_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_User_Profile_id_profile",
                        column: x => x.id_profile,
                        principalTable: "Profile",
                        principalColumn: "id_profile",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    id_admin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.id_admin);
                    table.ForeignKey(
                        name: "FK_Admin_User_id_user",
                        column: x => x.id_user,
                        principalTable: "User",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    id_professor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.id_professor);
                    table.ForeignKey(
                        name: "FK_Professor_User_id_user",
                        column: x => x.id_user,
                        principalTable: "User",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id_student = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_address = table.Column<int>(type: "int", nullable: true),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_gender = table.Column<int>(type: "int", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_blocked = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    block_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id_student);
                    table.ForeignKey(
                        name: "FK_Student_Address_id_address",
                        column: x => x.id_address,
                        principalTable: "Address",
                        principalColumn: "id_address");
                    table.ForeignKey(
                        name: "FK_Student_Gender_id_gender",
                        column: x => x.id_gender,
                        principalTable: "Gender",
                        principalColumn: "id_gender",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_User_id_user",
                        column: x => x.id_user,
                        principalTable: "User",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentManagement",
                columns: table => new
                {
                    IdContentManagement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    IdAdmin = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    Whatsapp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentManagement", x => x.IdContentManagement);
                    table.ForeignKey(
                        name: "FK_ContentManagement_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "id_address",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentManagement_Admin_IdAdmin",
                        column: x => x.IdAdmin,
                        principalTable: "Admin",
                        principalColumn: "id_admin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    id_class = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    end_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    id_professor = table.Column<int>(type: "int", nullable: false),
                    id_status = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Class_Status_id_status",
                        column: x => x.id_status,
                        principalTable: "Status",
                        principalColumn: "id_status",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "id_status",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPoints",
                columns: table => new
                {
                    id_student = table.Column<int>(type: "int", nullable: false),
                    id_exercise = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "AdminClass",
                columns: table => new
                {
                    id_admin = table.Column<int>(type: "int", nullable: false),
                    id_class = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "StudentCheckInClass",
                columns: table => new
                {
                    id_student = table.Column<int>(type: "int", nullable: false),
                    id_class = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "IX_Admin_id_user",
                table: "Admin",
                column: "id_user",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminClass_id_class",
                table: "AdminClass",
                column: "id_class");

            migrationBuilder.CreateIndex(
                name: "IX_Class_id_professor",
                table: "Class",
                column: "id_professor");

            migrationBuilder.CreateIndex(
                name: "IX_Class_id_status",
                table: "Class",
                column: "id_status");

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagement_IdAddress",
                table: "ContentManagement",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagement_IdAdmin",
                table: "ContentManagement",
                column: "IdAdmin");

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

            migrationBuilder.CreateIndex(
                name: "IX_Professor_id_user",
                table: "Professor",
                column: "id_user",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_id_address",
                table: "Student",
                column: "id_address",
                unique: true,
                filter: "[id_address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Student_id_gender",
                table: "Student",
                column: "id_gender");

            migrationBuilder.CreateIndex(
                name: "IX_Student_id_user",
                table: "Student",
                column: "id_user",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheckInClass_id_class",
                table: "StudentCheckInClass",
                column: "id_class");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPoints_id_exercise",
                table: "StudentPoints",
                column: "id_exercise");

            migrationBuilder.CreateIndex(
                name: "IX_User_id_profile",
                table: "User",
                column: "id_profile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminClass");

            migrationBuilder.DropTable(
                name: "ContentManagement");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "StudentCheckInClass");

            migrationBuilder.DropTable(
                name: "StudentPoints");

            migrationBuilder.DropTable(
                name: "Telephone");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
