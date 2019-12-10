namespace TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "DoctorType_DoctorTypeID", "dbo.DoctorTypes");
            DropForeignKey("dbo.Doctors", "Employee_EmployeeID", "dbo.Employees");
            DropIndex("dbo.Doctors", new[] { "DoctorType_DoctorTypeID" });
            DropIndex("dbo.Doctors", new[] { "Employee_EmployeeID" });
            RenameColumn(table: "dbo.Doctors", name: "DoctorType_DoctorTypeID", newName: "DoctorTypeID");
            RenameColumn(table: "dbo.Doctors", name: "Employee_EmployeeID", newName: "EmployeeID");
            AddColumn("dbo.Rooms", "RoomLabel", c => c.String());
            AlterColumn("dbo.Doctors", "DoctorTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Doctors", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "EmployeeID");
            CreateIndex("dbo.Doctors", "DoctorTypeID");
            AddForeignKey("dbo.Doctors", "DoctorTypeID", "dbo.DoctorTypes", "DoctorTypeID", cascadeDelete: true);
            AddForeignKey("dbo.Doctors", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Doctors", "DoctorTypeID", "dbo.DoctorTypes");
            DropIndex("dbo.Doctors", new[] { "DoctorTypeID" });
            DropIndex("dbo.Doctors", new[] { "EmployeeID" });
            AlterColumn("dbo.Doctors", "EmployeeID", c => c.Int());
            AlterColumn("dbo.Doctors", "DoctorTypeID", c => c.Int());
            DropColumn("dbo.Rooms", "RoomLabel");
            RenameColumn(table: "dbo.Doctors", name: "EmployeeID", newName: "Employee_EmployeeID");
            RenameColumn(table: "dbo.Doctors", name: "DoctorTypeID", newName: "DoctorType_DoctorTypeID");
            CreateIndex("dbo.Doctors", "Employee_EmployeeID");
            CreateIndex("dbo.Doctors", "DoctorType_DoctorTypeID");
            AddForeignKey("dbo.Doctors", "Employee_EmployeeID", "dbo.Employees", "EmployeeID");
            AddForeignKey("dbo.Doctors", "DoctorType_DoctorTypeID", "dbo.DoctorTypes", "DoctorTypeID");
        }
    }
}
