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
    
    public partial class Patient
    {    
        public int PatientID { get; set; }
        public string LastNamePatient { get; set; }
        public string FirstNamePatient { get; set; }
        public string EmailPatient { get; set; }
        public string AddressPatient { get; set; }
        public int TelephonePatient { get; set; }
        public Nullable<System.DateTime> BirthDatePatient { get; set; }
    
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<PatientRecord> PatientRecords { get; set; }
    }
}
