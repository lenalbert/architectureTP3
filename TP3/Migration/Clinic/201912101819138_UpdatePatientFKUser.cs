namespace TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatientFKUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Patients", "TelephonePatient", c => c.String());
            CreateIndex("dbo.Patients", "User_Id");
            AddForeignKey("dbo.Patients", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Patients", new[] { "User_Id" });
            AlterColumn("dbo.Patients", "TelephonePatient", c => c.Int(nullable: false));
            DropColumn("dbo.Patients", "User_Id");
        }
    }
}
