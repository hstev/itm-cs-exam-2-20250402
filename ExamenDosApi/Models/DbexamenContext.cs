using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamenDosApi.Models;

public partial class DbexamenContext : DbContext
{
    public DbexamenContext()
    {
    }

    public DbexamenContext(DbContextOptions<DbexamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FotoInfraccion> FotoInfraccions { get; set; }

    public virtual DbSet<Infraccion> Infraccions { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=IDEAPAD3\\SQLEXPRESS; Database=DBExamen; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FotoInfraccion>(entity =>
        {
            entity.HasKey(e => e.IdFoto);

            entity.ToTable("FotoInfraccion");

            entity.Property(e => e.IdFoto).HasColumnName("idFoto");
            entity.Property(e => e.IdInfraccion).HasColumnName("idInfraccion");
            entity.Property(e => e.NombreFoto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdInfraccionNavigation).WithMany(p => p.FotoInfraccions)
                .HasForeignKey(d => d.IdInfraccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FotoInfraccion_Infraccion");
        });

        modelBuilder.Entity<Infraccion>(entity =>
        {
            entity.HasKey(e => e.IdFotoMulta);

            entity.ToTable("Infraccion");

            entity.Property(e => e.IdFotoMulta).HasColumnName("idFotoMulta");
            entity.Property(e => e.FechaInfraccion).HasColumnType("datetime");
            entity.Property(e => e.PlacaVehiculo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TipoInfraccion)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.PlacaVehiculoNavigation).WithMany(p => p.Infraccions)
                .HasForeignKey(d => d.PlacaVehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Infraccion_Vehiculo");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Placa);

            entity.ToTable("Vehiculo");

            entity.Property(e => e.Placa)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoVehiculo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
