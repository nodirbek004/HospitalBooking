using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.MedicalRecords;

namespace HospitalInformationSystem.Data.Repositories;

public class MedicalRecordRepository : Repository<MedicalRecordEntity>, IMedicalRecordRepository
{

    public MedicalRecordRepository(AppDbContext options) : base(options)
    {
    }
    public IQueryable<MedicalRecordEntity> GetByPatientId(long id)
        => appDbContext.MedicalRecords.Where(m => m.PatientId == id);
}
