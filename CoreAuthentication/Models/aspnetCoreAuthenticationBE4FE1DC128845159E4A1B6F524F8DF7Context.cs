using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreAuthentication.Models
{
    public partial class aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context : DbContext
    {
        public aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context()
        {
        }

        public aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context(DbContextOptions<aspnetCoreAuthenticationBE4FE1DC128845159E4A1B6F524F8DF7Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<EducationBoard> EducationBoard { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<EmailsGroup> EmailsGroup { get; set; }
        public virtual DbSet<EmailsOfEmailsGroup> EmailsOfEmailsGroup { get; set; }
        public virtual DbSet<Fax> Fax { get; set; }
        public virtual DbSet<FaxsGroup> FaxsGroup { get; set; }
        public virtual DbSet<FaxsOfFaxsGroup> FaxsOfFaxsGroup { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<PhonesGroup> PhonesGroup { get; set; }
        public virtual DbSet<PhonesOfPhonesGroup> PhonesOfPhonesGroup { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StudentAddress> StudentAddress { get; set; }
        public virtual DbSet<StudentEducation> StudentEducation { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<SyllabusType> SyllabusType { get; set; }
        public virtual DbSet<WebSite> WebSite { get; set; }
        public virtual DbSet<WebSitesGroup> WebSitesGroup { get; set; }
        public virtual DbSet<WebSitesOfWebSitesGroup> WebSitesOfWebSitesGroup { get; set; }

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
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasMaxLength(450);

                entity.Property(e => e.DistrinctId).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasMaxLength(450);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StateId).HasMaxLength(450);
            });

            modelBuilder.Entity<EducationBoard>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email1)
                    .HasColumnName("EMail")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EmailsGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailsOfEmailsGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmailId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailsGroupId).HasColumnType("numeric(12, 0)");
            });

            modelBuilder.Entity<Fax>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fax1)
                    .HasColumnName("Fax")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<FaxsGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FaxsOfFaxsGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FaxId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FaxsGroupId).HasColumnType("numeric(12, 0)");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhNumber).HasColumnType("numeric(12, 0)");
            });

            modelBuilder.Entity<PhonesGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhonesOfPhonesGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PhoneGroupId).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.PhoneId)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressLine1).HasMaxLength(450);

                entity.Property(e => e.AddressLine2).HasMaxLength(450);

                entity.Property(e => e.AddressLine3).HasMaxLength(450);

                entity.Property(e => e.CityId).HasMaxLength(450);

                entity.Property(e => e.CountryId).HasMaxLength(450);

                entity.Property(e => e.DistrictId).HasMaxLength(450);

                entity.Property(e => e.EmailsGroupId).HasMaxLength(450);

                entity.Property(e => e.FaxsGroupId).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhonesGroupId).HasMaxLength(450);

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(450);

                entity.Property(e => e.StateId).HasMaxLength(450);

                entity.Property(e => e.WebSitesGroupId).HasMaxLength(450);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryId).HasMaxLength(450);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentAddress>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressLine1).HasMaxLength(450);

                entity.Property(e => e.AddressLine2).HasMaxLength(450);

                entity.Property(e => e.AddressLine3).HasMaxLength(450);

                entity.Property(e => e.CityId).HasMaxLength(450);

                entity.Property(e => e.CountryId).HasMaxLength(450);

                entity.Property(e => e.DistrictId).HasMaxLength(450);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailsGroupId).HasMaxLength(450);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FaxsGroupId).HasMaxLength(450);

                entity.Property(e => e.GurdianName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhonesGroupId).HasMaxLength(450);

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(450);

                entity.Property(e => e.StateId).HasMaxLength(450);

                entity.Property(e => e.WebSitesGroupId).HasMaxLength(450);
            });

            modelBuilder.Entity<StudentEducation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BoardId).HasMaxLength(450);

                entity.Property(e => e.ClassId).HasMaxLength(450);

                entity.Property(e => e.ForAcademicYearFrom).HasColumnType("datetime");

                entity.Property(e => e.ForAcademicYearTo).HasColumnType("datetime");

                entity.Property(e => e.SchoolId).HasMaxLength(450);

                entity.Property(e => e.StudentId).HasMaxLength(450);

                entity.Property(e => e.SyllabusId).HasMaxLength(450);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SyllabusType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebSite>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.WebSite1)
                    .HasColumnName("WebSite")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WebSitesGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebSitesOfWebSitesGroup>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.WebSiteId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WebSitesGroupId).HasColumnType("numeric(12, 0)");
            });
        }
    }
}
