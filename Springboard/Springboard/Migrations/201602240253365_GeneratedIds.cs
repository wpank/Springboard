namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneratedIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Application", "JobPosting_Id", "dbo.JobPosting");
            DropForeignKey("dbo.JobPosting", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount");
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements");
            DropIndex("dbo.Application", new[] { "JobPosting_Id" });
            DropIndex("dbo.JobPosting", new[] { "Culture_Id" });
            DropIndex("dbo.JobPosting", new[] { "SkillRequirement_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Culture_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Skill_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "SeekerAccount_Id" });
            DropPrimaryKey("dbo.Application");
            DropPrimaryKey("dbo.JobPosting");
            DropPrimaryKey("dbo.Culture");
            DropPrimaryKey("dbo.SeekerAccount");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.SkillRequirements");
            AlterColumn("dbo.Application", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Application", "JobPosting_Id", c => c.Guid());
            AlterColumn("dbo.JobPosting", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.JobPosting", "Culture_Id", c => c.Guid());
            AlterColumn("dbo.JobPosting", "SkillRequirement_Id", c => c.Guid());
            AlterColumn("dbo.Culture", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.SeekerAccount", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.Guid());
            AlterColumn("dbo.SeekerAccount", "Skill_Id", c => c.Guid());
            AlterColumn("dbo.Skills", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.AspNetUsers", "SeekerAccount_Id", c => c.Guid());
            AlterColumn("dbo.SkillRequirements", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Application", "Id");
            AddPrimaryKey("dbo.JobPosting", "Id");
            AddPrimaryKey("dbo.Culture", "Id");
            AddPrimaryKey("dbo.SeekerAccount", "Id");
            AddPrimaryKey("dbo.Skills", "Id");
            AddPrimaryKey("dbo.SkillRequirements", "Id");
            CreateIndex("dbo.Application", "JobPosting_Id");
            CreateIndex("dbo.JobPosting", "Culture_Id");
            CreateIndex("dbo.JobPosting", "SkillRequirement_Id");
            CreateIndex("dbo.SeekerAccount", "Culture_Id");
            CreateIndex("dbo.SeekerAccount", "Skill_Id");
            CreateIndex("dbo.AspNetUsers", "SeekerAccount_Id");
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
            DropIndex("dbo.AspNetUsers", new[] { "SeekerAccount_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Skill_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Culture_Id" });
            DropIndex("dbo.JobPosting", new[] { "SkillRequirement_Id" });
            DropIndex("dbo.JobPosting", new[] { "Culture_Id" });
            DropIndex("dbo.Application", new[] { "JobPosting_Id" });
            DropPrimaryKey("dbo.SkillRequirements");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.SeekerAccount");
            DropPrimaryKey("dbo.Culture");
            DropPrimaryKey("dbo.JobPosting");
            DropPrimaryKey("dbo.Application");
            AlterColumn("dbo.SkillRequirements", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "SeekerAccount_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Skills", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SeekerAccount", "Skill_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.SeekerAccount", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Culture", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.JobPosting", "SkillRequirement_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.JobPosting", "Culture_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.JobPosting", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Application", "JobPosting_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Application", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.SkillRequirements", "Id");
            AddPrimaryKey("dbo.Skills", "Id");
            AddPrimaryKey("dbo.SeekerAccount", "Id");
            AddPrimaryKey("dbo.Culture", "Id");
            AddPrimaryKey("dbo.JobPosting", "Id");
            AddPrimaryKey("dbo.Application", "Id");
            CreateIndex("dbo.AspNetUsers", "SeekerAccount_Id");
            CreateIndex("dbo.SeekerAccount", "Skill_Id");
            CreateIndex("dbo.SeekerAccount", "Culture_Id");
            CreateIndex("dbo.JobPosting", "SkillRequirement_Id");
            CreateIndex("dbo.JobPosting", "Culture_Id");
            CreateIndex("dbo.Application", "JobPosting_Id");
            AddForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements", "Id");
            AddForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills", "Id");
            AddForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount", "Id");
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.JobPosting", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.Application", "JobPosting_Id", "dbo.JobPosting", "Id");
        }
    }
}
