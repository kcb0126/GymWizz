namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DumbellWalkingLunge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DumbellWalkingLunge", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DumbellWalkingLunge");
        }
    }
}
