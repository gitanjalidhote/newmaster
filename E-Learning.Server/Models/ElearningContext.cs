using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Server.Models;

public partial class ElearningContext : DbContext
{
    public ElearningContext()
    {
    }

    public ElearningContext(DbContextOptions<ElearningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<SetExam> SetExams { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SIPLGETGD;Database=ELearning; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__admin__43AA41418845BE26");

            entity.ToTable("admin");

            entity.HasIndex(e => e.AdminName, "UQ__admin__37EDA0F7379AF229").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.AdminName)
                .HasMaxLength(20)
                .HasColumnName("admin_name");
            entity.Property(e => e.AdminPass)
                .HasMaxLength(20)
                .HasColumnName("admin_pass");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QueId).HasName("PK__question__D2E71F28A0DF5E03");

            entity.ToTable("questions");

            entity.HasIndex(e => e.Qd, "UQ__question__32152F2C38902583").IsUnique();

            entity.HasIndex(e => e.Qc, "UQ__question__32152F2DB2D93103").IsUnique();

            entity.HasIndex(e => e.Qb, "UQ__question__32152F2E9417B2BC").IsUnique();

            entity.HasIndex(e => e.Qa, "UQ__question__32152F2F82DC686B").IsUnique();

            entity.Property(e => e.QueId).HasColumnName("Que_id");
            entity.Property(e => e.Qa)
                .HasMaxLength(20)
                .HasColumnName("QA");
            entity.Property(e => e.Qb)
                .HasMaxLength(20)
                .HasColumnName("QB");
            entity.Property(e => e.Qc)
                .HasMaxLength(20)
                .HasColumnName("QC");
            entity.Property(e => e.QcorrectAns).HasMaxLength(20);
            entity.Property(e => e.Qd)
                .HasMaxLength(20)
                .HasColumnName("QD");
            entity.Property(e => e.QueText).HasColumnName("que_text");
        });

        modelBuilder.Entity<SetExam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__setExam__9C8C7BE9061B2D80");

            entity.ToTable("setExam");

            entity.Property(e => e.ExamId).HasColumnName("exam_id");
            entity.Property(e => e.ExamDate)
                .HasColumnType("datetime")
                .HasColumnName("exam_date");
            entity.Property(e => e.ExamFkStd).HasColumnName("exam_fk_std");
            entity.Property(e => e.ExamName)
                .HasMaxLength(20)
                .HasColumnName("exam_name");
            entity.Property(e => e.StdScore).HasColumnName("std_score");

            entity.HasOne(d => d.ExamFkStdNavigation).WithMany(p => p.SetExams)
                .HasForeignKey(d => d.ExamFkStd)
                .HasConstraintName("FK__setExam__exam_fk__5812160E");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId).HasName("PK__student__0B0245BAF99AE711");

            entity.ToTable("student");

            entity.HasIndex(e => e.StdName, "UQ__student__BA9CAC34D1796B19").IsUnique();

            entity.Property(e => e.StdId).HasColumnName("std_id");
            entity.Property(e => e.StdName)
                .HasMaxLength(20)
                .HasColumnName("std_name");
            entity.Property(e => e.StdPass)
                .HasMaxLength(20)
                .HasColumnName("std_pass");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
