using HospitalInformationSystem.Domain.Commons;
using HospitalInformationSystem.Domain.Entities.Doctors;
using HospitalInformationSystem.Domain.Entities.Patients;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalInformationSystem.Domain.Entities.Appointments;

[Table("Appointments")]
public class AppointmentEntity : Auditable
{
    public PatientEntity Patient { get; set; }
    public long DoctorId { get; set; }
    public DoctorEntity Doctor { get; set; }
    public object SpecifyingDate { get; set; }
}
