using System;
using System.Collections.Generic;
using Blood_Donation_Management.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace Blood_Donation_Management.EF;

public partial class BloodBankContext : DbContext
{
    public BloodBankContext()
    {
    }

    public BloodBankContext(DbContextOptions<BloodBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<Donor> Donors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BloodBankDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Donation>(entity =>
        {
            entity.ToTable("Donation");

            entity.Property(e => e.CampName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Donor).WithMany(p => p.Donations)
                .HasForeignKey(d => d.DonorId)
                .HasConstraintName("FK_Donation_Donation");
        });

        modelBuilder.Entity<Donor>(entity =>
        {
            entity.ToTable("Donor");

            entity.Property(e => e.BloodGroup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
