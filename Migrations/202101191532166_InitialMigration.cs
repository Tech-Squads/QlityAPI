namespace Qlity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        GigID = c.Int(nullable: false, identity: true),
                        GigTitle = c.String(),
                        DueDate = c.String(),
                        GigDescription = c.String(),
                        RequiredSkills = c.String(),
                        ContactDetails = c.String(),
                        RequestorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GigID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        userID = c.Int(nullable: false),
                        uName = c.String(),
                        uSurname = c.String(),
                        uCountry = c.String(),
                        uCompany = c.String(),
                        uEducation = c.String(),
                        uSkills = c.String(),
                        uReferences = c.String(),
                        uPastProjectName = c.String(),
                        uPastProjectDuration = c.String(),
                        uPastProjectDetails = c.String(),
                    })
                .PrimaryKey(t => t.ProfileID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        uEmail = c.String(),
                        uPassword = c.String(),
                        uType = c.Int(nullable: false),
                        FirstLogin = c.String(),
                        HasGig = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Profiles");
            DropTable("dbo.Gigs");
        }
    }
}
