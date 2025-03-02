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
         Task<Appointment> getAppointmentById(int id);
         Task<IEnumerable<Sickness>> getSicknessById(int id);
         Task<IEnumerable<Medicine>> getAppointedMedicineById(int id);
         Task<Sickness> getSingleSicknessById(int id);
         Task<Medicine> getSingleMedicineById(int id); 
         Task<Visit> getVisitById(int id);
         Task<DoctorService> AddDoctorService (DoctorService service);
         Task<Sickness> AddSickness (Sickness sickness);
         Task<Medicine> AddMedicine (Medicine medicine);
         Task<Visit> AddVisit (Visit visit); 
         Task<Appointment> AddAppointment (Appointment appointment);
         Task<IEnumerable<DoctorService>> getDoctorServices (string DoctorName);
         Task<IEnumerable<Appointment>> GetDoctorAppointments (string DoctorName);
         Task<IEnumerable<DoctorService>> GetAllDoctorServices();
         Task<IEnumerable<Appointment>> GetAllAppointments();         
         Task<IEnumerable<Appointment>> GetAllAppointmentsByPesel(string Pesel);         
         Task<bool> SaveAll();
         Task<Patient> getPatientById(int id);
    }
}