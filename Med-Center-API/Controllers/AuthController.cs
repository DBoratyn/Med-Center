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
using Microsoft.IdentityModel.Tokens;
using AutoMapper;

namespace Med_Center_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, DataContext context, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _context = context;
            _config = config;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username, userForLoginDto.Password);

            if (userFromRepo == null) {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username),
                new Claim(ClaimTypes.Role, userFromRepo.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok( new { 
                token = tokenHandler.WriteToken(token)
            });
        }

        [HttpGet("GetDoctorServices/{DoctorName}")]
        public async Task<IActionResult> GetDoctorServices(string DoctorName)
        {
            var data = await _repo.getDoctorServices(DoctorName);
            return Ok(data);
        }

        [HttpGet("GetDoctorAppointments/{DoctorName}")]
        public async Task<IActionResult> GetDoctorAppointments(string DoctorName)
        {
            var data = await _repo.GetDoctorAppointments(DoctorName);
            return Ok(data);
        }

        [HttpGet("GetAllDoctorServices")]
        public async Task<IActionResult> GetAllDoctorServices()
        {
            var data = await _repo.GetAllDoctorServices();
            return Ok(data);
        }

        [HttpGet("getAppointmentSickness/{AppointmentId}")]
        public async Task<IActionResult> GetAllSickness(int AppointmentId)
        {
            var data = await _repo.getSicknessById(AppointmentId);
            return Ok(data);
        }

        [HttpGet("getAppointmentVisit/{AppointmentId}")]
        public async Task<IActionResult> getAppointmentVisit(int AppointmentId)
        {
            var data = await _repo.getVisitById(AppointmentId);
            return Ok(data);
        }

        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult>GetAllAppointments() {
            var data = await _repo.GetAllAppointments();
            return Ok(data);
        }

        [HttpGet("GetAllAppointmentsByPesel/{Pesel}")]
        public async Task<IActionResult>GetAllAppointmentsByPesel(string Pesel) {
            var data = await _repo.GetAllAppointmentsByPesel(Pesel);
            return Ok(data);
        }

        [HttpGet("getUser/{name}")]
        public async Task<IActionResult> getUser(string name)
        {
            var data = await _repo.getUser(name);
            return Ok(data);
        }

        [HttpPost("updatePatient")]
        public async Task<IActionResult> updatePatient([FromBody]PatientForUpdateDto patientForUpdate)
        {
            try {
                var patientFromRepo = await _repo.getPatientById(patientForUpdate.Id);

                _mapper.Map(patientForUpdate, patientFromRepo);

                await _repo.SaveAll();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return StatusCode(200);
        }

        [HttpPost("updateSickness")]
        public async Task<IActionResult> updateSickness([FromBody]SIcknessForUpdateDto sicknessForAddOrUpdateDto)
        {
            try {
                var sicknessFromRepo = await _repo.getSingleSicknessById(sicknessForAddOrUpdateDto.id);

                _mapper.Map(sicknessForAddOrUpdateDto, sicknessFromRepo);
                if (await _repo.SaveAll())
                {
                    return StatusCode(200);
                }
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return StatusCode(400);
        }

        [HttpPost("updateVisit")]
        public async Task<IActionResult> updateVisit([FromBody]VisitForUpdateDto visitForUpdateDto)
        {
            try {
                var visitFromRepo = await _repo.getVisitById(visitForUpdateDto.Id);

                _mapper.Map(visitForUpdateDto, visitFromRepo);

                await _repo.SaveAll();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return StatusCode(200);
        }

        [HttpPost("updateAppointment")]
        public async Task<IActionResult> updateAppointment([FromBody]AppointmentForUpdateDto appointmentForUpdate)
        {
            try
            {
                var appointmentFromRepo = await _repo.getAppointmentById(appointmentForUpdate.Id);

                _mapper.Map(appointmentForUpdate, appointmentFromRepo);

                if (await _repo.SaveAll())
                {
                    return StatusCode(200);
                }
            }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            return StatusCode(400);
        }
        
        [HttpPost("PayAppointment/{id}")]
        public async Task<IActionResult> PayAppointment(int id) {
            try
            {
                var appointmentFromRepo = await _repo.getAppointmentById(id);
                var appointmentForUpdate = appointmentFromRepo;

                if (appointmentFromRepo.paid == true) {
                    appointmentForUpdate.paid = false;
                } else {
                appointmentForUpdate.paid = true;
                }

                _mapper.Map(appointmentForUpdate, appointmentFromRepo);

                if (await _repo.SaveAll())
                {
                    return StatusCode(200);
                }
            }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            return StatusCode(400);
        }

        [HttpPost("updateDoctorService")]
        public async Task<IActionResult> updateDoctorService([FromBody]DoctorServiceForUpdateDto doctorServiceForUpdate)
        {
            try
            {
                var serviceFromRepo = await _repo.getDoctoServiceById(doctorServiceForUpdate.id);

                _mapper.Map(doctorServiceForUpdate, serviceFromRepo);

                if (await _repo.SaveAll())
                {
                    return StatusCode(200);
                }
            }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            return StatusCode(400);
        }

        [HttpPost("updateUser")]
        public async Task<IActionResult> updateUser([FromBody]UserForUpdateDto userForUpdate)
        {
            try
            {
                var userFromRepo =  await _repo.getUser(userForUpdate.Username);

                _mapper.Map(userForUpdate, userFromRepo);

                if (await _repo.SaveAll())
                {
                    return StatusCode(200);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return StatusCode(400);
        }

        [HttpDelete("remove/{username}")]
        public async Task<IActionResult> Remove(string username)
        {
            var userFromRepo = await _repo.getUser(username);

            _context.Users.Remove(userFromRepo);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpPost("DeleteAppointment/{id}")]
        public async Task<IActionResult> DeleteAppointment(int id){
            var serviceFromRepo = await _repo.getAppointmentById(id);
            
            _context.Appointments.Remove(serviceFromRepo);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost("DeleteSickness/{id}")]
        public async Task<IActionResult> DeleteSickness(int id){
            var serviceFromRepo = await _repo.getSingleSicknessById(id);
            
            _context.Sicknesses.Remove(serviceFromRepo);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost("DeletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(int id){
            var patientFromRepo = await _repo.getPatientById(id);
            
            _context.Patients.Remove(patientFromRepo);
            await _context.SaveChangesAsync();
            return Ok(true);
        }


        [HttpPost("DeleteDoctorService/{id}")]
        public async Task<IActionResult> DeleteDoctorService(int id)
        {
            var serviceFromRepo = await _repo.getDoctoServiceById(id);
            
            _context.DoctorServices.Remove(serviceFromRepo);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddAppointment([FromBody]AppointmentToAddDto appointmentToAddDto) {
             
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appointmentToCreate = new Appointment
            {
                startDate = appointmentToAddDto.startDate,
                endDate = appointmentToAddDto.endDate,
                allDay = appointmentToAddDto.allDay,
                text = appointmentToAddDto.text,
                description = appointmentToAddDto.description,
                patientName = appointmentToAddDto.patientName,
                patientSurname = appointmentToAddDto.patientSurname,
                patientaddress = appointmentToAddDto.patientaddress,
                patientpesel = appointmentToAddDto.patientpesel,
                specialization = appointmentToAddDto.specialization,
                NameOfTreatment = appointmentToAddDto.NameOfTreatment,
                doctor = appointmentToAddDto.doctor,
                price = appointmentToAddDto.price,
                paid = appointmentToAddDto.paid
            };

            await _repo.AddAppointment(appointmentToCreate);

            return StatusCode(201);
        }

        [HttpPost("AddSickness/{AppointmentId}")]
        public async Task<IActionResult> AddSickness([FromBody]SicknessForAddOrUpdateDto sicknessForAddOrUpdateDto, int AppointmentId) {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceToCreate = new Sickness
            {
                sicknessName = sicknessForAddOrUpdateDto.sicknessName,
                sicknessDescription = sicknessForAddOrUpdateDto.sicknessDescription,
                cured = sicknessForAddOrUpdateDto.cured,
                appointmentId = AppointmentId
            };

            await _repo.AddSickness(serviceToCreate);

            return StatusCode(201);
        }

        [HttpPost("AddVisitInfo/{AppointmentId}")]
        public async Task<IActionResult> AddVisitInfo([FromBody]VisitForAddOrUpdateDto visitForAddOrUpdateDto, int AppointmentId) {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceToCreate = new Visit
            {
                dateOfVisit = visitForAddOrUpdateDto.dateOfVisit,
                descriptionOfVisit = visitForAddOrUpdateDto.descriptionOfVisit,
                appointmentId = AppointmentId
            };

            await _repo.AddVisit(serviceToCreate);

            return StatusCode(201);
        }

        [HttpPost("DeleteVisit/{id}")]
        public async Task<IActionResult> DeleteVisit(int id){
            var patientFromRepo = await _repo.getVisitById(id);
            
            _context.Visits.Remove(patientFromRepo);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost("AddDoctorService")]
        public async Task<IActionResult> AddDoctorService([FromBody]DoctorServiceToAddDto serviceToAddDto) {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceToCreate = new DoctorService
            {
                NameOfTreatment = serviceToAddDto.NameOfTreatment,
                Specialization = serviceToAddDto.Specialization,
                Price = serviceToAddDto.Price,
                DoctorName = serviceToAddDto.DoctorName
            };

            await _repo.AddDoctorService(serviceToCreate);

            return StatusCode(201);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();
            
            if (await _repo.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
                Role = userForRegisterDto.Role,
                Profession = userForRegisterDto.Profession,
                Pesel = userForRegisterDto.Pesel,
                Name = userForRegisterDto.Name,
                SecondName = userForRegisterDto.SecondName,
                Surname = userForRegisterDto.Surname,
                DateOfBirth = userForRegisterDto.DateOfBirth,
                PlaceOfBirth = userForRegisterDto.PlaceOfBirth,
                City = userForRegisterDto.City,
                Street = userForRegisterDto.Street,
                HouseNumber = userForRegisterDto.HouseNumber,
                ZipCode = userForRegisterDto.ZipCode
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}