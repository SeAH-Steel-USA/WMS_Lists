﻿using Microsoft.EntityFrameworkCore;

namespace WMS_Lists.Data
{
    public class MAIRDbContext : DbContext
    {
        public MAIRDbContext(DbContextOptions<MAIRDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventLoggerWeight> EVENT_LOGGER_WEIGHT { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventLoggerWeight>()
                .ToTable("WEIGHT", "EVENT_LOGGER")
                .HasNoKey();
        }
    }
}
