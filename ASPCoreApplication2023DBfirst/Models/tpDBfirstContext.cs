using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPCoreApplication2023DBfirst.Models
{
    public partial class tpDBfirstContext : DbContext
    {
        public tpDBfirstContext()
        {
        }

        public tpDBfirstContext(DbContextOptions<tpDBfirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TECHTYCOON;Initial Catalog=tpDBfirst;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Movie_Customer");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Movie_Genre");

                entity.HasMany(d => d.Customers)
                    .WithMany(p => p.MoviesNavigation)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieCustomer",
                        l => l.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MovieCustomer_Customer"),
                        r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId").HasConstraintName("FK_MovieCustomer_Movie"),
                        j =>
                        {
                            j.HasKey("MovieId", "CustomerId").HasName("PK__MovieCus__D198725744D45CC3");

                            j.ToTable("MovieCustomer");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
