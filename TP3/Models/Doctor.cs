//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor
    {
        public int DoctorID { get; set; }
        public int EmployeeID { get; set; }
        public int DoctorTypeID { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual DoctorType DoctorType { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
