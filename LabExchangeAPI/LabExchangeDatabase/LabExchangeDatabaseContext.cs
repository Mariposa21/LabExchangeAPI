using System;
using System.Collections.Generic;
using LabExchangeAPI.Controllers;
using Microsoft.EntityFrameworkCore;

namespace LabExchangeAPI.LabExchangeDatabase;

public partial class LabExchangeDatabaseContext : DbContext
{
    public LabExchangeDatabaseContext()
    {
    }

    public LabExchangeDatabaseContext(DbContextOptions<LabExchangeDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblTestResult> TblTestResults { get; set; }

    public virtual DbSet<TblTestType> TblTestTypes { get; set; }

    public virtual DbSet<TblTestTypeCategory> TblTestTypeCategories { get; set; }

    public virtual DbSet<TblVendor> TblVendors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblTestResult>(entity =>
        {
            entity.HasKey(e => e.TestResultId).HasName("PK__tblTestR__E246358720548DCC");

            entity
                .ToTable("tblTestResult"); 

            entity.Property(e => e.FlagForReview).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsValidTestResult).HasDefaultValueSql("((0))");
            entity.Property(e => e.PatientDateOfBirth).HasColumnType("date");
            entity.Property(e => e.PatientMedicalRecordNum)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.ResultGenerationDateTime).HasColumnType("datetime");
            entity.Property(e => e.SubmissionDateTime).HasColumnType("datetime");
            entity.Property(e => e.TestResultNotes)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.TestResultShortDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.VendorResultId)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ResultTestType).WithMany(p => p.TblTestResults)
                .HasForeignKey(d => d.ResultTestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblTestRe__Resul__5441852A");

            entity.HasOne(d => d.Vendor).WithMany(p => p.TblTestResults)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblTestRe__Vendo__5535A963");
        });

        modelBuilder.Entity<TblTestType>(entity =>
        {
            entity.HasKey(e => e.TestTypeId).HasName("PK__tblTestT__9BB876A6EADA596E");

            entity
                .ToTable("tblTestType"); 

            entity.Property(e => e.TestTypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TestTypeNormalValues)
                .HasMaxLength(4000)
                .IsUnicode(false);

            entity.HasOne(d => d.TestTypeCategory).WithMany(p => p.TblTestTypes)
                .HasForeignKey(d => d.TestTypeCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblTestTy__TestT__4BAC3F29");
        });

        modelBuilder.Entity<TblTestTypeCategory>(entity =>
        {
            entity.HasKey(e => e.TestTypeCategoryId).HasName("PK__tblTestT__4E6B19620CA7E548");

            entity.ToTable("tblTestTypeCategory");

            entity.Property(e => e.TestTypeCategoryId).ValueGeneratedOnAdd();
            entity.Property(e => e.TestTypeCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblVendor>(entity =>
        {
            entity.HasKey(e => e.VendorId);

            entity
                .ToTable("tblVendor"); 

            entity.Property(e => e.VendorCity)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VendorExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.VendorPhone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VendorState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.VendorStreetAddress1)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.VendorStreetAddress2)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.VendorZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
