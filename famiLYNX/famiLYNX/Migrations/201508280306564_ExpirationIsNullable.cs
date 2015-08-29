namespace famiLYNX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpirationIsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Conversations", "ExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Conversations", "ExpirationDate", c => c.DateTime(nullable: false));
        }
    }
}
