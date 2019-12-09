using System.Threading.Tasks;
using Med_Center_API.Models;

namespace Med_Center_API.Data
{
    public interface IPatientRepository
    {
         Task<Patient> AddPatient(Patient patient);
    }
}