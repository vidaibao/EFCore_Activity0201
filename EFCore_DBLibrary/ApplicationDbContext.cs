using Microsoft.EntityFrameworkCore;

namespace EFCore_DBLibrary
{
    public class ApplicationDbContext : DbContext
    {
        //Add a default constructor if scaffolding is needed
        public ApplicationDbContext() { }

        //Add the complex constructor for allowing Dependency Injection
        public ApplicationDbContext(DbContextOptions options)        : base(options)
        {
            //intentionally empty.
        }

        // Command: reverse-engineered an existing database
        //NG Scaffold-DbContext 'DataSource=localhost;Initial Catalog=AdventureWorks;Trusted_Connection=True' Microsoft,EntityFrameWorkCore.SqlServer

        //OK  dotnet ef dbcontext scaffold "Server=localhost;Database=AdventureWorks;Trusted_Connection=True;Encrypt=false" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir DataAcessLayer

    }
}