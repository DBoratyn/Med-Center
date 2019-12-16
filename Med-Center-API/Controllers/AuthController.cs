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

        [HttpGet("getUser/{name}")]
        public async Task<IActionResult> getUser(string name)
        {
            var data = await _repo.getUser(name);
            return Ok(data);
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
                Price = serviceToAddDto.Price
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