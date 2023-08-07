using HospitalInformationSystem.Domain.Commons;
using HospitalInformationSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalInformationSystem.Domain.Entities.Doctors;

[Table("Doctors")]
public class DoctorEntity : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelNumber { get; set; }
    public Specialty Specialization { get; set; }
}
