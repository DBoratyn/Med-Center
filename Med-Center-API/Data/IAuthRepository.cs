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
         Task<bool> SaveAll();
    }
}