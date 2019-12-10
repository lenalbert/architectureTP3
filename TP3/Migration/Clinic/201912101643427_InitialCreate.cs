namespace TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        ReasonID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.AppointmentID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .ForeignKey("dbo.Reasons", t => t.ReasonID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.PatientID)
                .Index(t => t.DoctorID)
                .Index(t => t.ReasonID)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        DoctorType_DoctorTypeID = c.Int(),
                        Employee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.DoctorID)
                .ForeignKey("dbo.DoctorTypes", t => t.DoctorType_DoctorTypeID)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID)
                .Index(t => t.DoctorType_DoctorTypeID)
                .Index(t => t.Employee_EmployeeID);
            
            CreateTable(
                "dbo.DoctorTypes",
                c => new
                    {
                        DoctorTypeID = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.DoctorTypeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastNameEmployee = c.String(),
                        FirstNameEmployee = c.String(),
                        EmailEmployee = c.String(),
                        AddressEmployee = c.String(),
                        TelephoneEmployee = c.Int(nullable: false),
                        BirthDateEmployee = c.DateTime(),
                        HiringDateEmployee = c.DateTime(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        LastNamePatient = c.String(),
                        FirstNamePatient = c.String(),
                        EmailPatient = c.String(),
                        AddressPatient = c.String(),
                        TelephonePatient = c.Int(nullable: false),
                        BirthDatePatient = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientID);
            
            CreateTable(
                "dbo.PatientRecords",
                c => new
                    {
                        PatientRecordID = c.Int(nullable: false, identity: true),
                        PatientHistory = c.String(),
                        Patient_PatientID = c.Int(),
                    })
                .PrimaryKey(t => t.PatientRecordID)
                .ForeignKey("dbo.Patients", t => t.Patient_PatientID)
                .Index(t => t.Patient_PatientID);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        ReasonID = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        ReasonCost = c.String(),
                        duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReasonID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        Equipment_EquipmentID = c.Int(),
                    })
                .PrimaryKey(t => t.RoomID)
                .ForeignKey("dbo.Equipments", t => t.Equipment_EquipmentID)
                .Index(t => t.Equipment_EquipmentID);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        EquipmentLabel = c.String(),
                        EquipmentPrice = c.Int(nullable: false),
                        Room_RoomID = c.Int(),
                    })
                .PrimaryKey(t => t.EquipmentID)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomID)
                .Index(t => t.Room_RoomID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rooms", "Equipment_EquipmentID", "dbo.Equipments");
            DropForeignKey("dbo.Equipments", "Room_RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Appointments", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Appointments", "ReasonID", "dbo.Reasons");
            DropForeignKey("dbo.PatientRecords", "Patient_PatientID", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Doctors", "Employee_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Doctors", "DoctorType_DoctorTypeID", "dbo.DoctorTypes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Equipments", new[] { "Room_RoomID" });
            DropIndex("dbo.Rooms", new[] { "Equipment_EquipmentID" });
            DropIndex("dbo.PatientRecords", new[] { "Patient_PatientID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropIndex("dbo.Doctors", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.Doctors", new[] { "DoctorType_DoctorTypeID" });
            DropIndex("dbo.Appointments", new[] { "RoomID" });
            DropIndex("dbo.Appointments", new[] { "ReasonID" });
            DropIndex("dbo.Appointments", new[] { "DoctorID" });
            DropIndex("dbo.Appointments", new[] { "PatientID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Equipments");
            DropTable("dbo.Rooms");
            DropTable("dbo.Reasons");
            DropTable("dbo.PatientRecords");
            DropTable("dbo.Patients");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Employees");
            DropTable("dbo.DoctorTypes");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
