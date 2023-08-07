using HospitalInformationSystem.Service.DTOs.Appointments;
using HospitalInformationSystem.Service.Helpers;

namespace HospitalInformationSystem.Service.Interfaces;
public interface IAppointmentService
{
    Task<Responce<AppointmentResultDTO>> CreateAsync(AppointmentCreationDTO dto);
    Task<Responce<AppointmentResultDTO>> UpdateAsync(AppointmentUpdateDTO dto);
    Task<Responce<AppointmentResultDTO>> GetByIdAsync(long id);
    Task<Responce<bool>> DeleteAsync(long id);
    Task<Responce<IEnumerable<AppointmentResultDTO>>> GetAllAsync();
    Task<Responce<IEnumerable<AppointmentResultDTO>>> GetBySpecifyingDate(DateTime date);
}

