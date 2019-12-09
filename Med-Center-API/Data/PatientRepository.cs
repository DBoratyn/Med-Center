using System;
using System.Threading.Tasks;
using Med_Center_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Med_Center_API.Data
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _context;

        public PatientRepository(DataContext context) {
            _context = context;
        }

        public async Task<Patient> AddPatient(Patient patient) 
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

    }
}