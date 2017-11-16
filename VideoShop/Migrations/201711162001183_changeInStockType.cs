namespace VideoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInStockType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.s", "InStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.s", "InStock", c => c.Int(nullable: false));
        }
    }
}
