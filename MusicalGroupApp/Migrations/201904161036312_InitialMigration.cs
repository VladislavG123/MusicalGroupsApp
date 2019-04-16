namespace MusicalGroupApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MusicalGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Content = c.String(),
                        Mark = c.Int(nullable: false),
                        Lenght = c.Int(nullable: false),
                        MusicalGroup_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MusicalGroups", t => t.MusicalGroup_Id)
                .Index(t => t.MusicalGroup_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "MusicalGroup_Id", "dbo.MusicalGroups");
            DropIndex("dbo.Songs", new[] { "MusicalGroup_Id" });
            DropTable("dbo.Songs");
            DropTable("dbo.MusicalGroups");
        }
    }
}
