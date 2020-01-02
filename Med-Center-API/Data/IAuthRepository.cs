using System.Collections.Generic;
using System.Threading.Tasks;
using Med_Center_API.Models;

namespace Med_Center_API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);
         Task<User> getUser(string username);
         Task<User> getUserById(int id);
         Task<DoctorService> getDoctoServiceById(int id);
         Task<DoctorService> AddDoctorService (DoctorService service);
         Task<IEnumerable<DoctorService>> getDoctorServices (string DoctorName);
         Task<IEnumerable<DoctorService>> GetAllDoctorServices();
         Task<bool> SaveAll();
    }
}