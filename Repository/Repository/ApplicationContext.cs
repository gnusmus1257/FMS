using Microsoft.EntityFrameworkCore;
using Models;
using Models.DatabaseModels;

namespace Repository.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Phones { get; set; }
    }

}