namespace CeramicsStoreShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prices", "ProductID", "dbo.Products");
            DropIndex("dbo.Prices", new[] { "ProductID" });
            AddColumn("dbo.Products", "PriceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "PriceID");
            AddForeignKey("dbo.Products", "PriceID", "dbo.Prices", "PriceID", cascadeDelete: true);
            DropColumn("dbo.Prices", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prices", "ProductID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "PriceID", "dbo.Prices");
            DropIndex("dbo.Products", new[] { "PriceID" });
            DropColumn("dbo.Products", "PriceID");
            CreateIndex("dbo.Prices", "ProductID");
            AddForeignKey("dbo.Prices", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
        }
    }
}
