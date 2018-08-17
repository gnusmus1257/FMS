using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Phones { get; set; }
    }

}