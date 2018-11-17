using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreAuthentication.EntityModels
{
    public partial class BrideOrGroomDBContext : DbContext
    {
        public BrideOrGroomDBContext()
        {
        }

        public BrideOrGroomDBContext(DbContextOptions<BrideOrGroomDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BrideOrGroom> BrideOrGroom { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NB093L1\\SQLEXPRESS;Database=aspnet-CoreAuthentication-BE4FE1DC-1288-4515-9E4A-1B6F524F8DF7;user Id=vista;Password=star;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrideOrGroom>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FathersName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MothersName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
