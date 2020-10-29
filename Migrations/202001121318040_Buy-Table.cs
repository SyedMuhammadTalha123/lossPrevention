namespace Loss_Prevention.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BuyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.String(nullable: false),
                        Purchased = c.Int(),
                        Amount = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            
        }
        
        public override void Down()
        {
            
            
            DropTable("dbo.Buys");
        }
    }
}
