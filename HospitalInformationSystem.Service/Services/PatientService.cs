using AutoMapper;
using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.Patients;
using HospitalInformationSystem.Service.DTOs.Patients;
using HospitalInformationSystem.Service.Helpers;
using HospitalInformationSystem.Service.Interfaces;
using HospitalInformationSystem.Service.Mappers;

namespace HospitalInformationSystem.Service.Services;

public class PatientService : IPatientService
{
    private readonly IMapper mapper;

    private readonly IUnitOfWork unitOfWork;

    public PatientService()
    {
        this.unitOfWork = new UnitOfWork();

        this.mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MappingProfile>() 
            ));
    }

    public async Task<Responce<PatientResultDTO>> CreateAsync(PatientCreationDTO dto)
    {
        var existPatient = await unitOfWork.PatientRepository.GetByTelNumber(dto.TelNumber);

        if (existPatient is not null)
            return new Responce<PatientResultDTO>
            {
                StatusCode = 403,
                Message = "This patient already exists!",
            };

        var mappedPatient = mapper.Map<PatientEntity>(dto);

        await unitOfWork.PatientRepository.CreateAsync(mappedPatient);
        var temp = await unitOfWork.PatientRepository.SaveAsync();

        var result = mapper.Map<PatientResultDTO>(mappedPatient);

        return new Responce<PatientResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<bool>> DeleteAsync(long id)
    {
        var existPatient = await unitOfWork.PatientRepository.GetByIdAsync(id);

        if (existPatient is null)
            return new Responce<bool>
            {
                StatusCode = 404,
                Message = "This patient not found!",
                Data = false
            };

        unitOfWork.PatientRepository.Delete(existPatient);
        await unitOfWork.PatientRepository.SaveAsync();

        return new Responce<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }
    
    public async Task<Responce<PatientResultDTO>> UpdateAsync(PatientUpdateDTO dto)
    {
        var existPatient = await unitOfWork.PatientRepository.GetByIdAsync(dto.Id);

        if (existPatient is null)
            return new Responce<PatientResultDTO>
            {
                StatusCode = 404,
                Message = "This patient not found!",
            };

        var mappedPatient = mapper.Map(dto, existPatient);

        var updatePatient = unitOfWork.PatientRepository.Update(mappedPatient);
        await unitOfWork.PatientRepository.SaveAsync();

        var result = mapper.Map<PatientResultDTO>(updatePatient);

        return new Responce<PatientResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<PatientResultDTO>>> GetAllAsync()
    {
        var patients = unitOfWork.PatientRepository.GetAll();

        List<PatientResultDTO> result= new List<PatientResultDTO>();

        foreach (var patient in patients)
        {
            result.Add(mapper.Map<PatientResultDTO>(patient));
        }

        return new Responce<IEnumerable<PatientResultDTO>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<PatientResultDTO>> GetByIdAsync(long id)
    {
        var existPatient = await unitOfWork.PatientRepository.GetByIdAsync(id);

        if (existPatient is null)
            return new Responce<PatientResultDTO>
            {
                StatusCode = 404,
                Message = "This patient not found!",
            };

        var result = mapper.Map<PatientResultDTO>(existPatient);

        return new Responce<PatientResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<PatientResultDTO>> GetByTelNumberAsync(string telNumber)
    {
        var existPatient = await unitOfWork.PatientRepository.GetByTelNumber(telNumber);

        if (existPatient is null)
            return new Responce<PatientResultDTO>
            {
                StatusCode = 404,
                Message = "This patient not found!",
            };

        var result = mapper.Map<PatientResultDTO>(existPatient);

        return new Responce<PatientResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<PatientResultDTO>>> SearchByName(string name)
    {
        var patients = unitOfWork.PatientRepository.SearchByName(name);

        var result = new List<PatientResultDTO>();

        foreach(var patient in patients)
        {
            result.Add(mapper.Map<PatientResultDTO>(patient));
        }

        return new Responce<IEnumerable<PatientResultDTO>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
