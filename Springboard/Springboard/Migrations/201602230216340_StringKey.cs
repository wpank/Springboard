namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Application", "JobPostingId", "dbo.JobPosting");
            DropForeignKey("dbo.JobPosting", "CultureId", "dbo.Culture");
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements");
            DropIndex("dbo.Application", new[] { "JobPostingId" });
            DropIndex("dbo.JobPosting", new[] { "CultureId" });
            DropIndex("dbo.JobPosting", new[] { "SkillRequirement_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Culture_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Skill_Id" });
            RenameColumn(table: "dbo.Application", name: "JobPostingId", newName: "JobPosting_Id");
            RenameColumn(table: "dbo.JobPosting", name: "CultureId", newName: "Culture_Id");
            DropPrimaryKey("dbo.Application");
            DropPrimaryKey("dbo.JobPosting");
            DropPrimaryKey("dbo.Culture");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.SkillRequirements");
            AlterColumn("dbo.Application", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Application", "JobPosting_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.JobPosting", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.JobPosting", "Culture_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.JobPosting", "SkillRequirement_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Culture", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.SeekerAccount", "Skill_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Skills", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SkillRequirements", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Application", "Id");
            AddPrimaryKey("dbo.JobPosting", "Id");
            AddPrimaryKey("dbo.Culture", "Id");
            AddPrimaryKey("dbo.Skills", "Id");
            AddPrimaryKey("dbo.SkillRequirements", "Id");
            CreateIndex("dbo.Application", "JobPosting_Id");
            CreateIndex("dbo.JobPosting", "Culture_Id");
            CreateIndex("dbo.JobPosting", "SkillRequirement_Id");
            CreateIndex("dbo.SeekerAccount", "Culture_Id");
            CreateIndex("dbo.SeekerAccount", "Skill_Id");
            AddForeignKey("dbo.Application", "JobPosting_Id", "dbo.JobPosting", "Id");
            AddForeignKey("dbo.JobPosting", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills", "Id");
            AddForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements", "Id");
            DropColumn("dbo.Application", "SeekerId");
            DropColumn("dbo.JobPosting", "PosterId");
            DropColumn("dbo.JobPosting", "SkillRequirementsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobPosting", "SkillRequirementsId", c => c.Int(nullable: false));
            AddColumn("dbo.JobPosting", "PosterId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Application", "SeekerId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements");
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.JobPosting", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.Application", "JobPosting_Id", "dbo.JobPosting");
            DropIndex("dbo.SeekerAccount", new[] { "Skill_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Culture_Id" });
            DropIndex("dbo.JobPosting", new[] { "SkillRequirement_Id" });
            DropIndex("dbo.JobPosting", new[] { "Culture_Id" });
            DropIndex("dbo.Application", new[] { "JobPosting_Id" });
            DropPrimaryKey("dbo.SkillRequirements");
            DropPrimaryKey("dbo.Skills");
            DropPrimaryKey("dbo.Culture");
            DropPrimaryKey("dbo.JobPosting");
            DropPrimaryKey("dbo.Application");
            AlterColumn("dbo.SkillRequirements", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Skills", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SeekerAccount", "Skill_Id", c => c.Int());
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.Int());
            AlterColumn("dbo.Culture", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.JobPosting", "SkillRequirement_Id", c => c.Int());
            AlterColumn("dbo.JobPosting", "Culture_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.JobPosting", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Application", "JobPosting_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Application", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SkillRequirements", "Id");
            AddPrimaryKey("dbo.Skills", "Id");
            AddPrimaryKey("dbo.Culture", "Id");
            AddPrimaryKey("dbo.JobPosting", "Id");
            AddPrimaryKey("dbo.Application", "Id");
            RenameColumn(table: "dbo.JobPosting", name: "Culture_Id", newName: "CultureId");
            RenameColumn(table: "dbo.Application", name: "JobPosting_Id", newName: "JobPostingId");
            CreateIndex("dbo.SeekerAccount", "Skill_Id");
            CreateIndex("dbo.SeekerAccount", "Culture_Id");
            CreateIndex("dbo.JobPosting", "SkillRequirement_Id");
            CreateIndex("dbo.JobPosting", "CultureId");
            CreateIndex("dbo.Application", "JobPostingId");
            AddForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements", "Id");
            AddForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills", "Id");
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.JobPosting", "CultureId", "dbo.Culture", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Application", "JobPostingId", "dbo.JobPosting", "Id", cascadeDelete: true);
        }
    }
}
