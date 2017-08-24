namespace CeramicsStoreShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceID = c.Int(nullable: false, identity: true),
                        PurchaesPrice = c.Double(nullable: false),
                        MinSellingPrice = c.Double(nullable: false),
                        MaxSellingPrice = c.Double(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PriceID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "ProductID", "dbo.Products");
            DropIndex("dbo.Prices", new[] { "ProductID" });
            DropTable("dbo.Prices");
        }
    }
}
