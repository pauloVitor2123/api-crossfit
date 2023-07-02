﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaCrossfit.Data;

#nullable disable

namespace SistemaCrossfit.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230627204017_delete-timestamp-fields")]
    partial class deletetimestampfields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SistemaCrossfit.Models.Address", b =>
                {
                    b.Property<int>("IdAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_address");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAddress"), 1L, 1);

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Complement")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("complement");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<string>("Neighborhood")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("neighborhood");

                    b.Property<int?>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("postal_code");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("street");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdAddress");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Admin", b =>
                {
                    b.Property<int>("IdAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_admin");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdmin"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdAdmin");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.AdminClass", b =>
                {
                    b.Property<int>("IdAdmin")
                        .HasColumnType("int")
                        .HasColumnName("id_admin");

                    b.Property<int>("IdClass")
                        .HasColumnType("int")
                        .HasColumnName("id_class");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdAdmin", "IdClass");

                    b.HasIndex("IdClass");

                    b.ToTable("AdminClass");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Class", b =>
                {
                    b.Property<int>("IdClass")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_class");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClass"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<TimeSpan>("EndHour")
                        .HasColumnType("time")
                        .HasColumnName("end_hour");

                    b.Property<int>("IdProfessor")
                        .HasColumnType("int")
                        .HasColumnName("id_professor");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int")
                        .HasColumnName("id_status");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("name");

                    b.Property<TimeSpan>("StartHour")
                        .HasColumnType("time")
                        .HasColumnName("start_hour");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdClass");

                    b.HasIndex("IdProfessor");

                    b.HasIndex("IdStatus");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.ContentManagement", b =>
                {
                    b.Property<int>("IdContentManagement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContentManagement"), 1L, 1);

                    b.Property<string>("AboutDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("EmailContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAddress")
                        .HasColumnType("int");

                    b.Property<int>("IdAdmin")
                        .HasColumnType("int");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("LogoImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubTitulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<string>("Whatsapp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContentManagement");

                    b.HasIndex("IdAddress");

                    b.HasIndex("IdAdmin");

                    b.ToTable("ContentManagement");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Exercise", b =>
                {
                    b.Property<int>("IdExercise")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_exercise");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdExercise"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdExercise");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Gender", b =>
                {
                    b.Property<int>("IdGender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_gender");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGender"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("normalized_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdGender");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Payment", b =>
                {
                    b.Property<int>("IdPayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPayment"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DatePayment")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdAdmin")
                        .HasColumnType("int");

                    b.Property<int?>("IdPaymentType")
                        .HasColumnType("int");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int");

                    b.Property<int>("IdStudent")
                        .HasColumnType("int");

                    b.Property<double?>("Invoice")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("IdPayment");

                    b.HasIndex("IdAdmin");

                    b.HasIndex("IdPaymentType");

                    b.HasIndex("IdStatus");

                    b.HasIndex("IdStudent");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.PaymentType", b =>
                {
                    b.Property<int>("IdPaymentType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_payment_type");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaymentType"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdPaymentType");

                    b.ToTable("PaymentType");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Professor", b =>
                {
                    b.Property<int>("IdProfessor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_professor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProfessor"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdProfessor");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Profile", b =>
                {
                    b.Property<int>("IdProfile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_profile");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProfile"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("normalized_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdProfile");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Status", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_status");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatus"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("normalized_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdStatus");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Student", b =>
                {
                    b.Property<int>("IdStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_student");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStudent"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<string>("BlockDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("block_description");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<int?>("IdAddress")
                        .HasColumnType("int")
                        .HasColumnName("id_address");

                    b.Property<int>("IdGender")
                        .HasColumnType("int")
                        .HasColumnName("id_gender");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<bool?>("IsBlocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("is_blocked");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdStudent");

                    b.HasIndex("IdAddress")
                        .IsUnique()
                        .HasFilter("[id_address] IS NOT NULL");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.StudentCheckInClass", b =>
                {
                    b.Property<int>("IdStudent")
                        .HasColumnType("int")
                        .HasColumnName("id_student");

                    b.Property<int>("IdClass")
                        .HasColumnType("int")
                        .HasColumnName("id_class");

                    b.HasKey("IdStudent", "IdClass");

                    b.HasIndex("IdClass");

                    b.ToTable("StudentCheckInClass");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.StudentPoints", b =>
                {
                    b.Property<int>("IdStudent")
                        .HasColumnType("int")
                        .HasColumnName("id_student");

                    b.Property<int>("IdExercise")
                        .HasColumnType("int")
                        .HasColumnName("id_exercise");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<int>("Points")
                        .HasColumnType("int")
                        .HasColumnName("points");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdStudent", "IdExercise");

                    b.HasIndex("IdExercise");

                    b.ToTable("StudentPoints");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Telephone", b =>
                {
                    b.Property<int>("IdTelephone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_telephone");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTelephone"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<int>("IdStudent")
                        .HasMaxLength(255)
                        .HasColumnType("int")
                        .HasColumnName("id_student");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdTelephone");

                    b.ToTable("Telephone");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at")
                        .HasColumnOrder(2147483646);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at")
                        .HasColumnOrder(2147483647);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<int>("IdProfile")
                        .HasColumnType("int")
                        .HasColumnName("id_profile");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("SocialName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("social_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(2147483645);

                    b.HasKey("IdUser");

                    b.HasIndex("IdProfile");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Admin", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("SistemaCrossfit.Models.Admin", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.AdminClass", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("IdAdmin")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaCrossfit.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Class", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("IdProfessor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCrossfit.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.ContentManagement", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("IdAddress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCrossfit.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("IdAdmin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Payment", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("IdAdmin");

                    b.HasOne("SistemaCrossfit.Models.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("IdPaymentType");

                    b.HasOne("SistemaCrossfit.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCrossfit.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("PaymentType");

                    b.Navigation("Status");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Professor", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.User", "User")
                        .WithOne("Professor")
                        .HasForeignKey("SistemaCrossfit.Models.Professor", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.Student", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.Address", "Address")
                        .WithOne()
                        .HasForeignKey("SistemaCrossfit.Models.Student", "IdAddress");

                    b.HasOne("SistemaCrossfit.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCrossfit.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("SistemaCrossfit.Models.Student", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Gender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.StudentCheckInClass", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaCrossfit.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.StudentPoints", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("IdExercise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaCrossfit.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("IdStudent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.User", b =>
                {
                    b.HasOne("SistemaCrossfit.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("IdProfile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SistemaCrossfit.Models.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Professor");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
