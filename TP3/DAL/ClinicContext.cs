using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TP3.Models
{
    public class ClinicContext : IdentityDbContext<ApplicationUser>
    {
        public ClinicContext() : base("DentalClinicDB") { }
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<DoctorType> DoctorTypes { get; set; }
        public virtual DbSet<Reason> Reasons { get; set; }
        public virtual DbSet<PatientRecord> PatientRecord { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }


        public static ClinicContext Create()
        {
            return new ClinicContext();
        }

        public System.Data.Entity.DbSet<TP3.Models.RoleViewModel> RoleViewModels { get; set; }
    }
}

