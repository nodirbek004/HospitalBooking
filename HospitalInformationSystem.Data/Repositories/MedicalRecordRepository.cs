using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.MedicalRecords;

namespace HospitalInformationSystem.Data.Repositories;

public class MedicalRecordRepository : Repository<MedicalRecordEntity>, IMedicalRecordRepository
{
    private readonly AppDbContext appDbContext;

    public MedicalRecordRepository()
    {
        this.appDbContext = new AppDbContext();
    }
    public IQueryable<MedicalRecordEntity> GetByPatientId(long id)
        => appDbContext.MedicalRecords.Where(m => m.PatientId == id);
}
