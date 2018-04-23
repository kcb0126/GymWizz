namespace GymWizz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BarbelCurls : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BarbellCurls", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "Arms");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Arms", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "BarbellCurls");
        }
    }
}
