using Microsoft.EntityFrameworkCore;

namespace WMS_Lists.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MAIRCombo> MAIRCombos { get; set; }
        public DbSet<P1Combo> P1Combo { get; set; }
        public DbSet<P1TLC1Combo> P1TLC1Combo { get; set; }
        public DbSet<P1TLC2Combo> P1TLC2Combo { get; set; }
        public DbSet<TMillCombo> TMillCombo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MAIRCombo>()
                .ToView("MAIRComboView")
                .HasNoKey();

            modelBuilder.Entity<P1Combo>()
                .ToView("P1ComboView")
                .HasNoKey();

            modelBuilder.Entity<P1TLC1Combo>()
                .ToView("WMS_P1TLC1")
                .HasNoKey();

            modelBuilder.Entity<P1TLC2Combo>()
                .ToView("WMS_P1TLC2")
                .HasNoKey();

            modelBuilder.Entity<TMillCombo>()
                .ToView("TMILLComboView")
                .HasNoKey();

            modelBuilder.Entity<CMillCombo>()
                .ToView("CMillComboView")
                .HasNoKey();
        }
    }
}
