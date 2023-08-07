using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories;
using HospitalInformationSystem.Data.IRepositories.Commons;

namespace HospitalInformationSystem.Data.Repositories.Commons;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;

    public UnitOfWork() 
    { 
        appDbContext = new AppDbContext();
        AppointmentRepository = new AppointmentRepository();
        DoctorRepository = new DoctorRepository();
        MedicalRecordRepository = new MedicalRecordRepository();
        PatientRepository = new PatientRepository();
    }

    public IAppointmentRepository AppointmentRepository { get; }

    public IDoctorRepository DoctorRepository { get; }

    public IMedicalRecordRepository MedicalRecordRepository { get; }

    public IPatientRepository PatientRepository { get; }

    public async Task<int> SaveAsync()
        => await this.appDbContext.SaveChangesAsync();
    
}
