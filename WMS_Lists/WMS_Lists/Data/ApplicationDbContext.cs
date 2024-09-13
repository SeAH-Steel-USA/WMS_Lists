using Microsoft.EntityFrameworkCore;

namespace WMS_Lists.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FloatTableP1_Table> FloatTableP1 { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FloatTableP1_Table>()
                .ToTable("FloatTableP1")
                .HasNoKey();
        }
    }
}
