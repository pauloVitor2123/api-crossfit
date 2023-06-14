using SistemaCrossfit.Factories;

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

                if (!context.Genre.Any())
                {
                    var profiles = GenreFactory.CreateSeedGenres();
                    await context.AddRangeAsync(profiles.ToArray());
                    Console.WriteLine("Genre seeds created successfully!");
                }
                await context.SaveChangesAsync();

                if (!context.User.Any())
                {
                    var users = UserFactory.CreateSeedUsers();
                    await context.AddRangeAsync(users.ToArray());
                    Console.WriteLine("Users seeds created successfully!");
                }
                await context.SaveChangesAsync();

                if (!context.Student.Any())
                {
                    var students = StudentFactory.CreateSeedStudents();
                    await context.AddRangeAsync(students.ToArray());
                    Console.WriteLine("Students seeds created successfully!");
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
                if (!context.Exercise.Any())
                {
                    var exercises = ExerciseFactory.CreateSeedExercises();
                    await context.AddRangeAsync(exercises.ToArray());
                    Console.WriteLine("Exercises seeds created successfully!");
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
                await context.SaveChangesAsync();
                Console.WriteLine("Seeds created successfully!");
            }
        }
    }
}
