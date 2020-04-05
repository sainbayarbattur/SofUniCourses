using System.Collections.Generic;

namespace P04_Hospital
{
    public class Department
    {
        public string NameOfTheDepartment { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();

        public List<Doctor> Doctors = new List<Doctor>();

        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
