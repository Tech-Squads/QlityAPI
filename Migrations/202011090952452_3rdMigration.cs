namespace Qlity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rdMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "uProfileID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "uProfileID", c => c.Int(nullable: false));
        }
    }
}
