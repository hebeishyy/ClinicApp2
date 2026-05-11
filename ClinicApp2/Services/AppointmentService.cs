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

        public bool CreateAppointment(
            Patient patient,
            DateTime date,
            string treatmentType)
        {
            bool slotTaken = _appointments.Any(a => a.Date == date);

            if (slotTaken)
            {
                return false;
            }

            Appointment appointment =
                new(_nextId++, patient, date, treatmentType, true);

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
