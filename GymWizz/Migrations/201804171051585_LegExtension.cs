namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LegExtension : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LegExtension", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "Leg");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Leg", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "LegExtension");
        }
    }
}
