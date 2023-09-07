using HospitalInformationSystem.Domain.Entities.Doctors;
using HospitalInformationSystem.Domain.Entities.Patients;

namespace HospitalInformationSystem.Service.DTOs.Appointments;

public class AppointmentCreationDTO
{
    public DateTime SpecifyingDate { get; set; } = DateTime.UtcNow;
    public string Time { get; set; }
    public long PatientId { get; set; }
    public long DoctorId { get; set; }

}
