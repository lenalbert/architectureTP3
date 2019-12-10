namespace TP3.Migration.Clinic
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TP3.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<TP3.Models.ClinicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migration\Clinic";
        }

        protected override void Seed(TP3.Models.ClinicContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
           
            context.Patients.AddOrUpdate(p => new { p.LastNamePatient, p.FirstNamePatient, p.EmailPatient, p.AddressPatient }, Data.getPatients().ToArray());
            context.Reasons.AddOrUpdate(p => new { p.Label, p.ReasonCost, p.duration}, Data.getReasons().ToArray());
            context.Room.AddOrUpdate(p => new { p.RoomLabel}, Data.getRooms().ToArray());
            context.Equipment.AddOrUpdate(p => new {p.EquipmentLabel,p.EquipmentPrice }, Data.getEquipments().ToArray());
            context.Employees.AddOrUpdate(p => new {p.LastNameEmployee, p.FirstNameEmployee, p.EmailEmployee, p.AddressEmployee }, Data.getEmployees().ToArray());
            context.DoctorTypes.AddOrUpdate(p => new {p.Label}, Data.getDoctorTypes().ToArray());
            context.Doctor.AddOrUpdate(p => new {p.DoctorTypeID, p.EmployeeID}, Data.getDoctors().ToArray());
            context.PatientRecord.AddOrUpdate(p => new { p.PatientHistory,p.PatientID }, Data.getPatientRecords().ToArray());
        //    context.Appointment.AddOrUpdate(p => new { p.PatientID,p.DoctorID,p.ReasonID,p.RoomID,/*p.AppointmentDate,p.StartTime */ }, Data.getAppointments().ToArray());


            context.SaveChanges();
        }
    }
}
