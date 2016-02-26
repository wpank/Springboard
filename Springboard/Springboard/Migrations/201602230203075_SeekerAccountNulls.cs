namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeekerAccountNulls : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropIndex("dbo.SeekerAccount", new[] { "Culture_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Skill_Id" });
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.Int());
            AlterColumn("dbo.SeekerAccount", "Skill_Id", c => c.Int());
            CreateIndex("dbo.SeekerAccount", "Culture_Id");
            CreateIndex("dbo.SeekerAccount", "Skill_Id");
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id");
            AddForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropIndex("dbo.SeekerAccount", new[] { "Skill_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Culture_Id" });
            AlterColumn("dbo.SeekerAccount", "Skill_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.SeekerAccount", "Skill_Id");
            CreateIndex("dbo.SeekerAccount", "Culture_Id");
            AddForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id", cascadeDelete: true);
        }
    }
}
