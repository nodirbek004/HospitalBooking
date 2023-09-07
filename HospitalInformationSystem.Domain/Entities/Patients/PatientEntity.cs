using HospitalInformationSystem.Domain.Commons;
using HospitalInformationSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalInformationSystem.Domain.Entities.Patients;

[Table("Patients")]
public class PatientEntity : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string TelNumber { get; set; }
    public Gender gender { get; set; }
}
