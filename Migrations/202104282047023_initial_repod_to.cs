namespace Qlity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_repod_to : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "Name", c => c.String());
            AddColumn("dbo.Gigs", "Surname", c => c.String());
            AddColumn("dbo.Gigs", "Email", c => c.String());
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Gigs", "Email");
            //DropColumn("dbo.Gigs", "Surname");
            //DropColumn("dbo.Gigs", "Name");
        }
    }
}
