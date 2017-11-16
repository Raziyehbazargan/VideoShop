namespace VideoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMovieModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.s", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.s", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.s", "InStock", c => c.Int(nullable: false));
            AddColumn("dbo.s", "GenreTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.s", "GenreTypeId");
            AddForeignKey("dbo.s", "GenreTypeId", "dbo.GenreTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.s", "GenreTypeId", "dbo.GenreTypes");
            DropIndex("dbo.s", new[] { "GenreTypeId" });
            DropColumn("dbo.s", "GenreTypeId");
            DropColumn("dbo.s", "InStock");
            DropColumn("dbo.s", "Created");
            DropColumn("dbo.s", "ReleaseDate");
            DropTable("dbo.GenreTypes");
        }
    }
}
