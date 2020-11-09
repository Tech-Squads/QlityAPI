namespace Qlity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SndMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        uName = c.String(),
                        uSurname = c.String(),
                        uCountry = c.String(),
                        uCompany = c.String(),
                        uEducation = c.String(),
                        uSkills = c.String(),
                        uReferences = c.String(),
                        PastProjectName = c.String(),
                        PastProjectDuration = c.String(),
                        PastProjectDetails = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profiles");
        }
    }
}
