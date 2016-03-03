namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyFix : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Application", name: "JobPosting_Id", newName: "JobPostingId");
            RenameColumn(table: "dbo.Application", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.JobPosting", name: "Culture_Id", newName: "CultureId");
            RenameColumn(table: "dbo.JobPosting", name: "SkillRequirement_Id", newName: "SkillRequirementId");
            RenameColumn(table: "dbo.JobPosting", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.SeekerAccount", name: "Culture_Id", newName: "CultureId");
            RenameColumn(table: "dbo.SeekerAccount", name: "Skill_Id", newName: "SkillId");
            RenameColumn(table: "dbo.AspNetUsers", name: "SeekerAccount_Id", newName: "SeekerAccountId");
            RenameIndex(table: "dbo.Application", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Application", name: "IX_JobPosting_Id", newName: "IX_JobPostingId");
            RenameIndex(table: "dbo.JobPosting", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.JobPosting", name: "IX_Culture_Id", newName: "IX_CultureId");
            RenameIndex(table: "dbo.JobPosting", name: "IX_SkillRequirement_Id", newName: "IX_SkillRequirementId");
            RenameIndex(table: "dbo.SeekerAccount", name: "IX_Culture_Id", newName: "IX_CultureId");
            RenameIndex(table: "dbo.SeekerAccount", name: "IX_Skill_Id", newName: "IX_SkillId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_SeekerAccount_Id", newName: "IX_SeekerAccountId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_SeekerAccountId", newName: "IX_SeekerAccount_Id");
            RenameIndex(table: "dbo.SeekerAccount", name: "IX_SkillId", newName: "IX_Skill_Id");
            RenameIndex(table: "dbo.SeekerAccount", name: "IX_CultureId", newName: "IX_Culture_Id");
            RenameIndex(table: "dbo.JobPosting", name: "IX_SkillRequirementId", newName: "IX_SkillRequirement_Id");
            RenameIndex(table: "dbo.JobPosting", name: "IX_CultureId", newName: "IX_Culture_Id");
            RenameIndex(table: "dbo.JobPosting", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Application", name: "IX_JobPostingId", newName: "IX_JobPosting_Id");
            RenameIndex(table: "dbo.Application", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "SeekerAccountId", newName: "SeekerAccount_Id");
            RenameColumn(table: "dbo.SeekerAccount", name: "SkillId", newName: "Skill_Id");
            RenameColumn(table: "dbo.SeekerAccount", name: "CultureId", newName: "Culture_Id");
            RenameColumn(table: "dbo.JobPosting", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.JobPosting", name: "SkillRequirementId", newName: "SkillRequirement_Id");
            RenameColumn(table: "dbo.JobPosting", name: "CultureId", newName: "Culture_Id");
            RenameColumn(table: "dbo.Application", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Application", name: "JobPostingId", newName: "JobPosting_Id");
        }
    }
}
