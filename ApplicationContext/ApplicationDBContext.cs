using hackaton.Models;
using Microsoft.EntityFrameworkCore;

namespace hackaton.ApplicationContext
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    }
}
