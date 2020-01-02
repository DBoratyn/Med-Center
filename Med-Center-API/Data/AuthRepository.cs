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

        public async Task<IEnumerable<DoctorService>> getDoctorServices(string DoctorName)
        {
            List<DoctorService> services = await _context.DoctorServices.ToListAsync();
            IEnumerable<DoctorService> filteredServices = services.FindAll(x => x.DoctorName.ToLower() == DoctorName.ToLower());
            return filteredServices;
        }

        public async Task<IEnumerable<DoctorService>> GetAllDoctorServices()
        {
            List<DoctorService> services = await _context.DoctorServices.ToListAsync();
            return services;
        }

        public async Task<DoctorService> AddDoctorService (DoctorService service) {
            await _context.DoctorServices.AddAsync(service);
            await _context.SaveChangesAsync();
            return service;
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
    }
}