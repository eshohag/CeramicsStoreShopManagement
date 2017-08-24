namespace CeramicsStoreShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductViewModels",
                c => new
                    {
                        ProductViewModelID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(nullable: false),
                        Color = c.String(),
                        Size = c.String(),
                        Description = c.String(),
                        BrandID = c.Int(nullable: false),
                        BrandName = c.String(),
                        CountryID = c.Int(nullable: false),
                        CountryName = c.String(),
                        PurchaesPrice = c.Double(nullable: false),
                        MinSellingPrice = c.Double(nullable: false),
                        MaxSellingPrice = c.Double(nullable: false),
                        Quentity = c.Int(nullable: false),
                        TotalCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductViewModelID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductViewModels");
        }
    }
}
