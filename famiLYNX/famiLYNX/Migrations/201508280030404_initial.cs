namespace famiLYNX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        Zip = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        IsEvent = c.Boolean(nullable: false),
                        Recurs = c.Boolean(nullable: false),
                        Family_Id = c.Int(),
                        CreatedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .ForeignKey("dbo.Members", t => t.CreatedBy_Id)
                .Index(t => t.Family_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserAddress_Id = c.Int(),
                        Conversation_Id = c.Int(),
                        Conversation_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.UserAddress_Id)
                .ForeignKey("dbo.Conversations", t => t.Conversation_Id)
                .ForeignKey("dbo.Conversations", t => t.Conversation_Id1)
                .Index(t => t.UserAddress_Id)
                .Index(t => t.Conversation_Id)
                .Index(t => t.Conversation_Id1);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrgName = c.String(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.FamilyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrgType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        OrgType_Id = c.Int(),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTypes", t => t.OrgType_Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.OrgType_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        TimeSubmitted = c.DateTime(nullable: false),
                        Contributor_Id = c.Int(),
                        Conversation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Contributor_Id)
                .ForeignKey("dbo.Conversations", t => t.Conversation_Id)
                .Index(t => t.Contributor_Id)
                .Index(t => t.Conversation_Id);
            
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        Family_Id = c.Int(nullable: false),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Family_Id, t.Member_Id })
                .ForeignKey("dbo.Families", t => t.Family_Id, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Family_Id)
                .Index(t => t.Member_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Conversation_Id1", "dbo.Conversations");
            DropForeignKey("dbo.Messages", "Conversation_Id", "dbo.Conversations");
            DropForeignKey("dbo.Messages", "Contributor_Id", "dbo.Members");
            DropForeignKey("dbo.Conversations", "CreatedBy_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "Conversation_Id", "dbo.Conversations");
            DropForeignKey("dbo.Members", "UserAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Roles", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Roles", "OrgType_Id", "dbo.FamilyTypes");
            DropForeignKey("dbo.Families", "Type_Id", "dbo.FamilyTypes");
            DropForeignKey("dbo.FamilyMembers", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.FamilyMembers", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Conversations", "Family_Id", "dbo.Families");
            DropIndex("dbo.FamilyMembers", new[] { "Member_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Family_Id" });
            DropIndex("dbo.Messages", new[] { "Conversation_Id" });
            DropIndex("dbo.Messages", new[] { "Contributor_Id" });
            DropIndex("dbo.Roles", new[] { "Member_Id" });
            DropIndex("dbo.Roles", new[] { "OrgType_Id" });
            DropIndex("dbo.Families", new[] { "Type_Id" });
            DropIndex("dbo.Members", new[] { "Conversation_Id1" });
            DropIndex("dbo.Members", new[] { "Conversation_Id" });
            DropIndex("dbo.Members", new[] { "UserAddress_Id" });
            DropIndex("dbo.Conversations", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Conversations", new[] { "Family_Id" });
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.Messages");
            DropTable("dbo.Roles");
            DropTable("dbo.FamilyTypes");
            DropTable("dbo.Families");
            DropTable("dbo.Members");
            DropTable("dbo.Conversations");
            DropTable("dbo.Addresses");
        }
    }
}
