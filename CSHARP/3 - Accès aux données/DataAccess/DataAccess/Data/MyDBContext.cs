using DataAccess.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Data
{
    public class MyDBContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public MyDBContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your connection string.
            // var connectionString = "server=localhost;user=root;database=personne;port=3306";
            var connectionString = _configuration.GetConnectionString("Default");

            var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        public DbSet<Test> Tests { get; set; }
        



    }
}
