using HospitalInformationSystem.Domain.Entities.Doctors;
using HospitalInformationSystem.Domain.Entities.Patients;

namespace HospitalInformationSystem.Service.DTOs.Appointments;

public class AppointmentResultDTO
{
    public long Id { get; set; }
    public DateTime SpecifyingDate { get; set; }
    public TimeSpan Time { get; set; }
    public long PatientId { get; set; }
    public PatientEntity Patient { get; set; }
    public long DoctorId { get; set; }
    public DoctorEntity Doctor { get; set; }
}
