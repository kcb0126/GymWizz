namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CloseGripBarbellBenchPress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CloseGripBarbellBenchPress", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CloseGripBarbellBenchPress");
        }
    }
}
