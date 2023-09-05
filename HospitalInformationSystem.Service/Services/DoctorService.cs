using AutoMapper;
using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.Doctors;
using HospitalInformationSystem.Domain.Entities.Patients;
using HospitalInformationSystem.Service.DTOs.Doctors;
using HospitalInformationSystem.Service.DTOs.Patients;
using HospitalInformationSystem.Service.Helpers;
using HospitalInformationSystem.Service.Interfaces;
using HospitalInformationSystem.Service.Mappers;

namespace HospitalInformationSystem.Service.Services;

public class DoctorService : IDoctorService
{
    private readonly IMapper mapper;

    private readonly IUnitOfWork unitOfWork;

    public DoctorService()
    {
        this.unitOfWork = new UnitOfWork();

        this.mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MappingProfile>()
            ));
    }

    public async Task<Responce<DoctorResultDTO>> CreateAsync(DoctorCreationDTO dto)
    {
        var existDoctor = await unitOfWork.DoctorRepository.GetByTelNumberAsync(dto.TelNumber);

        if (existDoctor is not null)
            return new Responce<DoctorResultDTO>
            {
                StatusCode = 403,
                Message = "This doctor already exists!",
            };

        var mappedDoctor = mapper.Map<DoctorEntity>(dto);

        await unitOfWork.DoctorRepository.CreateAsync(mappedDoctor);
        var temp = await unitOfWork.DoctorRepository.SaveAsync();

        var result = mapper.Map<DoctorResultDTO>(mappedDoctor);

        return new Responce<DoctorResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<bool>> DeleteAsync(long id)
    {
        var existDoctor = await unitOfWork.DoctorRepository.GetByIdAsync(id);

        if (existDoctor is null)
            return new Responce<bool>
            {
                StatusCode = 404,
                Message = "This doctor not found!",
                Data = false
            };

        unitOfWork.DoctorRepository.Delete(existDoctor);
        await unitOfWork.DoctorRepository.SaveAsync();

        return new Responce<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Responce<DoctorResultDTO>> UpdateAsync(DoctorUpdateDTO dto)
    {
        var existDoctor = await unitOfWork.DoctorRepository.GetByIdAsync(dto.Id);

        if (existDoctor is null)
            return new Responce<DoctorResultDTO>
            {
                StatusCode = 404,
                Message = "This doctor not found!",
            };

        var mappedDoctor = mapper.Map(dto, existDoctor);

        var updateDoctor = unitOfWork.DoctorRepository.Update(mappedDoctor);
        await unitOfWork.DoctorRepository.SaveAsync();

        var result = mapper.Map<DoctorResultDTO>(updateDoctor);

        return new Responce<DoctorResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<DoctorResultDTO>>> GetAllAsync()
    {
        var doctors = unitOfWork.DoctorRepository.GetAll();

        List<DoctorResultDTO> result = new List<DoctorResultDTO>();

        foreach (var doctor in doctors)
        {
            result.Add(mapper.Map<DoctorResultDTO>(doctor));
        }
        
        var response = new Responce<IEnumerable<DoctorResultDTO>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
        if(response.Data == null)
        {
            response.StatusCode = 404;
            response.Message = "Not Found";
        }
        return response;        
    }

    public async Task<Responce<DoctorResultDTO>> GetByIdAsync(long id)
    {
        var existDoctor = await unitOfWork.DoctorRepository.GetByIdAsync(id);

        if (existDoctor is null)
            return new Responce<DoctorResultDTO>
            {
                StatusCode = 404,
                Message = "This doctor not found!",
            };

        var result = mapper.Map<DoctorResultDTO>(existDoctor);

        return new Responce<DoctorResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }


    public async Task<Responce<DoctorResultDTO>> GetByTelNumberAsync(string telNumber)
    {
        var existDoctor = await unitOfWork.DoctorRepository.GetByTelNumberAsync(telNumber);

        if (existDoctor is null)
            return new Responce<DoctorResultDTO>
            {
                StatusCode = 404,
                Message = "This doctor not found!",
            };

        var result = mapper.Map<DoctorResultDTO>(existDoctor);

        return new Responce<DoctorResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<DoctorResultDTO>>> SearchByName(string name)
    {
        var doctors = unitOfWork.DoctorRepository.SearchByName(name);

        var result = new List<DoctorResultDTO>();

        foreach (var doctor in doctors)
        {
            result.Add(mapper.Map<DoctorResultDTO>(doctor));
        }

        return new Responce<IEnumerable<DoctorResultDTO>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
