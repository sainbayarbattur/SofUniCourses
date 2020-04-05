using System.Collections.Generic;

namespace P04_Hospital
{
    public class Doctor
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public List<Patient> Patients = new List<Patient>();
    }
}
