using AutoMapper;
using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.Appointments;
using HospitalInformationSystem.Domain.Entities.Patients;
using HospitalInformationSystem.Service.DTOs.Appointments;
using HospitalInformationSystem.Service.DTOs.MedicalRecords;
using HospitalInformationSystem.Service.DTOs.Patients;
using HospitalInformationSystem.Service.Helpers;
using HospitalInformationSystem.Service.Interfaces;
using HospitalInformationSystem.Service.Mappers;

namespace HospitalInformationSystem.Service.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IMapper mapper;

    private readonly IUnitOfWork unitOfWork;

    public AppointmentService(AppDbContext dbContext)
    {
        this.unitOfWork = new UnitOfWork(dbContext);

        this.mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MappingProfile>()
            ));
    }
    public async Task<Responce<AppointmentResultDTO>> CreateAsync(AppointmentCreationDTO dto)
    {
        var existPatient = await unitOfWork.PatientRepository.GetByIdAsync(dto.PatientId);
        var existDoctor = await unitOfWork.DoctorRepository.GetByIdAsync(dto.DoctorId);

        if (existPatient is null || existDoctor is null)
            return new Responce<AppointmentResultDTO>
            {
                StatusCode = 404,
                Message = "This patientId or doctorId not found!",
            };

        var mappedAppointment = mapper.Map<AppointmentEntity>(dto);

        await unitOfWork.AppointmentRepository.CreateAsync(mappedAppointment);
        var temp = await unitOfWork.AppointmentRepository.SaveAsync();

        var result = mapper.Map<AppointmentResultDTO>(mappedAppointment);

        return new Responce<AppointmentResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<bool>> DeleteAsync(long id)
    {
        var existAppointment = await unitOfWork.AppointmentRepository.GetByIdAsync(id);

        if (existAppointment is null)
            return new Responce<bool>
            {
                StatusCode = 404,
                Message = "This appointment not found!",
                Data = false
            };

        unitOfWork.AppointmentRepository.Delete(existAppointment);
        await unitOfWork.AppointmentRepository.SaveAsync();

        return new Responce<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Responce<AppointmentResultDTO>> UpdateAsync(AppointmentUpdateDTO dto)
    {
        var existAppointment = await unitOfWork.AppointmentRepository.GetByIdAsync(dto.Id);

        if (existAppointment is null)
            return new Responce<AppointmentResultDTO>
            {
                StatusCode = 404,
                Message = "This appointment not found!",
            };

        var mappedAppointment = mapper.Map(dto, existAppointment);

        var updateAppointment = unitOfWork.AppointmentRepository.Update(mappedAppointment);
        await unitOfWork.AppointmentRepository.SaveAsync();

        var result = mapper.Map<AppointmentResultDTO>(updateAppointment);

        return new Responce<AppointmentResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
    
    public async Task<Responce<IEnumerable<AppointmentResultDTO>>> GetAllAsync()
    {
        var appointments = unitOfWork.AppointmentRepository.GetAll();

        List<AppointmentResultDTO> result = new List<AppointmentResultDTO>();

        foreach (var appointment in appointments)
        {
            result.Add(mapper.Map<AppointmentResultDTO>(appointment));
        }

        return new Responce<IEnumerable<AppointmentResultDTO>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<AppointmentResultDTO>> GetByIdAsync(long id)
    {
        var existAppointment = await unitOfWork.AppointmentRepository.GetByIdAsync(id);

        if (existAppointment is null)
            return new Responce<AppointmentResultDTO>
            {
                StatusCode = 404,
                Message = "This appointment not found!",
            };

        var result = mapper.Map<AppointmentResultDTO>(existAppointment);

        return new Responce<AppointmentResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
        
    }

    public async Task<Responce<IEnumerable<AppointmentResultDTO>>> GetBySpecifyingDate(DateTime date)
    {
        var appointments = unitOfWork.AppointmentRepository.GetBySpecifyingDate(DateTime.UtcNow);

        if (appointments is null)
            return new Responce<IEnumerable<AppointmentResultDTO>>
            {
                StatusCode = 404,
                Message = "Those appointments not found!",
            };

        var result = new List<AppointmentResultDTO>();

        foreach (var appointment in appointments)
        {
            result.Add(mapper.Map<AppointmentResultDTO>(appointment));
        }

        return new Responce<IEnumerable<AppointmentResultDTO>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
