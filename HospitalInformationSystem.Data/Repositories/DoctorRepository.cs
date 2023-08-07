using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.Doctors;
using HospitalInformationSystem.Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Data.Repositories;

public class DoctorRepository : Repository<DoctorEntity>, IDoctorRepository
{
    AppDbContext appDbContext;

    public DoctorRepository()
    {
        this.appDbContext = new AppDbContext();
    }

    public async Task<DoctorEntity> GetByTelNumberAsync(string telNumber)
        => await appDbContext.Doctors.FirstOrDefaultAsync(t => t.TelNumber.Equals(telNumber));

    public IQueryable<DoctorEntity> SearchByName(string name)
        => appDbContext.Doctors.Where(p => p.FirstName.Contains(name)).AsQueryable();
}
