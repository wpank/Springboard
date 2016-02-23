namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SeekerId = c.String(nullable: false, maxLength: 128),
                        JobPostingId = c.Int(nullable: false),
                        DateOpen = c.DateTime(nullable: false, storeType: "date"),
                        Resolved = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobPosting", t => t.JobPostingId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.JobPostingId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.JobPosting",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        JobTitle = c.String(nullable: false, maxLength: 50),
                        JobDescription = c.String(nullable: false, unicode: false, storeType: "text"),
                        PosterId = c.String(nullable: false, maxLength: 128),
                        CultureId = c.Int(nullable: false),
                        SkillRequirementsId = c.Int(nullable: false),
                        SkillRequirement_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Culture", t => t.CultureId, cascadeDelete: true)
                .ForeignKey("dbo.SkillRequirements", t => t.SkillRequirement_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CultureId)
                .Index(t => t.SkillRequirement_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Culture",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Accurate = c.Int(nullable: false),
                        Analytical = c.Int(nullable: false),
                        Creative = c.Int(nullable: false),
                        Efficient = c.Int(nullable: false),
                        FlexibleScheduling = c.Int(nullable: false),
                        GoodListener = c.Int(nullable: false),
                        LikeFastPace = c.Int(nullable: false),
                        Logical = c.Int(nullable: false),
                        MultiTasker = c.Int(nullable: false),
                        OralCommunicator = c.Int(nullable: false),
                        PeopleSkills = c.Int(nullable: false),
                        Planner = c.Int(nullable: false),
                        Punctual = c.Int(nullable: false),
                        RealtionshipBuilder = c.Int(nullable: false),
                        Researcher = c.Int(nullable: false),
                        Stamina = c.Int(nullable: false),
                        TeacherMentor = c.Int(nullable: false),
                        TeamLeader = c.Int(nullable: false),
                        TeamMentor = c.Int(nullable: false),
                        UXUI = c.Int(nullable: false),
                        WrittenCommunicator = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SeekerAccount",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AccountId = c.String(nullable: false, maxLength: 128),
                        CultureId = c.Int(nullable: false),
                        SkillsId = c.Int(nullable: false),
                        Skill_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Culture", t => t.CultureId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Skill_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CultureId)
                .Index(t => t.Skill_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AI_Rank = c.Int(nullable: false),
                        AI_Conf = c.Int(nullable: false),
                        Algo_Rank = c.Int(nullable: false),
                        Algo_Conf = c.Int(nullable: false),
                        BusAnalysis_Rank = c.Int(nullable: false),
                        BusAnalysis_Conf = c.Int(nullable: false),
                        Database_Rank = c.Int(nullable: false),
                        Database_Conf = c.Int(nullable: false),
                        Debug_Rank = c.Int(nullable: false),
                        Debug_Conf = c.Int(nullable: false),
                        GameProgramming_Rank = c.Int(nullable: false),
                        GameProgramming_Conf = c.Int(nullable: false),
                        MobileDev_Rank = c.Int(nullable: false),
                        MobileDev_Conf = c.Int(nullable: false),
                        OS_Rank = c.Int(nullable: false),
                        OS_Conf = c.Int(nullable: false),
                        Cpp_Rank = c.Int(nullable: false),
                        Cpp_Conf = c.Int(nullable: false),
                        Java_Rank = c.Int(nullable: false),
                        Java_Conf = c.Int(nullable: false),
                        Python_Rank = c.Int(nullable: false),
                        Python_Conf = c.Int(nullable: false),
                        Script_Rank = c.Int(nullable: false),
                        Script_Conf = c.Int(nullable: false),
                        ProjectMan_Rank = c.Int(nullable: false),
                        ProjectMan_Conf = c.Int(nullable: false),
                        SysArch_Rank = c.Int(nullable: false),
                        SysArch_Conf = c.Int(nullable: false),
                        SysDes_Rank = c.Int(nullable: false),
                        SysDes_Conf = c.Int(nullable: false),
                        SysInt_Rank = c.Int(nullable: false),
                        SysInt_Conf = c.Int(nullable: false),
                        TechWriting_Rank = c.Int(nullable: false),
                        TechWriting_Conf = c.Int(nullable: false),
                        UI_Rank = c.Int(nullable: false),
                        UI_Conf = c.Int(nullable: false),
                        WebDev_Rank = c.Int(nullable: false),
                        WebDev_Conf = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Role = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        SeekerAccount_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SeekerAccount", t => t.SeekerAccount_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.SeekerAccount_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SkillRequirements",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AI = c.Int(),
                        Algorithms = c.Int(),
                        BusAnalysis = c.Int(),
                        Database = c.Int(),
                        Debugging = c.Int(),
                        GameProgramming = c.Int(),
                        MobileDev = c.Int(),
                        OS = c.Int(),
                        Cpp = c.Int(),
                        Java = c.Int(),
                        Python = c.Int(),
                        Script = c.Int(),
                        ProjectMan = c.Int(),
                        SysArch = c.Int(),
                        SysDes = c.Int(),
                        SysInt = c.Int(),
                        TechWritting = c.Int(),
                        UI = c.Int(),
                        WebDev = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Application", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobPosting", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobPosting", "SkillRequirement_Id", "dbo.SkillRequirements");
            DropForeignKey("dbo.AspNetUsers", "SeekerAccount_Id", "dbo.SeekerAccount");
            DropForeignKey("dbo.SeekerAccount", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SeekerAccount", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.SeekerAccount", "CultureId", "dbo.Culture");
            DropForeignKey("dbo.JobPosting", "CultureId", "dbo.Culture");
            DropForeignKey("dbo.Application", "JobPostingId", "dbo.JobPosting");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "SeekerAccount_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SeekerAccount", new[] { "User_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "Skill_Id" });
            DropIndex("dbo.SeekerAccount", new[] { "CultureId" });
            DropIndex("dbo.JobPosting", new[] { "User_Id" });
            DropIndex("dbo.JobPosting", new[] { "SkillRequirement_Id" });
            DropIndex("dbo.JobPosting", new[] { "CultureId" });
            DropIndex("dbo.Application", new[] { "User_Id" });
            DropIndex("dbo.Application", new[] { "JobPostingId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SkillRequirements");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Skills");
            DropTable("dbo.SeekerAccount");
            DropTable("dbo.Culture");
            DropTable("dbo.JobPosting");
            DropTable("dbo.Application");
        }
    }
}
