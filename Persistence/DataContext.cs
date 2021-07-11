using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        const string DefaultConnection = "Data source=reactivities.db";
        //public string SqlServerConnectionString => ConfigurationManager..AppSettings["SqlServerConnectionString"];
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //if (!options.IsConfigured)
            //{
            //    IConfigurationRoot configuration = new ConfigurationBuilder()
            //       .SetBasePath(Directory.GetCurrentDirectory())
            //       .AddJsonFile("appsettings.json")
            //       .Build();
            //    var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
            //    options.UseSqlServer(connectionString);
            //}
            if (!options.IsConfigured)
            {
                options.UseSqlite(DefaultConnection);
            }

            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
            .HasData(
                new Value{Id = 1 , Name = "Value 101"},
                new Value{Id = 2 , Name = "Value 102"},
                new Value{Id = 3 , Name = "Value 103"}
            );
            base.OnModelCreating(builder);
        }


        public DbSet<Value> Values { get; set; }
    }
}

