using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TP2console.Models.EntityFramework
{
    public partial class FilmsDBContext : DbContext
    {
        public FilmsDBContext()
        {
        }

        public FilmsDBContext(DbContextOptions<FilmsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avis> Avis { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres;password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avis>(entity =>
            {
                entity.HasKey(e => new { e.Film, e.Utilisateur })
                    .HasName("pk_avis");

                entity.ToTable("avis");

                entity.Property(e => e.Film).HasColumnName("film");

                entity.Property(e => e.Utilisateur).HasColumnName("utilisateur");

                entity.Property(e => e.Avis1).HasColumnName("avis");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.FilmNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Film)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_film");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Utilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_utilisateur");
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("categorie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("film");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categorie).HasColumnName("categorie");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CategorieNavigation)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.Categorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_categorie");
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.ToTable("utilisateur");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(50);

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("pwd")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
