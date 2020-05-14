using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ObstacleDb
{
    public partial class PBNContext : DbContext
    {
        public PBNContext()
        {
        }

        public PBNContext(DbContextOptions<PBNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Obstacle> Obstacle { get; set; }
        public virtual DbSet<Runway> Runway { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=PBN;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Obstacle>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ObsAglHeight).HasColumnName("ObsAgl_Height");

                entity.Property(e => e.ObsIcao)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ObsLatitudeDms).HasColumnName("ObsLatitudeDMS");

                entity.Property(e => e.ObsLatitudeHemisphere)
                    .HasColumnName("ObsLatitude_Hemisphere")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ObsLongitudeDd).HasColumnName("ObsLongitude_DD");

                entity.Property(e => e.ObsLongitudeDms).HasColumnName("ObsLongitudeDMS");

                entity.Property(e => e.ObsLongitudeHemisphere)
                    .HasColumnName("ObsLongitude_Hemisphere")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ObsMslHeight).HasColumnName("ObsMsl_Height");

                entity.Property(e => e.ObsStudy)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ObsType)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ObstLatitudeDd).HasColumnName("ObstLatitude_DD");
            });

            modelBuilder.Entity<Runway>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("runway");

                entity.Property(e => e.Icao)
                    .HasColumnName("icao")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Long).HasColumnName("long");

                entity.Property(e => e.Runway1)
                    .HasColumnName("runway")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
