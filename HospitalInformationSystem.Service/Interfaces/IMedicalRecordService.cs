using HospitalInformationSystem.Service.DTOs.MedicalRecords;
using HospitalInformationSystem.Service.Helpers;

namespace HospitalInformationSystem.Service.Interfaces;

public interface IMedicalRecordService
{
    Task<Responce<MedicalRecordResultDTO>> CreateAsync(MedicalRecordCreationDTO dto);
    Task<Responce<MedicalRecordResultDTO>> UpdateAsync(MedicalRecordUpdateDTO dto);
    Task<Responce<MedicalRecordResultDTO>> GetByIdAsync(long id);
    Task<Responce<bool>> DeleteAsync(long id);
    Task<Responce<IEnumerable<MedicalRecordResultDTO>>> GetAllAsync();
    Task<Responce<IEnumerable<MedicalRecordResultDTO>>> GetByPatientId(long id);
}
