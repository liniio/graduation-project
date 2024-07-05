namespace Managing_Teacher_Work.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MTWDbContext : DbContext
    {
        public MTWDbContext()
            : base("name=MTWDbContext")
        {
        }

        public virtual DbSet<CalendarWorking> CalendarWorking { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Credentials> Credentials { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<GroupUser> GroupUser { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<ReportMonth> ReportMonth { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Science> Science { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TypeCalendar> TypeCalendar { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Work> Work { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasMany(e => e.Student)
                .WithRequired(e => e.Class)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Credentials>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Credentials>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<GroupUser>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<GroupUser>()
                .Property(e => e.CodeRole)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Science>()
                .HasMany(e => e.Class)
                .WithRequired(e => e.Science)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Science>()
                .HasMany(e => e.Teacher)
                .WithRequired(e => e.Science)
                .HasForeignKey(e => e.SicenceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Class)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeCalendar>()
                .HasMany(e => e.CalendarWorking)
                .WithRequired(e => e.TypeCalendar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Work>()
                .HasMany(e => e.CalendarWorking)
                .WithRequired(e => e.Work)
                .WillCascadeOnDelete(false);
        }
    }
}
