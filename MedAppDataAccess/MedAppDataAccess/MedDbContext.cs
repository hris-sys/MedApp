namespace MedAppDataAccess
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class MedDbContext : DbContext
    {
        public DbSet<ActiveIngredient> ActiveIngedients { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<MedicineActiveIngredient> MedicinesActiveIngredients { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<PrescriptionMedicines> PrescriptionsMedicines { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<DoctorPatient> DoctorsPatients { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<PatientPrescription> PatientsPrescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=MedApp;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
