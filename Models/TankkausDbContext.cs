using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RestApiBensas.Models;

public partial class TankkausDbContext : DbContext
{
    public TankkausDbContext()
    {
    }

    public TankkausDbContext(DbContextOptions<TankkausDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ajoneuvot> Ajoneuvots { get; set; }

    public virtual DbSet<Käyttäjät> Käyttäjäts { get; set; }

    public virtual DbSet<Tankkau> Tankkaus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            return;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ajoneuvot>(entity =>
        {
            entity.HasKey(e => e.AjoneuvoId).HasName("PK__Ajoneuvo__E0953F7BCFD8F88B");

            entity.ToTable("Ajoneuvot");

            entity.HasIndex(e => e.Rekisterinumero, "UQ__Ajoneuvo__7446AE9EE1C4089D").IsUnique();

            entity.Property(e => e.AjoneuvoId).HasColumnName("Ajoneuvo_Id");
            entity.Property(e => e.KäyttäjäId).HasColumnName("Käyttäjä_Id");
            entity.Property(e => e.Malli)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Merkki)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rekisterinumero)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Käyttäjä).WithMany(p => p.Ajoneuvots)
                .HasForeignKey(d => d.KäyttäjäId)
                .HasConstraintName("FK__Ajoneuvot__Käytt__60A75C0F");
        });

        modelBuilder.Entity<Käyttäjät>(entity =>
        {
            entity.HasKey(e => e.KäyttäjäId).HasName("PK__Käyttäjä__914A7D755076997C");

            entity.ToTable("Käyttäjät");

            entity.HasIndex(e => e.Sähköposti, "UQ__Käyttäjä__2231DE4D40B86914").IsUnique();

            entity.Property(e => e.KäyttäjäId).HasColumnName("Käyttäjä_Id");
            entity.Property(e => e.Etunimi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salasana)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Sukunimi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sähköposti)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tankkau>(entity =>
        {
            entity.HasKey(e => e.TankkausId).HasName("PK__Tankkaus__4354D1A48414621C");

            entity.Property(e => e.TankkausId).HasColumnName("Tankkaus_Id");
            entity.Property(e => e.AjoneuvoId).HasColumnName("Ajoneuvo_Id");
            entity.Property(e => e.Euroa).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Litraa).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Ajoneuvo).WithMany(p => p.Tankkaus)
                .HasForeignKey(d => d.AjoneuvoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tankkaus__Ajoneu__6383C8BA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
