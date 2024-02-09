using EFCore_DBLibrary.DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFCore_Activity0201
{
    internal class Program
    {
        // SQLServerManager16.msc Network Configuration - Protocols for... TCP/IP Enabled
        // Step 1: Create the ability to connect and use the AdventureWorks DBContext
        private static IConfigurationRoot? _configuration;
        private static DbContextOptionsBuilder<AdventureWorksContext>? _optionsBuilder;


        static void Main(string[] args)
        {
            BuildConfiguration();
            //Console.WriteLine($"CNSTR: {_configuration.GetConnectionString("AdventureWorks")}");
            BuildOptions();
            ListPeople();
        }

        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        static void BuildOptions()
        {
            _optionsBuilder = new DbContextOptionsBuilder<AdventureWorksContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AdventureWorks"));
        }

        // Step 2: Query the data
        static void ListPeople()
        {
            using (var db = new AdventureWorksContext(_optionsBuilder.Options))
            {
                var people = db.People.OrderByDescending(x => x.LastName).Take(20).ToList();
                foreach (var person in people) Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }

    }
}