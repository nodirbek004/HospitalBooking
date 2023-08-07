using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.Appointments;

namespace HospitalInformationSystem.Data.Repositories;

public class AppointmentRepository : Repository<AppointmentEntity>, IAppointmentRepository
{
    private readonly AppDbContext appDbContext;

    public AppointmentRepository()
    {
        this.appDbContext = new AppDbContext();
    }
    public IQueryable<AppointmentEntity> GetBySpecifyingDate(DateTime date)
        => appDbContext.Appointments.Where(a => a.SpecifyingDate.Equals(date));
}
