namespace famiLYNX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConversationAddFamily : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Conversations", name: "Family_Id", newName: "WhichFam_Id");
            RenameIndex(table: "dbo.Conversations", name: "IX_Family_Id", newName: "IX_WhichFam_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Conversations", name: "IX_WhichFam_Id", newName: "IX_Family_Id");
            RenameColumn(table: "dbo.Conversations", name: "WhichFam_Id", newName: "Family_Id");
        }
    }
}
