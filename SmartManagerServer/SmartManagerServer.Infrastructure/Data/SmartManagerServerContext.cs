using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartManagerServer.Core.Entities.SmartManagerServer;
using Object = SmartManagerServer.Core.Entities.SmartManagerServer.Object;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SmartManagerServer.Infrastructure.Data
{
    public partial class SmartManagerServerContext : DbContext
    {
        public SmartManagerServerContext()
        {
        }

        public SmartManagerServerContext(DbContextOptions<SmartManagerServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DocumentObject> DocumentObject { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeCalculation> EmployeeCalculation { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<ImageObject> ImageObject { get; set; }
        public virtual DbSet<Object> Object { get; set; }
        public virtual DbSet<OutlayEmployee> OutlayEmployee { get; set; }
        public virtual DbSet<OutlayMaterial> OutlayMaterial { get; set; }
        public virtual DbSet<Payout> Payout { get; set; }
        public virtual DbSet<Prepaid> Prepaid { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentObject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileId).HasColumnName("FIleId");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.DocumentObject)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentObject_File");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.DocumentObject)
                    .HasForeignKey(d => d.ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentObject_Object");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(300);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(12);

                entity.Property(e => e.Recidence).HasMaxLength(250);

                entity.Property(e => e.Specialization).HasMaxLength(50);

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EducationId)
                    .HasConstraintName("FK_Employee_Education");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Employee_File");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Status");
            });

            modelBuilder.Entity<EmployeeCalculation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.TermOfWork).HasMaxLength(300);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeCalculation)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeCalculation_Employee");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GuidName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OriginalName).HasMaxLength(250);
            });

            modelBuilder.Entity<ImageObject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.ImageObject)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImageObject_File");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.ImageObject)
                    .HasForeignKey(d => d.ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImageObject_Object");
            });

            modelBuilder.Entity<Object>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CloseDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Object)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Object_Status");
            });

            modelBuilder.Entity<OutlayEmployee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OutlayEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutlayEmployee_Employee");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.OutlayEmployee)
                    .HasForeignKey(d => d.ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutlayEmployee_Object");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OutlayEmployee)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutlayEmployee_Status");
            });

            modelBuilder.Entity<OutlayMaterial>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.OutlayMaterial)
                    .HasForeignKey(d => d.ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutlayMaterial_Object");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OutlayMaterial)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutlayMaterial_Status");
            });

            modelBuilder.Entity<Payout>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Payout)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK_Payout_File");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.Payout)
                    .HasForeignKey(d => d.ObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payout_Object1");
            });

            modelBuilder.Entity<Prepaid>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Prepaid)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prepaid_Employee");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
