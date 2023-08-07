using HospitalInformationSystem.Service.DTOs.Patients;
using HospitalInformationSystem.Service.Helpers;

namespace HospitalInformationSystem.Service.Interfaces;

public interface IPatientService
{
    Task<Responce<PatientResultDTO>> CreateAsync(PatientCreationDTO dto);
    Task<Responce<PatientResultDTO>> UpdateAsync(PatientUpdateDTO dto);
    Task<Responce<PatientResultDTO>> GetByIdAsync(long id);
    Task<Responce<bool>> DeleteAsync(long id);
    Task<Responce<IEnumerable<PatientResultDTO>>> GetAllAsync();
    Task<Responce<PatientResultDTO>> GetByTelNumberAsync(string telNumber);
    Task<Responce<IEnumerable<PatientResultDTO>>> SearchByName(string name);
}
