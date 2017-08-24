namespace CeramicsStoreShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brands", "ProductViewModel_ProductViewModelID", "dbo.ProductViewModels");
            DropForeignKey("dbo.Countries", "ProductViewModel_ProductViewModelID", "dbo.ProductViewModels");
            DropIndex("dbo.Brands", new[] { "ProductViewModel_ProductViewModelID" });
            DropIndex("dbo.Countries", new[] { "ProductViewModel_ProductViewModelID" });
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Color = c.String(),
                        Size = c.String(),
                        Description = c.String(),
                        BrandID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            AddColumn("dbo.Brands", "Product_ProductID", c => c.Int());
            AddColumn("dbo.Countries", "Product_ProductID", c => c.Int());
            CreateIndex("dbo.Brands", "Product_ProductID");
            CreateIndex("dbo.Countries", "Product_ProductID");
            AddForeignKey("dbo.Brands", "Product_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.Countries", "Product_ProductID", "dbo.Products", "ProductID");
            DropColumn("dbo.Brands", "ProductViewModel_ProductViewModelID");
            DropColumn("dbo.Countries", "ProductViewModel_ProductViewModelID");
            DropTable("dbo.ProductViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductViewModels",
                c => new
                    {
                        ProductViewModelID = c.Int(nullable: false, identity: true),
                        PurchesPrice = c.Double(nullable: false),
                        MinSellingPrice = c.Double(nullable: false),
                        MaxSellingPrice = c.Double(nullable: false),
                        Quentity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Color = c.String(),
                        Size = c.String(),
                        Description = c.String(),
                        BrandID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductViewModelID);
            
            AddColumn("dbo.Countries", "ProductViewModel_ProductViewModelID", c => c.Int());
            AddColumn("dbo.Brands", "ProductViewModel_ProductViewModelID", c => c.Int());
            DropForeignKey("dbo.Countries", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Brands", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Countries", new[] { "Product_ProductID" });
            DropIndex("dbo.Brands", new[] { "Product_ProductID" });
            DropColumn("dbo.Countries", "Product_ProductID");
            DropColumn("dbo.Brands", "Product_ProductID");
            DropTable("dbo.Products");
            CreateIndex("dbo.Countries", "ProductViewModel_ProductViewModelID");
            CreateIndex("dbo.Brands", "ProductViewModel_ProductViewModelID");
            AddForeignKey("dbo.Countries", "ProductViewModel_ProductViewModelID", "dbo.ProductViewModels", "ProductViewModelID");
            AddForeignKey("dbo.Brands", "ProductViewModel_ProductViewModelID", "dbo.ProductViewModels", "ProductViewModelID");
        }
    }
}
