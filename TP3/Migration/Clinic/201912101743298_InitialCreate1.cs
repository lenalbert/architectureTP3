namespace TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "TelephoneEmployee", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "TelephoneEmployee", c => c.Int(nullable: false));
        }
    }
}
