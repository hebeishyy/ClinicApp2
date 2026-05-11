using ClinicApp2.Models;
using ClinicApp2.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicApp2.UI
{
    internal class Menu
    {
        private readonly PatientService _patientService;
        private readonly AppointmentService _appointmentService;

        public Menu()
        {
            _patientService = new PatientService();
            _appointmentService = new AppointmentService();
        }

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("=== DENTAL CLINIC SYSTEM ===");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View Patients");
                Console.WriteLine("3. Create Appointment");
                Console.WriteLine("4. View Appointments");
                Console.WriteLine("0. Exit");

                Console.Write("\nChoose: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPatientMenu();
                        break;

                    case "2":
                        ViewPatientsMenu();
                        break;

                    case "3":
                        CreateAppointmentMenu();
                        break;

                    case "4":
                        ViewAppointmentsMenu();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
        }

        private void AddPatientMenu()
        {
            Console.Clear();

            Console.WriteLine("=== ADD PATIENT ===");

           
            string name = InputHelper.ReadString("Name: ");

            string phone = InputHelper.ReadPhone("Phone: ");

            int age = InputHelper.ReadInt("Age: ");

            _patientService.AddPatient(name, phone, age);

            Console.WriteLine("\nPatient added successfully.");
            Pause();
        }

        private void ViewPatientsMenu()
        {
            Console.Clear();

            List<Patient> patients = _patientService.GetAllPatients();

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found.");
            }
            else
            {
                foreach (Patient patient in patients)
                {
                    Console.WriteLine(patient);
                }
            }

            Pause();
        }

        private void CreateAppointmentMenu()
        {
            Console.Clear();

            List<Patient> patients = _patientService.GetAllPatients();

            if (patients.Count == 0)
            {
                Console.WriteLine("Add patients first.");
                Pause();
                return;
            }

            Console.WriteLine("=== PATIENTS ===");

            foreach (Patient p in patients)
            {
                Console.WriteLine(p);
            }

            Console.Write("\nEnter Patient ID: ");
            int patientId = int.Parse(Console.ReadLine()!);

            Patient? patient =
                _patientService.GetPatientById(patientId);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                Pause();
                return;
            }

            Console.Write("Appointment Date (yyyy-MM-dd HH:mm): ");

            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Enter a valid date (example: 2026-05-15 14:00):");
            }

            Console.Write("Treatment Type: ");
            string treatment = Console.ReadLine()!;

            bool created =
                _appointmentService.CreateAppointment(
                    patient,
                    date,
                    treatment);

            if (!created)
            {
                Console.WriteLine("This time slot is already booked.");
            }
            else
            {
                Console.WriteLine("Appointment created.");
            }

            Pause();
        }

        private void ViewAppointmentsMenu()
        {
            Console.Clear();

            List<Appointment> appointments =
                _appointmentService.GetAllAppointments();

            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found.");
            }
            else
            {
                foreach (Appointment appointment in appointments)
                {
                    Console.WriteLine(appointment);
                }
            }

            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
