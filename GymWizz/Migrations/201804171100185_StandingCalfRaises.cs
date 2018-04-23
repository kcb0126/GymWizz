namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StandingCalfRaises : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "StandingCalfRaises", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "StandingCalfRaises");
        }
    }
}
