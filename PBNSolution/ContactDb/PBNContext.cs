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
                //optionsBuilder.UseSqlServer("Data Source = 'seavvbifssrs03, 1450'; Initial Catalog = PBN; Integrated Security = True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Obstacle>(entity =>
            {
                entity.HasKey(e => e.ObsId)
                    .HasName("PK_Contact");

                entity.Property(e => e.ObsIcao).HasMaxLength(10);

                entity.Property(e => e.ObsLatitudeHemisphere).HasMaxLength(10);

                entity.Property(e => e.ObsLongitudeHemisphere).HasMaxLength(10);

                entity.Property(e => e.ObsStudy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ObsType).HasMaxLength(50);
            });

            modelBuilder.Entity<Runway>(entity =>
            {
                entity.HasKey(e => e.Icao);

                entity.ToTable("runway");

                entity.Property(e => e.Icao)
                    .HasColumnName("icao")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Long).HasColumnName("long");

                entity.Property(e => e.RWY)
                    .HasColumnName("runway")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
