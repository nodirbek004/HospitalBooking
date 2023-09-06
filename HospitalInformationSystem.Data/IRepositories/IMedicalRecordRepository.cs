
using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Domain.Entities.MedicalRecords;

namespace HospitalInformationSystem.Data.IRepositories;

public interface IMedicalRecordRepository :IRepository<MedicalRecordEntity>
{
    IQueryable<MedicalRecordEntity> GetByPatientId(long id);
}
