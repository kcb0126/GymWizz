namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetAlarm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GetAlarm", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GetAlarm");
        }
    }
}
