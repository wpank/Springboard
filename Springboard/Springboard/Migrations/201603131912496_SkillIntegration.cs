namespace Springboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Data.Entity.Migrations.Model;
    public partial class SkillIntegration : DbMigration
    {
   
        public override void Up()
        {
            //MigrationExtensions.DeleteDefaultContraint(this, "dbo.SeekerAccout", "SkillId");
            //DropForeignKey("dbo.SeekerAccount", "SkillId", "dbo.Skills");
            DropIndex("dbo.SeekerAccount", new[] { "SkillId" });
            AddColumn("dbo.SeekerAccount", "SkillRequirementId", c => c.Guid());
            CreateIndex("dbo.SeekerAccount", "SkillRequirementId");
            AddForeignKey("dbo.SeekerAccount", "SkillRequirementId", "dbo.SkillRequirements", "Id");
            DropColumn("dbo.SeekerAccount", "SkillId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SeekerAccount", "SkillId", c => c.Guid());
            DropForeignKey("dbo.SeekerAccount", "SkillRequirementId", "dbo.SkillRequirements");
            DropIndex("dbo.SeekerAccount", new[] { "SkillRequirementId" });
            DropColumn("dbo.SeekerAccount", "SkillRequirementId");
            CreateIndex("dbo.SeekerAccount", "SkillId");
            AddForeignKey("dbo.SeekerAccount", "SkillId", "dbo.Skills", "Id");
        }
    }

    static internal class MigrationExtensions
    {
        public static void DeleteDefaultContraint(this IDbMigration migration, string tableName, string colName, bool suppressTransaction = false)
        {
            var sql = new SqlOperation(String.Format(@"DECLARE @SQL varchar(1000)
        SET @SQL='ALTER TABLE {0} DROP CONSTRAINT ['+(SELECT name
        FROM sys.default_constraints
        WHERE parent_object_id = object_id('{0}')
        AND col_name(parent_object_id, parent_column_id) = '{1}')+']';
        PRINT @SQL;
        EXEC(@SQL);", tableName, colName)) { SuppressTransaction = suppressTransaction };
            migration.AddOperation(sql);
        }
    }
}
