using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GCStudyBuddyAPI.Entities;

public partial class GcstudyBuddyDbContext : DbContext
{
    public GcstudyBuddyDbContext()
    {
    }

    public GcstudyBuddyDbContext(DbContextOptions<GcstudyBuddyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Qa> Qas { get; set; }

    public virtual DbSet<UserFavorite> UserFavorites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Qa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QA__3214EC07F298ABDF");

            entity.ToTable("QA");

            entity.Property(e => e.Answer).HasMaxLength(3000);
            entity.Property(e => e.Question).HasMaxLength(3000);
        });

        modelBuilder.Entity<UserFavorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__UserFavo__CE74FAD5BBA392D5");

            entity.Property(e => e.UserId).HasMaxLength(30);

            entity.HasOne(d => d.Question).WithMany(p => p.UserFavorites)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserFavor__Quest__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
