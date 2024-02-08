using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyServices.Entities;

namespace MyServices.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("ApiDatabase"))
            .UseSnakeCaseNamingConvention();
        }
        public DbSet<People> Users { get; set; }

    }
}
