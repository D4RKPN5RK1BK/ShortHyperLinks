using Microsoft.EntityFrameworkCore;
using ShortHyperLinks.Models;

namespace ShortHyperLinks.Data
{
    public class SHLContext : DbContext
    {
        public DbSet<HyperLink> HyperLinks { get; set; }
        public SHLContext(DbContextOptions<SHLContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder buidler)
        //{

        //}


    }
}
