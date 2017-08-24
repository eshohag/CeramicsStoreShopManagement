namespace CeramicsStoreShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        Quentity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "ProductID", "dbo.Products");
            DropIndex("dbo.Stores", new[] { "ProductID" });
            DropTable("dbo.Stores");
        }
    }
}
