using HospitalInformationSystem.Service.DTOs.Doctors;
using HospitalInformationSystem.Service.DTOs.Patients;
using HospitalInformationSystem.Service.Helpers;

namespace HospitalInformationSystem.Service.Interfaces;

public interface IDoctorService
{
    Task<Responce<DoctorResultDTO>> CreateAsync(DoctorCreationDTO dto);
    Task<Responce<DoctorResultDTO>> UpdateAsync(DoctorUpdateDTO dto);
    Task<Responce<DoctorResultDTO>> GetByIdAsync(long id);
    Task<Responce<bool>> DeleteAsync(long id);
    Task<Responce<IEnumerable<DoctorResultDTO>>> GetAllAsync();
    Task<Responce<DoctorResultDTO>> GetByTelNumberAsync(string telNumber);
    Task<Responce<IEnumerable<DoctorResultDTO>>> SearchByName(string name);
}
