using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-K15F7ED;Database=CRUDEmployee;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.Property(e => e.EmpId).HasColumnName("Emp_Id");
            entity.Property(e => e.EmpAddress)
                .HasMaxLength(250)
                .HasColumnName("Emp-Address");
            entity.Property(e => e.EmpCode)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Emp_Code");
            entity.Property(e => e.EmpDepartment)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Emp_Department");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Emp_Designation");
            entity.Property(e => e.EmpEmailId)
                .HasMaxLength(50)
                .HasColumnName("Emp_EmailId");
            entity.Property(e => e.EmpMobileNumber)
                .HasMaxLength(50)
                .HasColumnName("Emp_MobileNumber");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Emp_Name");
            entity.Property(e => e.EmpSalary)
                .HasMaxLength(50)
                .HasColumnName("Emp_Salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
