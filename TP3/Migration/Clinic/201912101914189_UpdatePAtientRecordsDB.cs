namespace TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePAtientRecordsDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientRecords", "Patient_PatientID", "dbo.Patients");
            DropIndex("dbo.PatientRecords", new[] { "Patient_PatientID" });
            RenameColumn(table: "dbo.PatientRecords", name: "Patient_PatientID", newName: "PatientID");
            AlterColumn("dbo.PatientRecords", "PatientID", c => c.Int(nullable: false));
            CreateIndex("dbo.PatientRecords", "PatientID");
            AddForeignKey("dbo.PatientRecords", "PatientID", "dbo.Patients", "PatientID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientRecords", "PatientID", "dbo.Patients");
            DropIndex("dbo.PatientRecords", new[] { "PatientID" });
            AlterColumn("dbo.PatientRecords", "PatientID", c => c.Int());
            RenameColumn(table: "dbo.PatientRecords", name: "PatientID", newName: "Patient_PatientID");
            CreateIndex("dbo.PatientRecords", "Patient_PatientID");
            AddForeignKey("dbo.PatientRecords", "Patient_PatientID", "dbo.Patients", "PatientID");
        }
    }
}
