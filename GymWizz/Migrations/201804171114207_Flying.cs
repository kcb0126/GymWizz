namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Flying : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Flying", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Flying");
        }
    }
}
