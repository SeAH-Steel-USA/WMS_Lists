using Microsoft.EntityFrameworkCore;

namespace WMS_Lists.Data
{
    public class MAIRDbContext : DbContext
    {
        public MAIRDbContext(DbContextOptions<MAIRDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventLoggerWeight>()
                .ToTable("WEIGHT", "EVENT_LOGGER")
                .HasNoKey();
        }
    }
}
