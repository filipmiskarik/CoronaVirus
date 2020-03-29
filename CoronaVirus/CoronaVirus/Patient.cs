using iText.IO.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaVirus
{
    class Patient : IComparable<Patient>
    {
        public string rodneCislo { get; private set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public DateTime datumNarozeni { get; set; }
        public DateTime denNakazy { get; set; }
        public Health healthEnum { get; set; }
        public Transmission transmissionEnum { get; set; }
        public Coordinate mistoPobytu { get; set; }
        public List<Patient> relatives = new List<Patient>();

        public Patient(string rodneCislo, string jmeno, string prijmeni, DateTime datumNarozeni, DateTime denNakazy, Health healthEnum, Transmission transmissionEnum, Coordinate mistoPobytu, List<Patient> relatives)
        {
            this.rodneCislo = rodneCislo;
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.datumNarozeni = datumNarozeni;
            this.denNakazy = denNakazy;
            this.healthEnum = healthEnum;
            this.transmissionEnum = transmissionEnum;
            this.mistoPobytu = mistoPobytu;
            this.relatives = relatives;
        }

        public override bool Equals(object obj)
        {
            Patient patient = (Patient)obj;

            if (
                patient.rodneCislo == rodneCislo &&
                patient.jmeno == jmeno &&
                patient.prijmeni == prijmeni &&
                patient.datumNarozeni == datumNarozeni &&
                patient.denNakazy == denNakazy &&
                patient.healthEnum == healthEnum &&
                patient.transmissionEnum == transmissionEnum &&
                patient.mistoPobytu.Equals(mistoPobytu) &&
                patient.relatives.SequenceEqual(relatives)
                )
            {
                return true;
            }

            else return false;
        }
        public override int GetHashCode()
        {
            return (rodneCislo, jmeno, prijmeni, datumNarozeni, denNakazy, healthEnum, transmissionEnum, mistoPobytu, relatives).GetHashCode();
        }
        public override string ToString()
        {
            if(healthEnum == Health.Deceased)
            {
                return "Mrtvy pacient " + jmeno + " " + prijmeni + " narozen dne:  " + datumNarozeni + " nakazen dne: " + denNakazy + " se naposled pohyboval: " + mistoPobytu + " nakazeni pribuzni " + String.Join(",", relatives);
            }
            if(healthEnum == Health.Recovered)
            {
                return "Vyleceny pacient " + jmeno + " " + prijmeni + " narozen dne:  " + datumNarozeni + " nakazen dne: " + denNakazy + " se pohybuje na souradnicich: " + mistoPobytu + " nakazeni pribuzni " + String.Join(",", relatives);
            }
            return "Nemocny pacient " + jmeno + " " + prijmeni + " narozen dne:  " + datumNarozeni + " nakazen dne: " + denNakazy + " se pohybuje na souradnicich: " + mistoPobytu + " nakazeni pribuzni " + String.Join(",", relatives);
        }
        public void addRelative(Patient patient)
        {
            relatives.Add(patient);
        }
        public int CompareTo(Patient other)
        {
            if (denNakazy > other.denNakazy)
                return 1;
            else if (denNakazy < other.denNakazy)
                return -1;
            else 
                return 0;
        }
    }
}
