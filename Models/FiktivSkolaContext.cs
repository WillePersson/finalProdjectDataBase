using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace finalProdjectDataBase.Models
{
    public partial class FiktivSkolaContext : DbContext
    {
        public FiktivSkolaContext()
        {
        }

        public FiktivSkolaContext(DbContextOptions<FiktivSkolaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseGrade> CourseGrades { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Janitor> Janitors { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<Principal> Principals { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=FiktivSkolaDatabase;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("Admin_Id");

                entity.Property(e => e.FkPersonalId).HasColumnName("FkPersonal_Id");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.HasOne(d => d.FkPersonal)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.FkPersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK Personal in Admin");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("Class_Id");

                entity.Property(e => e.ClassName).HasMaxLength(50);

                entity.Property(e => e.FkTeacherId).HasColumnName("FkTeacher_Id");

                entity.HasOne(d => d.FkTeacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.FkTeacherId)
                    .HasConstraintName("FK Teacher In Class");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.FkClassId).HasColumnName("FkClass_Id");

                entity.Property(e => e.FkTeacherId).HasColumnName("FkTeacher_Id");
            });

            modelBuilder.Entity<CourseGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Course_Grades");

                entity.Property(e => e.CourseDate).HasColumnType("date");

                entity.Property(e => e.CourseGrade1)
                    .HasMaxLength(10)
                    .HasColumnName("CourseGrade");

                entity.Property(e => e.FkCourseId).HasColumnName("FkCourse_Id");

                entity.Property(e => e.FkStudentId).HasColumnName("FkStudent_Id");

                entity.Property(e => e.FkTeacherId).HasColumnName("FkTeacher_Id");

                entity.HasOne(d => d.FkCourse)
                    .WithMany()
                    .HasForeignKey(d => d.FkCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Grades_Course");

                entity.HasOne(d => d.FkStudent)
                    .WithMany()
                    .HasForeignKey(d => d.FkStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Grades_Student");

                entity.HasOne(d => d.FkTeacher)
                    .WithMany()
                    .HasForeignKey(d => d.FkTeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Grades_Teacher");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Department_Name");
            });

            modelBuilder.Entity<Janitor>(entity =>
            {
                entity.ToTable("Janitor");

                entity.Property(e => e.JanitorId).HasColumnName("Janitor_Id");

                entity.Property(e => e.FkPersonalId).HasColumnName("FkPersonal_Id");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.HasOne(d => d.FkPersonal)
                    .WithMany(p => p.Janitors)
                    .HasForeignKey(d => d.FkPersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK Perosnal in Janitor");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("Personal");

                entity.Property(e => e.PersonalId)
                    .ValueGeneratedNever()
                    .HasColumnName("Personal_Id");

                entity.Property(e => e.FkDepartmentId).HasColumnName("FkDepartment_Id");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.HireDate).HasColumnType("date");

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.Property(e => e.Profession).HasMaxLength(50);

                entity.HasOne(d => d.FkDepartment)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.FkDepartmentId)
                    .HasConstraintName("FK_Department in _Personal");
            });

            modelBuilder.Entity<Principal>(entity =>
            {
                entity.ToTable("Principal");

                entity.Property(e => e.PrincipalId).HasColumnName("Principal_Id");

                entity.Property(e => e.FkPersonalId).HasColumnName("FkPersonal_Id");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.HasOne(d => d.FkPersonal)
                    .WithMany(p => p.Principals)
                    .HasForeignKey(d => d.FkPersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK Personal In Principal");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");

                entity.Property(e => e.FkClassId).HasColumnName("FkClass_Id");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkClassId)
                    .HasConstraintName("FK Class in Student");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_Id");

                entity.Property(e => e.FkClassId).HasColumnName("FkClass_Id");

                entity.Property(e => e.FkPersonalId).HasColumnName("FkPersonal_Id");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.FkClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK Class in Teacher");

                entity.HasOne(d => d.FkPersonal)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.FkPersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK Personal In Teacher");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
