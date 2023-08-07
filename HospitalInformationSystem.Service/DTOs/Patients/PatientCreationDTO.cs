using HospitalInformationSystem.Domain.Enums;

namespace HospitalInformationSystem.Service.DTOs.Patients;

public class PatientCreationDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string TelNumber { get; set; }
    public Gender gender { get; set; }
}
