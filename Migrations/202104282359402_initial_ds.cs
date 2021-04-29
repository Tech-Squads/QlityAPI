namespace Qlity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_ds : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Users", "cellnumber");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Users", "cellnumber", c => c.String());
        }
    }
}
