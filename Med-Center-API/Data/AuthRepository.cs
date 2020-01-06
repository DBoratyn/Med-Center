using System;
using System.Threading.Tasks;
using Med_Center_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Med_Center_API.Dtos;
using System.Collections.Generic;

namespace Med_Center_API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository( DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null) {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)){
                return null;
            }        
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using( var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) {
                    if (computedHash[i] != passwordHash[i]){
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> getUser(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
            return user;
        }

        public async Task<User> getUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<Sickness>> getSicknessById(int id)
        {
            List<Sickness> services = await _context.Sicknesses.ToListAsync();
            IEnumerable<Sickness> filteredServices = services.FindAll(x => x.appointmentId == id);
            return filteredServices;
        }

        public async Task<Sickness> getSingleSicknessById(int id)
        {
            var sickness = await _context.Sicknesses.FirstOrDefaultAsync(x => x.id == id);
            return sickness;
        }

        public async Task<IEnumerable<DoctorService>> getDoctorServices(string DoctorName)
        {
            List<DoctorService> services = await _context.DoctorServices.ToListAsync();
            IEnumerable<DoctorService> filteredServices = services.FindAll(x => x.DoctorName.ToLower() == DoctorName.ToLower());
            return filteredServices;
        }

        public async Task<IEnumerable<Appointment>> GetDoctorAppointments(string DoctorName)
        {
            List<Appointment> services = await _context.Appointments.ToListAsync();
            IEnumerable<Appointment> filteredServices = services.FindAll(x => x.doctor.ToLower() == DoctorName.ToLower());
            return filteredServices;
        }

        public async Task<IEnumerable<DoctorService>> GetAllDoctorServices()
        {
            List<DoctorService> services = await _context.DoctorServices.ToListAsync();
            return services;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            List<Appointment> appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }

        public async Task<DoctorService> AddDoctorService (DoctorService service) {
            await _context.DoctorServices.AddAsync(service);
            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Visit> AddVisit(Visit visit)
        {
            await _context.Visits.AddAsync(visit);
            await _context.SaveChangesAsync();
            return visit;
        }

        public async Task<Sickness> AddSickness(Sickness sickness)
        {
            await _context.Sicknesses.AddAsync(sickness);
            await _context.SaveChangesAsync();
            return sickness;
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using( var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username)) {
                return true;
            }
            return false;
        }

        public async Task<DoctorService> getDoctoServiceById(int id)
        {
            var service = await _context.DoctorServices.FirstOrDefaultAsync(u => u.Id == id);
            return service;
        }

        public async Task<Visit> getVisitById(int id)
        {
            var visit = await _context.Visits.FirstOrDefaultAsync(u => u.appointmentId == id);
            return visit;
        }

        public async Task<Appointment> getAppointmentById(int id)
        {
            var appointment = await _context.Appointments.FirstOrDefaultAsync(u => u.Id == id);
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsByPesel(string Pesel)
        {
            var appointment = await _context.Appointments.ToListAsync();
            var appointmentfiltered = appointment.FindAll(x => x.patientpesel == Pesel);
            return appointmentfiltered;
        }

        public async Task<Patient> getPatientById(int id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(u => u.Id == id);
            return patient;
        }
    }
}