using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WorkoutProj.Models
{
    public partial class WorkForceManagementContext : DbContext
    {
        public WorkForceManagementContext()
        {
        }

        public WorkForceManagementContext(DbContextOptions<WorkForceManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Skillmap> Skillmaps { get; set; }
        public virtual DbSet<Softlock> Softlocks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SQL201901.softura.com;Database=WorkForceManagement;User Id=WorkForceSQLUser;password=W06kF0rce;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__employee__DDDF6446AA9F0151");

                entity.ToTable("employees");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Experience)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("experience");

                entity.Property(e => e.Lockstatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lockstatus");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("manager");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.WfmManager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("wfm_manager");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skills");

                entity.Property(e => e.Skillid)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("skillid");

                entity.Property(e => e.Skillname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("skillname");
            });

            modelBuilder.Entity<Skillmap>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__skillmap__DDDF64463F44E326");

                entity.ToTable("skillmap");

                entity.Property(e => e.Sno).HasColumnName("sno");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Skillid)
                    .HasColumnType("decimal(5, 0)")
                    .HasColumnName("skillid");
            });

            modelBuilder.Entity<Softlock>(entity =>
            {
                entity.HasKey(e => e.Lockid)
                    .HasName("PK__softlock__B2B463D82E2E1D2D");

                entity.ToTable("softlock");

                entity.Property(e => e.Lockid)
                    .ValueGeneratedNever()
                    .HasColumnName("lockid");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Lastupdated)
                    .HasColumnType("date")
                    .HasColumnName("lastupdated");

                entity.Property(e => e.Manager)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("manager");

                entity.Property(e => e.Managerstatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("managerstatus")
                    .HasDefaultValueSql("('awaiting_approval')");

                entity.Property(e => e.Mgrlastupdate)
                    .HasColumnType("date")
                    .HasColumnName("mgrlastupdate");

                entity.Property(e => e.Mgrstatuscomment)
                    .HasColumnType("text")
                    .HasColumnName("mgrstatuscomment");

                entity.Property(e => e.Reqdate)
                    .HasColumnType("date")
                    .HasColumnName("reqdate");

                entity.Property(e => e.Requestmessage)
                    .HasColumnType("text")
                    .HasColumnName("requestmessage");

                entity.Property(e => e.Sno)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("sno");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Wfmremark)
                    .HasColumnType("text")
                    .HasColumnName("wfmremark");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__users__F3DBC57305F78E9D");

                entity.ToTable("users");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasColumnType("text")
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
