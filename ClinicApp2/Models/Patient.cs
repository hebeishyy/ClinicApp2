using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicApp2.Models
{
    internal class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

        public Patient(int id, string name, string phoneNumber, int age) 
        {
            ID = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Age = age;
        }
        public override string ToString()
        {
            return $"[{ID}] {Name} | Phone: {PhoneNumber} | Age: {Age} ";
        }
    }
}
