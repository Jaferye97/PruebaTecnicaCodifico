using Microsoft.EntityFrameworkCore;

namespace ReporitorySqlServer.Context
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext()
        {
        }

        public EntityDbContext(DbContextOptions<EntityDbContext> options)
        : base(options)
        { }
    }
}
