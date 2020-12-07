namespace Qlity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        uEmail = c.String(),
                        uPassword = c.String(),
                        uType = c.Int(),
                        FirstLogin = c.String(),
                    })
                .PrimaryKey(t => t.UserID);

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
            DropTable("dbo.Users");
            DropTable("dbo.Profiles");
        }
    }
}
