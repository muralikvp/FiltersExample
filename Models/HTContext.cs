using Microsoft.EntityFrameworkCore;

namespace Filters.Models
{
    public class HTContext : DbContext
    {
        public HTContext(DbContextOptions<HTContext> ob) : base(ob)
        {
        }
        public DbSet<User> user { get; set; } = default!;

    }
}
