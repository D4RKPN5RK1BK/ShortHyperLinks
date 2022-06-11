using Microsoft.EntityFrameworkCore;

namespace ShortHyperLinks.Data
{
    public class SHLContext : DbContext
    {
        public DbSet<HyperLink> HyperLinks { get; set; }

        public SHLContext(DbContextOptions<SHLContext> options) : base(options) { }


    }
}
