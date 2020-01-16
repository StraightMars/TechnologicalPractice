namespace TechnologicalPracticeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ecolabels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Image = c.Binary(),
                        Description = c.String(),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Address = c.String(nullable: false, maxLength: 25),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Country_Ecolabel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryID = c.Int(nullable: false),
                        EcolabelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .ForeignKey("dbo.Ecolabels", t => t.EcolabelID, cascadeDelete: true)
                .Index(t => t.CountryID)
                .Index(t => t.EcolabelID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Demand_Ecolabel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EcolabelID = c.Int(nullable: false),
                        DemandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Demands", t => t.DemandID, cascadeDelete: true)
                .ForeignKey("dbo.Ecolabels", t => t.EcolabelID, cascadeDelete: true)
                .Index(t => t.EcolabelID)
                .Index(t => t.DemandID);
            
            CreateTable(
                "dbo.Demands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rule = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EcoType_Ecolabel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EcoTypeID = c.Int(nullable: false),
                        EcolabelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ecolabels", t => t.EcolabelID, cascadeDelete: true)
                .ForeignKey("dbo.EcoTypes", t => t.EcoTypeID, cascadeDelete: true)
                .Index(t => t.EcoTypeID)
                .Index(t => t.EcolabelID);
            
            CreateTable(
                "dbo.EcoTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonalCabinets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.Int(nullable: false),
                        EcolabelID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ecolabels", t => t.EcolabelID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.EcolabelID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        FatherName = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        AccessLevelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccessLevels", t => t.AccessLevelID, cascadeDelete: true)
                .Index(t => t.AccessLevelID);
            
            CreateTable(
                "dbo.AccessLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PersonalCabinets", "PersonID", "dbo.People");
            DropForeignKey("dbo.People", "AccessLevelID", "dbo.AccessLevels");
            DropForeignKey("dbo.PersonalCabinets", "EcolabelID", "dbo.Ecolabels");
            DropForeignKey("dbo.EcoType_Ecolabel", "EcoTypeID", "dbo.EcoTypes");
            DropForeignKey("dbo.EcoType_Ecolabel", "EcolabelID", "dbo.Ecolabels");
            DropForeignKey("dbo.Demand_Ecolabel", "EcolabelID", "dbo.Ecolabels");
            DropForeignKey("dbo.Demand_Ecolabel", "DemandID", "dbo.Demands");
            DropForeignKey("dbo.Country_Ecolabel", "EcolabelID", "dbo.Ecolabels");
            DropForeignKey("dbo.Country_Ecolabel", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Ecolabels", "CompanyID", "dbo.Companies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.People", new[] { "AccessLevelID" });
            DropIndex("dbo.PersonalCabinets", new[] { "PersonID" });
            DropIndex("dbo.PersonalCabinets", new[] { "EcolabelID" });
            DropIndex("dbo.EcoType_Ecolabel", new[] { "EcolabelID" });
            DropIndex("dbo.EcoType_Ecolabel", new[] { "EcoTypeID" });
            DropIndex("dbo.Demand_Ecolabel", new[] { "DemandID" });
            DropIndex("dbo.Demand_Ecolabel", new[] { "EcolabelID" });
            DropIndex("dbo.Country_Ecolabel", new[] { "EcolabelID" });
            DropIndex("dbo.Country_Ecolabel", new[] { "CountryID" });
            DropIndex("dbo.Ecolabels", new[] { "CompanyID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AccessLevels");
            DropTable("dbo.People");
            DropTable("dbo.PersonalCabinets");
            DropTable("dbo.EcoTypes");
            DropTable("dbo.EcoType_Ecolabel");
            DropTable("dbo.Demands");
            DropTable("dbo.Demand_Ecolabel");
            DropTable("dbo.Countries");
            DropTable("dbo.Country_Ecolabel");
            DropTable("dbo.Companies");
            DropTable("dbo.Ecolabels");
        }
    }
}
