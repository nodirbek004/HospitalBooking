using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Data.Repositories;

public class PatientRepository : Repository<PatientEntity>, IPatientRepository
{

    public PatientRepository(AppDbContext appdb) :base(appdb)
    {
    }

    public async Task<PatientEntity> GetByTelNumber(string telNumber)
        => await appDbContext.Patients.FirstOrDefaultAsync(t => t.TelNumber.Equals(telNumber));

    public IQueryable<PatientEntity> SearchByName(string name)
        => appDbContext.Patients.Where(p => p.FirstName.Contains(name)).AsQueryable();
}
