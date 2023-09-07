using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Domain.Entities.Appointments;

namespace HospitalInformationSystem.Data.IRepositories;

public interface IAppointmentRepository:IRepository<AppointmentEntity>
{
    IQueryable<AppointmentEntity> GetBySpecifyingDate(DateTime dateTime);
}
