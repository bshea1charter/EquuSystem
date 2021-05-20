using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EquuSystem.Repository.Models;

#nullable disable

namespace EquuSystem.Repository
{
    public partial class EquuSystemDB : DbContext
    {
        public EquuSystemDB()
        {
        }

        public EquuSystemDB(DbContextOptions<EquuSystemDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<FreeLesson> FreeLessons { get; set; }
        public virtual DbSet<Horse> Horses { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<LessonRate> LessonRates { get; set; }
        public virtual DbSet<LessonStatus> LessonStatuses { get; set; }
        public virtual DbSet<LessonType> LessonTypes { get; set; }
        public virtual DbSet<Rider> Riders { get; set; }
        public virtual DbSet<RiderLevel> RiderLevels { get; set; }
        public virtual DbSet<RiderWaitlist> RiderWaitlists { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<TrainingType> TrainingTypes { get; set; }
        public virtual DbSet<training> training { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-GPVU2DEV\\SQLEXPRESS;Initial Catalog=EquuSoft;User ID=EquuSoftAPI; password=shahbaskus");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Breed>(entity =>
            {
                entity.Property(e => e.breed_name).IsUnicode(false);
            });

            modelBuilder.Entity<Horse>(entity =>
            {
                entity.Property(e => e.horse_name).IsUnicode(false);
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(e => e.instructor_admin).HasDefaultValueSql("('0')");

                entity.Property(e => e.instructor_first_name).IsUnicode(false);

                entity.Property(e => e.instructor_last_name).IsUnicode(false);

                entity.Property(e => e.instructor_password).IsUnicode(false);

                entity.Property(e => e.instructor_phone).IsUnicode(false);

                entity.Property(e => e.instructor_user_id).IsUnicode(false);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.ImportCompleted).IsUnicode(false);

                entity.Property(e => e.ImportHorse).IsUnicode(false);

                entity.Property(e => e.ImportPrivateLesson).IsUnicode(false);

                entity.Property(e => e.ImportStudent).IsUnicode(false);

                entity.Property(e => e.LessonCompleted).HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<LessonRate>(entity =>
            {
                entity.Property(e => e.LessonRateText).IsUnicode(false);
            });

            modelBuilder.Entity<LessonStatus>(entity =>
            {
                entity.Property(e => e.LessonStatusCode).IsUnicode(false);

                entity.Property(e => e.LessonStatusText).IsUnicode(false);
            });

            modelBuilder.Entity<LessonType>(entity =>
            {
                entity.Property(e => e.LessonTypeText).IsUnicode(false);
            });

            modelBuilder.Entity<Rider>(entity =>
            {
                entity.Property(e => e.ImportActive).IsUnicode(false);

                entity.Property(e => e.ImportRiderLevel).IsUnicode(false);

                entity.Property(e => e.ImportRiderLookup).IsUnicode(false);

                entity.Property(e => e.ImportRiderNotes).IsUnicode(false);

                entity.Property(e => e.ImportState).IsUnicode(false);

                entity.Property(e => e.RiderActive).HasDefaultValueSql("('0')");

                entity.Property(e => e.RiderAddressLine1).IsUnicode(false);

                entity.Property(e => e.RiderAddressLine2).IsUnicode(false);

                entity.Property(e => e.RiderCity).IsUnicode(false);

                entity.Property(e => e.RiderFirstName).IsUnicode(false);

                entity.Property(e => e.RiderHomePhone).IsUnicode(false);

                entity.Property(e => e.RiderIsCore).HasDefaultValueSql("('0')");

                entity.Property(e => e.RiderIsTenPercent).HasDefaultValueSql("('0')");

                entity.Property(e => e.RiderLastName).IsUnicode(false);

                entity.Property(e => e.RiderNickname).IsUnicode(false);

                entity.Property(e => e.RiderPrimaryContact).IsUnicode(false);

                entity.Property(e => e.RiderPrimaryContactEmail).IsUnicode(false);

                entity.Property(e => e.RiderPrimaryContactPhone).IsUnicode(false);

                entity.Property(e => e.RiderPrimaryContactPhone2).IsUnicode(false);

                entity.Property(e => e.RiderSecondaryContact).IsUnicode(false);

                entity.Property(e => e.RiderSecondaryContactEmail).IsUnicode(false);

                entity.Property(e => e.RiderSecondaryContactPhone).IsUnicode(false);

                entity.Property(e => e.RiderSecondaryContactPhone2).IsUnicode(false);

                entity.Property(e => e.RiderState).HasDefaultValueSql("('1')");

                entity.Property(e => e.RiderZipcode).IsUnicode(false);
            });

            modelBuilder.Entity<RiderLevel>(entity =>
            {
                entity.Property(e => e.RiderLevelText).IsUnicode(false);
            });

            modelBuilder.Entity<RiderWaitlist>(entity =>
            {
                entity.Property(e => e.RiderWaitlistEmail).IsUnicode(false);

                entity.Property(e => e.RiderWaitlistFirstName).IsUnicode(false);

                entity.Property(e => e.RiderWaitlistLastName).IsUnicode(false);

                entity.Property(e => e.RiderWaitlistNotes).IsUnicode(false);

                entity.Property(e => e.RiderWaitlistPhone).IsUnicode(false);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.StateAbbr).IsUnicode(false);

                entity.Property(e => e.StateName).IsUnicode(false);
            });

            modelBuilder.Entity<TrainingType>(entity =>
            {
                entity.Property(e => e.TrainingTypeText).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
