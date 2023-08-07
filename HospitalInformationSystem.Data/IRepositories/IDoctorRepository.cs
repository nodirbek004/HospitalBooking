using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Domain.Entities.Doctors;
using HospitalInformationSystem.Domain.Entities.Patients;

namespace HospitalInformationSystem.Data.IRepositories;

public interface IDoctorRepository : IRepository<DoctorEntity>
{
    Task<DoctorEntity> GetByTelNumberAsync(string telNumber);
    IQueryable<DoctorEntity> SearchByName(string name);
}
