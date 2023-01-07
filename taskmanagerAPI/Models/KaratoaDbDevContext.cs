using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace taskmanagerAPI.Models;

public partial class KaratoaDbDevContext : DbContext
{
    public KaratoaDbDevContext()
    {
    }

    public KaratoaDbDevContext(DbContextOptions<KaratoaDbDevContext> options)
        : base(options)
    {
    }


    public virtual DbSet<BlTask> BlTasks { get; set; }

    public virtual DbSet<BlUser> BlUsers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("karatoa_dev");

        modelBuilder.Entity<BlTask>(entity =>
        {
            entity.ToTable("BL_Task");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Prority).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<BlUser>(entity =>
        {
            entity.ToTable("BL_User");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
