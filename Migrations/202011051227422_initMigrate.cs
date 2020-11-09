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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
