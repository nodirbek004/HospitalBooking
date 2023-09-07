using HospitalInformationSystem.Domain.Enums;

namespace HospitalInformationSystem.Service.DTOs.Patients;

public class PatientResultDTO
{
    public long  Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string TelNumber { get; set; }
    public Gender gender { get; set; }
}
