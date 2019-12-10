namespace TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BDDandRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
    }
}
