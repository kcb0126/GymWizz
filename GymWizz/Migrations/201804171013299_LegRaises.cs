namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LegRaises : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LegRaises", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "SitUps", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "AbBikes", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "SitUpTouchingKnees", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PlankFromKnees", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Arms", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Leg", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Chest", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "TotalBody", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TotalBody");
            DropColumn("dbo.AspNetUsers", "Chest");
            DropColumn("dbo.AspNetUsers", "Leg");
            DropColumn("dbo.AspNetUsers", "Arms");
            DropColumn("dbo.AspNetUsers", "PlankFromKnees");
            DropColumn("dbo.AspNetUsers", "SitUpTouchingKnees");
            DropColumn("dbo.AspNetUsers", "AbBikes");
            DropColumn("dbo.AspNetUsers", "SitUps");
            DropColumn("dbo.AspNetUsers", "LegRaises");
        }
    }
}
