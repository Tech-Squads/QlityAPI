namespace Qlity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_initial_gigs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "uGigIDs", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "uGigTitles", c => c.String());
            AddColumn("dbo.Users", "uDueDates", c => c.String());
            AddColumn("dbo.Users", "uGigDescriptions", c => c.String());
            AddColumn("dbo.Users", "uRequiredSkills", c => c.String());
            AddColumn("dbo.Users", "uContactDetails", c => c.String());
            AddColumn("dbo.Users", "uRequestorIDs", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "uImagePs", c => c.String());
            AddColumn("dbo.Users", "uStatusGigs", c => c.String());
           
          
        }
        
        public override void Down()
        {
          
            AddColumn("dbo.Users", "uStatusGig", c => c.String());
            AddColumn("dbo.Users", "uImageP", c => c.String());
            AddColumn("dbo.Users", "uRequestorID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "uContactDetail", c => c.String());
            AddColumn("dbo.Users", "uRequiredSkill", c => c.String());
            AddColumn("dbo.Users", "uGigDescription", c => c.String());
            AddColumn("dbo.Users", "uDueDate", c => c.String());
            AddColumn("dbo.Users", "uGigTitle", c => c.String());
            AddColumn("dbo.Users", "uGigID", c => c.Int(nullable: false));
       
        }
    }
}
