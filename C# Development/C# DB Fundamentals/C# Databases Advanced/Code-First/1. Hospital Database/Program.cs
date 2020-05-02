namespace P01_HospitalDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            using var db = new HospitalContext();

            //var patient = new Patient
            //{
            //    FirstName = "Valeri",
            //    LastName = "Stopkanov",
            //    Address = "Lulin",
            //    Email = "babichikiobicamdaqm@abv.bg",
            //    HasInsurance = false,
            //};

            //var medicament = new Medicament
            //{
            //    Name = "Heroin"
            //};

            //db.Medicaments.Find(1).Prescriptions
            //    .Add(new PatientMedicament
            //    {
            //        MedicamentId = 1,
            //        PatientId = 1
            //    });

            var medicament = db.Medicaments.Find(1);
            var patient = db.Patients.Find(2);

            db.PatientsMedicaments.Add(new PatientMedicament
            {
                Medicament = medicament,
                Patient = patient
            });

            //db.Database.Migrate();

            //var p = db.PatientsMedicaments.First(pm => pm.PatientId == 1);

            //Console.WriteLine(p.Patient.FirstName);

            //medicament.Prescriptions.Add(new PatientMedicament 
            //{
            //    Patient = patient,
            //    Medicament = medicament
            //});

            //db.Medicaments.Add(medicament);

            //patient.Prescriptions.Add(new PatientMedicament
            //{
            //    Medicament = medicament,
            //    Patient = patient
            //});

            //db.Patients.Add(patient);

            db.SaveChanges();
        }
    }
}