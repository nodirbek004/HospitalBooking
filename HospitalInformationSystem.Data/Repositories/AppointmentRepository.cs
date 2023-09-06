using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.Appointments;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Data.Repositories;

public class AppointmentRepository : Repository<AppointmentEntity>, IAppointmentRepository
{
    private readonly AppDbContext appDbContext;

    public AppointmentRepository(DbContextOptions<AppDbContext> options)
    {
        this.appDbContext = new AppDbContext(options);
    }
    public IQueryable<AppointmentEntity> GetBySpecifyingDate(DateTime date)
        => appDbContext.Appointments.Where(a => a.SpecifyingDate.Equals(date));
}
