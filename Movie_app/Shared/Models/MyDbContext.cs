using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Movie_app.Shared.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=MyConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Genero");

                entity.Property(e => e.Tipo).HasMaxLength(50);
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("Pelicula");

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.FechaSalida)
                    .HasMaxLength(50)
                    .HasColumnName("Fecha_salida");

                entity.Property(e => e.Puntuacion).HasMaxLength(10);

                entity.Property(e => e.Titulo).HasMaxLength(50);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pelicula__IdGene__5AEE82B9");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasIndex(e => e.IdPelicula, "UQ__Prestamo__60537FD188445743")
                    .IsUnique();

                entity.Property(e => e.FechaPrestamo)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_prestamo")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Prestatario).HasMaxLength(100);

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithOne(p => p.Prestamo)
                    .HasForeignKey<Prestamo>(d => d.IdPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prestamos__IdPel__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
