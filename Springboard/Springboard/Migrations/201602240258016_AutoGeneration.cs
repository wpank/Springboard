namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoGeneration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Application", "JobPosting_Id", "dbo.JobPosting");
            DropForeignKey("dbo.JobPosting", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount");
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements");
            DropPrimaryKey("dbo.Application");
            DropPrimaryKey("dbo.JobPosting");
            DropPrimaryKey("dbo.Culture");
            DropPrimaryKey("dbo.SeekerAccount");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.SkillRequirements");
            AlterColumn("dbo.Application", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.JobPosting", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Culture", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.SeekerAccount", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Skills", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.SkillRequirements", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Application", "Id");
            AddPrimaryKey("dbo.JobPosting", "Id");
            AddPrimaryKey("dbo.Culture", "Id");
            AddPrimaryKey("dbo.SeekerAccount", "Id");
            AddPrimaryKey("dbo.Skills", "Id");
            AddPrimaryKey("dbo.SkillRequirements", "Id");
            AddForeignKey("dbo.Application", "JobPosting_Id", "dbo.JobPosting", "Id");
            AddForeignKey("dbo.JobPosting", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount", "Id");
            AddForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills", "Id");
            AddForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements");
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount");
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.JobPosting", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.Application", "JobPosting_Id", "dbo.JobPosting");
            DropPrimaryKey("dbo.SkillRequirements");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.SeekerAccount");
            DropPrimaryKey("dbo.Culture");
            DropPrimaryKey("dbo.JobPosting");
            DropPrimaryKey("dbo.Application");
            AlterColumn("dbo.SkillRequirements", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Skills", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.SeekerAccount", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Culture", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.JobPosting", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Application", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.SkillRequirements", "Id");
            AddPrimaryKey("dbo.Skills", "Id");
            AddPrimaryKey("dbo.SeekerAccount", "Id");
            AddPrimaryKey("dbo.Culture", "Id");
            AddPrimaryKey("dbo.JobPosting", "Id");
            AddPrimaryKey("dbo.Application", "Id");
            AddForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements", "Id");
            AddForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills", "Id");
            AddForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount", "Id");
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.JobPosting", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.Application", "JobPosting_Id", "dbo.JobPosting", "Id");
        }
    }
}
