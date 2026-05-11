using ClinicApp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicApp2.Services
{
    internal class AppointmentService
    {
        private List<Appointment> _appointments = new();
        private int _nextId = 1;

        public bool CreateAppointment(Patient patient,
            DateTime date, 
            string treatmentType)
        {
            bool overlap = _appointments.Any(a =>
                date < a.Date.AddHours(1) &&
                a.Date < date.AddHours(1)
            );

            if (overlap)
                return false;

            Appointment appointment = 
                new Appointment(_nextId++, patient, date, treatmentType);
            _appointments.Add(appointment);

            return true;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointments
                .OrderBy(a => a.Date)
                .ToList();
        }
    }
}
