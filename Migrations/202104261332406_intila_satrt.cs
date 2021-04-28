namespace Qlity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intila_satrt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "GiggerIDs", c => c.String());
            DropColumn("dbo.Gigs", "GiggerID");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Gigs", "GiggerID", c => c.String());
            //DropColumn("dbo.Gigs", "GiggerIDs");
        }
    }
}
