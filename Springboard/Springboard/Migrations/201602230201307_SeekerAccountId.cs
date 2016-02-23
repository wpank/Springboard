namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeekerAccountId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount");
            DropIndex("dbo.SeekerAccount", new[] { "Culture_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Skill_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "SeekerAccount_Id" });
            DropPrimaryKey("dbo.SeekerAccount");
            AlterColumn("dbo.SeekerAccount", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SeekerAccount", "Skill_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "SeekerAccount_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.SeekerAccount", "Id");
            CreateIndex("dbo.SeekerAccount", "Culture_Id");
            CreateIndex("dbo.SeekerAccount", "Skill_Id");
            CreateIndex("dbo.AspNetUsers", "SeekerAccount_Id");
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount");
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropIndex("dbo.AspNetUsers", new[] { "SeekerAccount_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Skill_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Culture_Id" });
            DropPrimaryKey("dbo.SeekerAccount");
            AlterColumn("dbo.AspNetUsers", "SeekerAccount_Id", c => c.Int());
            AlterColumn("dbo.SeekerAccount", "Skill_Id", c => c.Int());
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.Int());
            AlterColumn("dbo.SeekerAccount", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SeekerAccount", "Id");
            CreateIndex("dbo.AspNetUsers", "SeekerAccount_Id");
            CreateIndex("dbo.SeekerAccount", "Skill_Id");
            CreateIndex("dbo.SeekerAccount", "Culture_Id");
            AddForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount", "Id");
            AddForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills", "Id");
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id");
        }
    }
}
