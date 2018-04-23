namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BenchPress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BenchPress", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BenchPress");
        }
    }
}
