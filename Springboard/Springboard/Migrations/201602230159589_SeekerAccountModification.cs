namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeekerAccountModification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SeekerAccount", "CultureId", "dbo.Culture");
            DropIndex("dbo.SeekerAccount", new[] { "CultureId" });
            RenameColumn(table: "dbo.SeekerAccount", name: "CultureId", newName: "Culture_Id");
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.Int());
            CreateIndex("dbo.SeekerAccount", "Culture_Id");
            AddForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture", "Id");
            DropColumn("dbo.SeekerAccount", "SkillsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SeekerAccount", "SkillsId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SeekerAccount", "Culture_Id", "dbo.Culture");
            DropIndex("dbo.SeekerAccount", new[] { "Culture_Id" });
            AlterColumn("dbo.SeekerAccount", "Culture_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SeekerAccount", name: "Culture_Id", newName: "CultureId");
            CreateIndex("dbo.SeekerAccount", "CultureId");
            AddForeignKey("dbo.SeekerAccount", "CultureId", "dbo.Culture", "Id", cascadeDelete: true);
        }
    }
}
