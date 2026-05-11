using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicApp2.Models
{
    internal class Appointment
    {
        public int ID { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
        public string Treatment { get; set; }
        public bool IsBooked { get; set; }

        public Appointment(int id, Patient patient, DateTime date,
            string treatment)
        {
            ID = id;
            Patient = patient;
            Date = date;
            Treatment = treatment;
            
        }

        public override string ToString()
        {
            return $"[{ID}] {Date:g} | {Patient.Name} | Treatment: {Treatment}";
        }
    }
}
