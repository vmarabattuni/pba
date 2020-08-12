namespace PhoneBook.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.City",
            //    c => new
            //        {
            //            CityId = c.Int(nullable: false, identity: true),
            //            CityName = c.String(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //            StateId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CityId)
            //    .ForeignKey("dbo.State", t => t.StateId)
            //    .Index(t => t.StateId);
            
            //CreateTable(
            //    "dbo.State",
            //    c => new
            //        {
            //            SateId = c.Int(nullable: false, identity: true),
            //            StateName = c.String(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //            CountryId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.SateId)
            //    .ForeignKey("dbo.Country", t => t.CountryId)
            //    .Index(t => t.CountryId);
            
            //CreateTable(
            //    "dbo.Country",
            //    c => new
            //        {
            //            CuntryId = c.Int(nullable: false, identity: true),
            //            CountryName = c.String(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CuntryId);
            
            //CreateTable(
            //    "dbo.People",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            FirstName = c.String(nullable: false, maxLength: 50),
            //            LastName = c.String(nullable: false, maxLength: 50),
            //            PhoneNumber = c.String(nullable: false, maxLength: 13),
            //            Email = c.String(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.Address",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false),
            //            AddressOne = c.String(nullable: false),
            //            AddressTwo = c.String(),
            //            PinCode = c.Int(nullable: false),
            //            CountryId = c.Int(nullable: false),
            //            StateId = c.Int(nullable: false),
            //            CityId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Country", t => t.CountryId)
            //    .ForeignKey("dbo.State", t => t.StateId)
            //    .ForeignKey("dbo.City", t => t.CityId)
            //    .ForeignKey("dbo.People", t => t.ID)
            //    .Index(t => t.ID)
            //    .Index(t => t.CountryId)
            //    .Index(t => t.StateId)
            //    .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "ID", "dbo.People");
            DropForeignKey("dbo.Address", "CityId", "dbo.City");
            DropForeignKey("dbo.Address", "StateId", "dbo.State");
            DropForeignKey("dbo.Address", "CountryId", "dbo.Country");
            DropForeignKey("dbo.City", "StateId", "dbo.State");
            DropForeignKey("dbo.State", "CountryId", "dbo.Country");
            DropIndex("dbo.Address", new[] { "CityId" });
            DropIndex("dbo.Address", new[] { "StateId" });
            DropIndex("dbo.Address", new[] { "CountryId" });
            DropIndex("dbo.Address", new[] { "ID" });
            DropIndex("dbo.State", new[] { "CountryId" });
            DropIndex("dbo.City", new[] { "StateId" });
            DropTable("dbo.Address");
            DropTable("dbo.People");
            DropTable("dbo.Country");
            DropTable("dbo.State");
            DropTable("dbo.City");
        }
    }
}
