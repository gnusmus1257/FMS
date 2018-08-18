using Microsoft.EntityFrameworkCore;
using Models;
using Models.DatabaseModels;

namespace Repository.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Phones { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=FMS;Integrated Security=true;");
        }
    }

}