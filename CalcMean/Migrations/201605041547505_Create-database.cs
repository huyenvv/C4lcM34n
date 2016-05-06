namespace CalcMean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DotChotSo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        TongThu = c.Decimal(precision: 18, scale: 2),
                        TongChi = c.Decimal(precision: 18, scale: 2),
                        IsChot = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        CreateBy = c.String(nullable: false),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DsChiTieu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserTieuId = c.String(),
                        ChotSoId = c.Int(nullable: false),
                        CreateBy = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DotChotSo", t => t.ChotSoId, cascadeDelete: true)
                .Index(t => t.ChotSoId);
            
            CreateTable(
                "dbo.UserInChiTieu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ForUserId = c.String(nullable: false, maxLength: 128),
                        ChiTieuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ForUserId, cascadeDelete: true)
                .ForeignKey("dbo.DsChiTieu", t => t.ChiTieuId, cascadeDelete: true)
                .Index(t => t.ForUserId)
                .Index(t => t.ChiTieuId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Name = c.String(),
                        CreateDate = c.DateTime(),
                        PhoneNumber = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DsNopTruoc",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NguoiNopId = c.String(nullable: false, maxLength: 128),
                        ChotSoId = c.Int(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.NguoiNopId, cascadeDelete: true)
                .Index(t => t.NguoiNopId);
            
            CreateTable(
                "dbo.TienGao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChotSoId = c.Int(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DotChotSo", t => t.ChotSoId, cascadeDelete: true)
                .Index(t => t.ChotSoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TienGao", "ChotSoId", "dbo.DotChotSo");
            DropForeignKey("dbo.UserInChiTieu", "ChiTieuId", "dbo.DsChiTieu");
            DropForeignKey("dbo.UserInChiTieu", "ForUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DsNopTruoc", "NguoiNopId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DsChiTieu", "ChotSoId", "dbo.DotChotSo");
            DropIndex("dbo.TienGao", new[] { "ChotSoId" });
            DropIndex("dbo.UserInChiTieu", new[] { "ChiTieuId" });
            DropIndex("dbo.UserInChiTieu", new[] { "ForUserId" });
            DropIndex("dbo.DsNopTruoc", new[] { "NguoiNopId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.DsChiTieu", new[] { "ChotSoId" });
            DropTable("dbo.TienGao");
            DropTable("dbo.DsNopTruoc");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserInChiTieu");
            DropTable("dbo.DsChiTieu");
            DropTable("dbo.DotChotSo");
        }
    }
}
