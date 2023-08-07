using HospitalInformationSystem.Domain.Enums;

namespace HospitalInformationSystem.Service.DTOs.Doctors;

public class DoctorResultDTO
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelNumber { get; set; }
    public Specialty Specialization { get; set; }
}
