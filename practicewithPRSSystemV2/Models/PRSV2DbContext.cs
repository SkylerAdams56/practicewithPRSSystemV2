using Microsoft.EntityFrameworkCore;

namespace practicewithPRSSystemV2.Models
{
    public class PRSV2DbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Requestlines> Requestlines { get; set; }
        public PRSV2DbContext(DbContextOptions<PRSV2DbContext> options) : base(options) { }
    }
}
