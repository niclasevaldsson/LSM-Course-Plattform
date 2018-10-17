namespace LSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fxes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "Name", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Modules", "Name", c => c.String(nullable: false, maxLength: 120));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modules", "Name", c => c.String());
            AlterColumn("dbo.Activities", "Name", c => c.String());
        }
    }
}
