using System;
using System.Collections.Generic;
using DAL.UserModel;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.Data;

public partial class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public virtual DbSet<TbExam> TbExams { get; set; }

    public virtual DbSet<TbQuestion> TbQuestions { get; set; }

    public virtual DbSet<TbSubjectsTaught> TbSubjectsTaughts { get; set; }

    public virtual DbSet<TbUserAnswer> TbUserAnswers { get; set; }

    public virtual DbSet<TbUserExam> TbUserExams { get; set; }

    public virtual DbSet<VwSEQuestion> VwSEQuestions { get; set; }

    public virtual DbSet<VwSubjectTaughtExam> VwSubjectTaughtExams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = SystemExa; Integrated Security = SSPI; TrustServerCertificate = True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<TbExam>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.SubjectTaugh).WithMany(p => p.TbExams)
                .HasForeignKey(d => d.SubjectTaughId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbExams_TbSubjectsTaught");
        });

        modelBuilder.Entity<TbQuestion>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.QuestionOrder).HasColumnType("int");

            entity.HasOne(d => d.Exam).WithMany(p => p.TbQuestions)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbQuestions_TbExams");
        });

        modelBuilder.Entity<TbSubjectsTaught>(entity =>
        {
            entity.ToTable("TbSubjectsTaught");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.NameSubjects).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbUserAnswer>(entity =>
        {

	entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.SelectedAnswer).HasColumnType("nvarchar(MAX)");
            entity.Property(e => e.IsCorrect).HasColumnType("bit");
            entity.Property(e => e.Result).HasColumnType("int");

            entity.HasOne(d => d.Question).WithMany(p => p.TbUserAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbUserAnswers_TbQuestions");

            entity.HasOne(d => d.UserExam).WithMany(p => p.TbUserAnswers)
                .HasForeignKey(d => d.UserExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbUserAnswers_TbUserExams");
        });

        modelBuilder.Entity<TbUserExam>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnType("uniqueidentifier");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Score).HasColumnType("int");
            entity.Property(e => e.Resultes).HasColumnType("Float");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Exam).WithMany(p => p.TbUserExams)
                .HasForeignKey(d => d.ExamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbUserExams_TbExams");
        });

        modelBuilder.Entity<VwSEQuestion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwSEQuestions");

            entity.Property(e => e.NameSubjects).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<VwSubjectTaughtExam>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwSubjectTaughtExams");

            entity.Property(e => e.NameSubjects).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
