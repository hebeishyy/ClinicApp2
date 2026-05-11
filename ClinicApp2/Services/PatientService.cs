using ClinicApp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicApp2.Services
{
    internal class PatientService
    {
        private List<Patient> _patients = new();
        private int _nextId = 1;

        public void AddPatient(string name, string phoneNumber, int age)
        {
            Patient patient = new(_nextId++, name, phoneNumber, age);
            _patients.Add(patient);
        }

        public List<Patient> GetAllPatients()
        {
            return _patients;
        }

        public Patient? GetPatientById(int id)
        {
            return _patients.FirstOrDefault(p => p.ID == id);
        }
    }
}
