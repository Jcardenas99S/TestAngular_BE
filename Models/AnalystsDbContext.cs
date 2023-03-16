using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestAngular_BE.Models;

public partial class AnalystsDbContext : DbContext
{
    public AnalystsDbContext()
    {
    }

    public AnalystsDbContext(DbContextOptions<AnalystsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerJc> CustomerJcs { get; set; }

    public virtual DbSet<CustomerTypeJc> CustomerTypeJcs { get; set; }

    public virtual DbSet<EmployeeJc> EmployeeJcs { get; set; }

    public virtual DbSet<PetJc> PetJcs { get; set; }

    public virtual DbSet<PetTypeJc> PetTypeJcs { get; set; }

    public virtual DbSet<ServiceJc> ServiceJcs { get; set; }

    public virtual DbSet<ServiceTypeJc> ServiceTypeJcs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerJc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F8227D3CA");

            entity.ToTable("customer_jc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_email");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_name");
            entity.Property(e => e.CustomerNationalId).HasColumnName("customer_national_id");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("customer_phone");
            entity.Property(e => e.CustomerTypeId).HasColumnName("customer_type_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");

            entity.HasOne(d => d.CustomerType).WithMany(p => p.CustomerJcs)
                .HasForeignKey(d => d.CustomerTypeId)
                .HasConstraintName("FK__customer___custo__01BFCDC5");
        });

        modelBuilder.Entity<CustomerTypeJc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83FB13117C1");

            entity.ToTable("customer_type_jc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerTypeCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("customer_type_code");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
        });

        modelBuilder.Entity<EmployeeJc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__employee__3213E83F43F01319");

            entity.ToTable("employee_jc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_name");
            entity.Property(e => e.EmployeeNationalId).HasColumnName("employee_national_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
        });

        modelBuilder.Entity<PetJc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pet__3213E83FDF3A99C2");

            entity.ToTable("pet_jc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.PetAge).HasColumnName("pet_age");
            entity.Property(e => e.PetName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("pet_name");
            entity.Property(e => e.PetTypeId).HasColumnName("pet_type_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.PetJcs)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__pet__customer_id__0F19C8E3");

            entity.HasOne(d => d.PetType).WithMany(p => p.PetJcs)
                .HasForeignKey(d => d.PetTypeId)
                .HasConstraintName("FK__pet__pet_type_id__100DED1C");
        });

        modelBuilder.Entity<PetTypeJc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pet_type__3213E83F0BA1D0D6");

            entity.ToTable("pet_type_jc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.PetTypeName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pet_type_name");
        });

        modelBuilder.Entity<ServiceJc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__service___3213E83F9DC1AF61");

            entity.ToTable("service_jc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.PetId).HasColumnName("pet_id");
            entity.Property(e => e.ServiceDate)
                .HasColumnType("datetime")
                .HasColumnName("service_date");
            entity.Property(e => e.ServiceTypeId).HasColumnName("service_type_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.ServiceJcs)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_service_jc_employee_jc");

            entity.HasOne(d => d.Pet).WithMany(p => p.ServiceJcs)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK_service_jc_pet_jc");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.ServiceJcs)
                .HasForeignKey(d => d.ServiceTypeId)
                .HasConstraintName("FK_service_jc_service_type_jc");
        });

        modelBuilder.Entity<ServiceTypeJc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__service___3213E83F1F0D0DE3");

            entity.ToTable("service_type_jc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.ServiceTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("service_type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
