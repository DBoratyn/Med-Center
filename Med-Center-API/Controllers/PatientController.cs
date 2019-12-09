using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Med_Center_API.Data;
using Med_Center_API.Dtos;
using Med_Center_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Med_Center_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IPatientRepository _repo;
        private readonly IConfiguration _config;
        public PatientController(IPatientRepository repo, IConfiguration config, DataContext context)
        {
            _repo = repo;
            _config = config;
            _context = context;
        }

        [HttpGet("getallpatients")]
        public async Task<IActionResult> GetAllPatients()
        {
           var Patients = await _context.Patients.ToListAsync();

           return Ok(Patients);
        }

        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody]PatientForRegisterDto patientForRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patientToCreate = new Patient
            {
                Pesel = patientForRegisterDto.Pesel,
                FileNumber = patientForRegisterDto.FileNumber,
                Name = patientForRegisterDto.Name,
                SecondName = patientForRegisterDto.SecondName,
                Surname = patientForRegisterDto.Surname,
                DateOfBirth = patientForRegisterDto.DateOfBirth,
                PlaceOfBirth = patientForRegisterDto.PlaceOfBirth,
                Gender = patientForRegisterDto.Gender,
                GuardianNameAndSurname = patientForRegisterDto.GuardianNameAndSurname,
                Foreign = patientForRegisterDto.Foreign,
                Country = patientForRegisterDto.Country,
                City = patientForRegisterDto.City,
                Street = patientForRegisterDto.Street,
                HouseNumber = patientForRegisterDto.HouseNumber,
                ApartmentNumber = patientForRegisterDto.ApartmentNumber,
                ZipCode = patientForRegisterDto.ZipCode,
                PostOffice = patientForRegisterDto.PostOffice,
                PhoneNumber = patientForRegisterDto.PhoneNumber,
                Email = patientForRegisterDto.Email,
                Profession = patientForRegisterDto.Profession,
                Education = patientForRegisterDto.Education,
                Employment = patientForRegisterDto.Employment,
                DocumentNumber = patientForRegisterDto.DocumentNumber,
                Type = patientForRegisterDto.Type,
                Series = patientForRegisterDto.Series,
                DocumentCountry = patientForRegisterDto.DocumentCountry,
                PersonToAuthName = patientForRegisterDto.PersonToAuthName,
                PersonToAuthSurname = patientForRegisterDto.PersonToAuthSurname,
                PersonToAuthPesel = patientForRegisterDto.PersonToAuthPesel,
                PersonToAuthKinship = patientForRegisterDto.PersonToAuthKinship
            };

            await _repo.AddPatient(patientToCreate);

            return StatusCode(201);

        }


    }
}