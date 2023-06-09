﻿using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Factories;
using SistemaCrossfit.Models;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Data
{
    public class AppDbInitializer
    {
        async public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();
                if (context == null)
                {
                    Console.WriteLine("Unable to create seeds!");
                    return;
                }
                context.Database.EnsureCreated();

                if (!context.Profile.Any())
                {
                    var profiles = ProfileFactory.CreateSeedProfiles();
                    await context.AddRangeAsync(profiles.ToArray());
                    Console.WriteLine("Profiles seeds created successfully!");
                }

                if (!context.Gender.Any())
                {
                    var profiles = GenderFactory.CreateSeedGenders();
                    await context.AddRangeAsync(profiles.ToArray());
                    Console.WriteLine("Gender seeds created successfully!");
                }
                if (!context.Profile.Any() || !context.Gender.Any())
                {
                    await context.SaveChangesAsync();
                }

                if (!context.User.Any())
                {
                    var users = UserFactory.CreateSeedUsers();
                    await context.AddRangeAsync(users.ToArray());
                    Console.WriteLine("Users seeds created successfully!");
                    await context.SaveChangesAsync();
                }
                if (!context.PaymentType.Any())
                {
                    var paymentTypes = PaymentTypeFactory.CreateSeedPaymentType();
                    await context.AddRangeAsync(paymentTypes.ToArray());
                    Console.WriteLine("PaymentTypes seeds created successfully!");
                }
                if (!context.Status.Any())
                {
                    var status = StatusFactory.CreateSeedStatus();
                    await context.AddRangeAsync(status.ToArray());
                    Console.WriteLine("Status seeds created successfully!");
                }

                if (!context.Student.Any())
                {
                    var students = StudentFactory.CreateSeedStudents();
                    await context.AddRangeAsync(students.ToArray());
                    Console.WriteLine("Students seeds created successfully!");
                    await context.SaveChangesAsync();
                    var T = await context.Database.BeginTransactionAsync();
                    try
                    {
                        var student = await context.Student.FirstOrDefaultAsync(x => x.IdStudent == 1);

                        if (student == null)
                        {
                            throw new Exception("Não foi encontrado o estudante");
                        }
                        var paymentDb = await context.Payment
                            .Where(x => x.IdStudent == 1)
                            .OrderByDescending(x => x.IdPayment)
                            .LastOrDefaultAsync();

                        var payment = new Payment()
                        {
                            IdAdmin = null,
                            IdStudent = 1,
                            DueDate = paymentDb == null ? DateTime.Now.AddMonths(1) : paymentDb.DueDate.AddMonths(1),
                            IdStatus = 4,
                            CreatedAt = DateTime.Now,
                        };

                        await context.Payment.AddAsync(payment);
                        await context.SaveChangesAsync();

                        await T.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await T.RollbackAsync();
                        throw new Exception(ex.Message);
                    }
                }

                if (!context.Admin.Any())
                {
                    var admins = AdminFactory.CreateSeedAdmins();
                    await context.AddRangeAsync(admins.ToArray());
                    Console.WriteLine("Admins seeds created successfully!");
                }
                if (!context.Professor.Any())
                {
                    var professors = ProfessorFactory.CreateSeedProfessors();
                    await context.AddRangeAsync(professors.ToArray());
                    Console.WriteLine("Professors seeds created successfully!");
                }
                if (!context.Admin.Any() || !context.Professor.Any() || !context.Student.Any())
                {
                    await context.SaveChangesAsync();
                }
                if (!context.Exercise.Any())
                {
                    var exercises = ExerciseFactory.CreateSeedExercises();
                    await context.AddRangeAsync(exercises.ToArray());
                    Console.WriteLine("Exercises seeds created successfully!");
                }

                if (!context.Exercise.Any() || !context.PaymentType.Any() || !context.Status.Any())
                {
                    await context.SaveChangesAsync();
                }

                if (!context.Telephone.Any())
                {
                    var telephones = TelephoneFactory.CreateSeedTelephones();
                    await context.AddRangeAsync(telephones.ToArray());
                    Console.WriteLine("Telephones seeds created successfully!");
                }
                if (!context.Class.Any())
                {
                    var classes = ClassFactory.CreateSeedClasses();
                    await context.AddRangeAsync(classes.ToArray());
                    Console.WriteLine("Classes seeds created successfully!");
                }
                if (!context.Class.Any() || !context.Telephone.Any())
                {
                    await context.SaveChangesAsync();
                }

                if (!context.StudentPoints.Any())
                {
                    var studentPoints = StudentPointsFactory.CreateSeedStudentPoints();
                    await context.AddRangeAsync(studentPoints.ToArray());
                    Console.WriteLine("StudentPoints seeds created successfully!");
                    await context.SaveChangesAsync();
                }

                if (!context.Address.Any())
                {
                    var addresses = AddressFactory.CreateSeedAddresses();
                    await context.AddRangeAsync(addresses.ToArray());
                    Console.WriteLine("Address seeds created successfully!");
                    await context.SaveChangesAsync();
                }

                /*if (!context.ContentManagement.Any())
                {
                    var contentManagements = ContentManagementFactory.CreateSeedContentManagements();
                    await context.AddRangeAsync(contentManagements.ToArray());
                    Console.WriteLine("ContentManagement seeds created successfully!");
                    await context.SaveChangesAsync();
                }*/

                Console.WriteLine("Seeds created successfully!");
            }
        }
    }
}
