namespace SuperApp.Backoffice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApiKeys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.Guid(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApiKeys", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApiKeys", new[] { "User_Id" });
            DropTable("dbo.ApiKeys");
        }
    }
}
