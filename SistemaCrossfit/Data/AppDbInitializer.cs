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
                Console.WriteLine("Seeds created successfully!");

            }
        }
    }
}
