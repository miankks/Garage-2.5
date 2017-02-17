namespace Garage2._5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fordons",
                c => new
                    {
                        FordonsId = c.Int(nullable: false, identity: true),
                        Regnr = c.String(),
                        Märke = c.String(),
                        Parkeringtid = c.DateTime(nullable: false),
                        MedlemId = c.Int(nullable: false),
                        FordonstypId = c.Int(nullable: false),
                        Fordontyps_FordontypId = c.Int(),
                    })
                .PrimaryKey(t => t.FordonsId)
                .ForeignKey("dbo.Fordonstyps", t => t.Fordontyps_FordontypId)
                .ForeignKey("dbo.Medlems", t => t.MedlemId, cascadeDelete: true)
                .Index(t => t.MedlemId)
                .Index(t => t.Fordontyps_FordontypId);
            
            CreateTable(
                "dbo.Fordonstyps",
                c => new
                    {
                        FordontypId = c.Int(nullable: false, identity: true),
                        Typ = c.String(),
                    })
                .PrimaryKey(t => t.FordontypId);
            
            CreateTable(
                "dbo.Medlems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FörNamn = c.String(),
                        EfterNamn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fordons", "MedlemId", "dbo.Medlems");
            DropForeignKey("dbo.Fordons", "Fordontyps_FordontypId", "dbo.Fordonstyps");
            DropIndex("dbo.Fordons", new[] { "Fordontyps_FordontypId" });
            DropIndex("dbo.Fordons", new[] { "MedlemId" });
            DropTable("dbo.Medlems");
            DropTable("dbo.Fordonstyps");
            DropTable("dbo.Fordons");
        }
    }
}
