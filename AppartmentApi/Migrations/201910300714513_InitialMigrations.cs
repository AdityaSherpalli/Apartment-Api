namespace AppartmentApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlatMember",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlatId = c.Int(nullable: false),
                        PrimaryOwnerId = c.Int(),
                        SecondaryOwnerId = c.Int(),
                        SecondaryResidentId = c.Int(),
                        PrimaryResidentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flat", t => t.FlatId)
                .ForeignKey("dbo.People", t => t.PrimaryOwnerId)
                .ForeignKey("dbo.People", t => t.PrimaryResidentId)
                .ForeignKey("dbo.People", t => t.SecondaryOwnerId)
                .ForeignKey("dbo.People", t => t.SecondaryResidentId)
                .Index(t => t.FlatId)
                .Index(t => t.PrimaryOwnerId)
                .Index(t => t.SecondaryOwnerId)
                .Index(t => t.SecondaryResidentId)
                .Index(t => t.PrimaryResidentId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PersonType = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaintenenceItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsWater = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maintenence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Period = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApartmentMaintenenceItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Notes = c.String(),
                        Amount = c.Double(nullable: false),
                        Maintenence_Id = c.Int(nullable: false),
                        MaintenenceItem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maintenence", t => t.Maintenence_Id)
                .ForeignKey("dbo.MaintenenceItem", t => t.MaintenenceItem_Id)
                .Index(t => t.Maintenence_Id)
                .Index(t => t.MaintenenceItem_Id);
            
            CreateTable(
                "dbo.FlatMaintenence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        Flat_Id = c.Int(nullable: false),
                        Maintenence_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flat", t => t.Flat_Id)
                .ForeignKey("dbo.Maintenence", t => t.Maintenence_Id)
                .Index(t => t.Flat_Id)
                .Index(t => t.Maintenence_Id);
            
            CreateTable(
                "dbo.FlatMaintenenceItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        ApartmentMaintenenceItem_Id = c.Int(nullable: false),
                        FlatMaintenence_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApartmentMaintenenceItem", t => t.ApartmentMaintenenceItem_Id)
                .ForeignKey("dbo.FlatMaintenence", t => t.FlatMaintenence_Id)
                .Index(t => t.ApartmentMaintenenceItem_Id)
                .Index(t => t.FlatMaintenence_Id);
            
            CreateTable(
                "dbo.WaterMaintenence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OldReading = c.Long(nullable: false),
                        NewReading = c.Long(nullable: false),
                        Reading = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Flat_Id = c.Int(nullable: false),
                        Maintenence_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flat", t => t.Flat_Id)
                .ForeignKey("dbo.Maintenence", t => t.Maintenence_Id)
                .Index(t => t.Flat_Id)
                .Index(t => t.Maintenence_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WaterMaintenence", "Maintenence_Id", "dbo.Maintenence");
            DropForeignKey("dbo.WaterMaintenence", "Flat_Id", "dbo.Flat");
            DropForeignKey("dbo.FlatMaintenenceItem", "FlatMaintenence_Id", "dbo.FlatMaintenence");
            DropForeignKey("dbo.FlatMaintenenceItem", "ApartmentMaintenenceItem_Id", "dbo.ApartmentMaintenenceItem");
            DropForeignKey("dbo.FlatMaintenence", "Maintenence_Id", "dbo.Maintenence");
            DropForeignKey("dbo.FlatMaintenence", "Flat_Id", "dbo.Flat");
            DropForeignKey("dbo.ApartmentMaintenenceItem", "MaintenenceItem_Id", "dbo.MaintenenceItem");
            DropForeignKey("dbo.ApartmentMaintenenceItem", "Maintenence_Id", "dbo.Maintenence");
            DropForeignKey("dbo.FlatMember", "SecondaryResidentId", "dbo.People");
            DropForeignKey("dbo.FlatMember", "SecondaryOwnerId", "dbo.People");
            DropForeignKey("dbo.FlatMember", "PrimaryResidentId", "dbo.People");
            DropForeignKey("dbo.FlatMember", "PrimaryOwnerId", "dbo.People");
            DropForeignKey("dbo.FlatMember", "FlatId", "dbo.Flat");
            DropIndex("dbo.WaterMaintenence", new[] { "Maintenence_Id" });
            DropIndex("dbo.WaterMaintenence", new[] { "Flat_Id" });
            DropIndex("dbo.FlatMaintenenceItem", new[] { "FlatMaintenence_Id" });
            DropIndex("dbo.FlatMaintenenceItem", new[] { "ApartmentMaintenenceItem_Id" });
            DropIndex("dbo.FlatMaintenence", new[] { "Maintenence_Id" });
            DropIndex("dbo.FlatMaintenence", new[] { "Flat_Id" });
            DropIndex("dbo.ApartmentMaintenenceItem", new[] { "MaintenenceItem_Id" });
            DropIndex("dbo.ApartmentMaintenenceItem", new[] { "Maintenence_Id" });
            DropIndex("dbo.FlatMember", new[] { "PrimaryResidentId" });
            DropIndex("dbo.FlatMember", new[] { "SecondaryResidentId" });
            DropIndex("dbo.FlatMember", new[] { "SecondaryOwnerId" });
            DropIndex("dbo.FlatMember", new[] { "PrimaryOwnerId" });
            DropIndex("dbo.FlatMember", new[] { "FlatId" });
            DropTable("dbo.WaterMaintenence");
            DropTable("dbo.FlatMaintenenceItem");
            DropTable("dbo.FlatMaintenence");
            DropTable("dbo.ApartmentMaintenenceItem");
            DropTable("dbo.Maintenence");
            DropTable("dbo.MaintenenceItem");
            DropTable("dbo.People");
            DropTable("dbo.FlatMember");
            DropTable("dbo.Flat");
            DropTable("dbo.Apartment");
        }
    }
}
