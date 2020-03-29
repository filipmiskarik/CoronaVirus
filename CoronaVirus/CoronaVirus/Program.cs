using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaVirus
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient patient = new Patient("9596961202", "Pdfsadfaprik", "Papucka",  DateTime.Today, (DateTime.Today).AddDays(-1) , Health.Infected, Transmission.Local, new Coordinate((50, 2, 45.1), (15, 31, 21.3)), new List<Patient>());
            Patient patient1 = new Patient("9596961202", "Paprik", "Papucka", DateTime.Today, (DateTime.Today).AddDays(-1), Health.Infected, Transmission.Local, new Coordinate((50, 2, 45.1), (15, 31, 21.3)), new List<Patient>());

            Patient patient2 = new Patient("7897897899", "Michail", "Horacek", DateTime.Today, (DateTime.Today).AddDays(-5), Health.Recovered, Transmission.ImportedOnly, new Coordinate((50, 2, 45.1), (15, 31, 21.3)), new List<Patient>());

            Patient patient3 = new Patient("7897897899", "gfdsfg", "Horacgdfsgek", DateTime.Today, (DateTime.Today).AddDays(-8), Health.Recovered, Transmission.ImportedOnly, new Coordinate((50, 2, 45.1), (15, 31, 21.3)), new List<Patient>());

            List<Patient> patients = new List<Patient>() { patient2, patient, patient3, patient1 };

            patients.Sort();

            foreach (Patient p in patients)
            {
                Console.WriteLine(p.ToString());
            }
            
            Console.ReadLine();
        }
    }
}
