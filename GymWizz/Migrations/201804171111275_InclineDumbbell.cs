namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InclineDumbbell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "InclineDumbbell", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "Chest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Chest", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "InclineDumbbell");
        }
    }
}
