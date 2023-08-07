namespace HospitalInformationSystem.Data.IRepositories.Commons;

public interface IUnitOfWork
{
    IAppointmentRepository AppointmentRepository { get; }
    IDoctorRepository DoctorRepository { get; }
    IMedicalRecordRepository MedicalRecordRepository { get; }
    IPatientRepository PatientRepository { get; }
    Task<int> SaveAsync();
}
