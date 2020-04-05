using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, Doctor>();
            var departments = new Dictionary<string, Department>();

            var department = new Department();
            var doctor = new Doctor();
            var patient = new Patient();
            var room = new Room();

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departamentName = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patientName = tokens[3];
                var fullName = firstName + secondName;

                room = new Room
                {
                    RoomNumber = 0,
                    Patients = new List<Patient>()
                };

                patient = new Patient
                {
                    Department = new Department(),
                    Doctor = doctor,
                    Name = patientName,
                };

                doctor = new Doctor
                {
                    Department = departamentName,
                    Name = patientName,
                    Patients = new List<Patient>(),
                };

                department = new Department
                {
                    Rooms = new List<Room>(),
                    Doctors = new List<Doctor>(),
                    NameOfTheDepartment = departamentName,
                };

                if (!doctors.ContainsKey(firstName + secondName))
                {
                    doctors[fullName] = new Doctor();
                }
                if (!departments.ContainsKey(departamentName))
                {
                    departments[departamentName] = new Department();
                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        room = new Room
                        {
                            RoomNumber = rooms
                        };
                        departments[departamentName].Rooms.Add(room);
                    }
                }

                bool isThereRoom = departments[departamentName].Patients.Count < 60;
                if (isThereRoom)
                {
                    int roomToSave = 0;
                    departments[departamentName].Patients.Add(patient);
                    doctors[fullName].Patients.Add(patient);
                    for (int currRoom = 0; currRoom < departments[departamentName].Rooms.Count; currRoom++)
                    {
                        if (departments[departamentName].Rooms[currRoom].Patients.Count < 3)
                        {
                            roomToSave = currRoom;
                            break;
                        }
                    }
                    departments[departamentName].Rooms[roomToSave].Patients.Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Patients.Select(x => x.Name)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room1))
                {
                    var roomTag = room1 - 1;
                    var a = departments[args[0]].Rooms.Where(x => x.RoomNumber == room1 - 1).Select(x => x.Patients.Select(p => p.Name).OrderBy(o => o));
                    foreach (var currPatient in a.OrderBy(x => x))
                    {
                        Console.WriteLine(string.Join("\n", currPatient));
                    }
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].Patients.Select(x => x.Name).OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
