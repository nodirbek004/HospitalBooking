using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Domain.Entities.Patients;

namespace HospitalInformationSystem.Data.IRepositories;

public interface IPatientRepository : IRepository<PatientEntity>
{
    Task<PatientEntity> GetByTelNumber(string telNumber);
    IQueryable<PatientEntity> SearchByName(string name);
}
