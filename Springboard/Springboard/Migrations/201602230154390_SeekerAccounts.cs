namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeekerAccounts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SeekerAccount", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SeekerAccount", new[] { "User_Id" });
            DropColumn("dbo.SeekerAccount", "AccountId");
            DropColumn("dbo.SeekerAccount", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SeekerAccount", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.SeekerAccount", "AccountId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.SeekerAccount", "User_Id");
            AddForeignKey("dbo.SeekerAccount", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
