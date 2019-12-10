using System;
using System.Collections.Generic;
using TP3.Models;

namespace TP3.DAL
{
    public class Data
    {
        public static List<Patient> getPatients()
        {
            List<Patient> patients = new List<Patient>()
            {
                new Patient()
                {
                    LastNamePatient="Albert",
                    FirstNamePatient="Lena",
                    EmailPatient="lena@lena.com",
                    AddressPatient="lenamaison",
                },
            };
            return patients;
        }

        public static List<PatientRecord> getPatientRecords()
        {
            List<PatientRecord> patientRecords = new List<PatientRecord>()
            {
                new PatientRecord()
                {
                    PatientHistory = "A toutes ses dents" ,
                    PatientID = 1
                },
            };
            return patientRecords;
        }

        public static List<Reason> getReasons()
        {
            List<Reason> reasons = new List<Reason>()
            {
                new Reason()
                {
                    Label="Extraction de dents",
                    ReasonCost="450",
                    duration=60,
                },
            };
            return reasons ;
        }

        public static List<Room> getRooms()
        {
            List<Room> rooms = new List<Room>()
            {
                new Room()
                {
                    RoomLabel="Morgue",
                },
            };
            return rooms;
        }

        public static List<Equipment> getEquipments()
        {
            List<Equipment> equipments = new List<Equipment>()
            {
                new Equipment()
                {
                    EquipmentLabel="Scalpel",
                    EquipmentPrice=500
                },
            };
            return equipments;
        }
        public static List<Employee> getEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    LastNameEmployee="Pichollet",
                    FirstNameEmployee="Quentin",
                    EmailEmployee="quentin@quentin.com",
                    AddressEmployee="quentinmaison",

                },
            };
            return employees;
        }

        public static List<DoctorType> getDoctorTypes()
        {
            List<DoctorType> doctortypes = new List<DoctorType>()
            {
                new DoctorType()
                {
                    Label = "Dentiste"
                },
            };
            return doctortypes;
        }

        public static List<Doctor> getDoctors()
        {
            List<Doctor> doctors = new List<Doctor>()
            {
                new Doctor()
                {
                    DoctorTypeID = 1 ,
                    EmployeeID = 2
                },
            };
            return doctors;
        }

        public static List<Appointment> getAppointments()
        {
            List<Appointment> appointment = new List<Appointment>()
            {
                new Appointment()
                {
                    PatientID = 1,
                    DoctorID = 1,
                    ReasonID = 1,
                    RoomID = 1,
                    AppointmentDate = DateTime.Now,
                    StartTime = new TimeSpan(1,2,0,30,0)
                },
            };
            return appointment;
        }

        public static List<RoleViewModel> getRoleViewModels()
        {
            List<RoleViewModel> roleviewmodel = new List<RoleViewModel>()
            {
                new RoleViewModel()
                {
                    Id="0",
                    Name="Secretary"
                },
                new RoleViewModel()
                {
                    Id="1",
                    Name="Doctor"
                },
                new RoleViewModel()
                {
                    Id="2",
                    Name="Patient"
                },
            };
            return roleviewmodel;
        }

    }
}