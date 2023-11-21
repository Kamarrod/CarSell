using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace WebApp.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var b = configuration.GetConnectionString("sqlConnection");
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(@"Server=localhost;
                                   Database=CarSeller;
                                   User Id=postgres;
                                   Password=Vbhcfzgjdrf09;
                                   Trusted_Connection=True;
                                   TrustServerCertificate=False;
                                   Encrypt=False;",//(configuration.GetConnectionString("sqlConnection"),
            b => b.MigrationsAssembly("WebApp"));
            return new RepositoryContext(builder.Options);
        }
    }
}
