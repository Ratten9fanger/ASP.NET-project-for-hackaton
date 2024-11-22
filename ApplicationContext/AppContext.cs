using Microsoft.EntityFrameworkCore;

namespace hackaton.ApplicationContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    }
}
