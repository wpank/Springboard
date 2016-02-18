namespace Springboard.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseModel : DbContext
    {
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<JobPosting> JobPostings { get; set; }
        public virtual DbSet<SeekerAccount> SeekerAccounts { get; set; }
        public virtual DbSet<SkillRequirement> SkillRequirements { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.Role)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.SeekerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.JobPostings)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.PosterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.SeekerAccounts)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.AccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Culture>()
                .HasMany(e => e.JobPostings)
                .WithRequired(e => e.Culture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Culture>()
                .HasMany(e => e.SeekerAccounts)
                .WithRequired(e => e.Culture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobPosting>()
                .Property(e => e.JobDescription)
                .IsUnicode(false);

            modelBuilder.Entity<JobPosting>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.JobPosting)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SeekerAccount>()
                .HasMany(e => e.AspNetUsers)
                .WithOptional(e => e.SeekerAccount)
                .HasForeignKey(e => e.SeekerId);

            modelBuilder.Entity<SkillRequirement>()
                .HasMany(e => e.JobPostings)
                .WithRequired(e => e.SkillRequirement)
                .HasForeignKey(e => e.SkillRequirementsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.SeekerAccounts)
                .WithRequired(e => e.Skill)
                .HasForeignKey(e => e.SkillsId)
                .WillCascadeOnDelete(false);
        }
    }
}
