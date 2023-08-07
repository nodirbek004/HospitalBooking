using AutoMapper;
using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.MedicalRecords;
using HospitalInformationSystem.Domain.Entities.Patients;
using HospitalInformationSystem.Service.DTOs.MedicalRecords;
using HospitalInformationSystem.Service.DTOs.Patients;
using HospitalInformationSystem.Service.Helpers;
using HospitalInformationSystem.Service.Interfaces;
using HospitalInformationSystem.Service.Mappers;

namespace HospitalInformationSystem.Service.Services;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly IMapper mapper;

    private readonly IUnitOfWork unitOfWork;

    public MedicalRecordService()
    {
        this.unitOfWork = new UnitOfWork();

        this.mapper = new Mapper(new MapperConfiguration(
                cfg => cfg.AddProfile<MappingProfile>()
            ));
    }
    public async Task<Responce<MedicalRecordResultDTO>> CreateAsync(MedicalRecordCreationDTO dto)
    {
        var existPatient = await unitOfWork.PatientRepository.GetByIdAsync(dto.PatientId);

        if (existPatient is null)
            return new Responce<MedicalRecordResultDTO>
            {
                StatusCode = 404,
                Message = "This patientId not found!",
            };

        var mappedMedicalRecord = mapper.Map<MedicalRecordEntity>(dto);

        await unitOfWork.MedicalRecordRepository.CreateAsync(mappedMedicalRecord);
        var temp = await unitOfWork.MedicalRecordRepository.SaveAsync();

        var result = mapper.Map<MedicalRecordResultDTO>(mappedMedicalRecord);

        return new Responce<MedicalRecordResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<bool>> DeleteAsync(long id)
    {
        var existMedicalRecord = await unitOfWork.MedicalRecordRepository.GetByIdAsync(id);

        if (existMedicalRecord is null)
            return new Responce<bool>
            {
                StatusCode = 404,
                Message = "This medicalRecord not found!",
                Data = false
            };

        unitOfWork.MedicalRecordRepository.Delete(existMedicalRecord);
        await unitOfWork.MedicalRecordRepository.SaveAsync();

        return new Responce<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Responce<MedicalRecordResultDTO>> UpdateAsync(MedicalRecordUpdateDTO dto)
    {
        var existMedicalRecord = await unitOfWork.MedicalRecordRepository.GetByIdAsync(dto.Id);

        if (existMedicalRecord is null)
            return new Responce<MedicalRecordResultDTO>
            {
                StatusCode = 404,
                Message = "This medicalRecord not found!",
            };

        var mappedMedicalRecord = mapper.Map(dto, existMedicalRecord);

        var updateMedicalRecord = unitOfWork.MedicalRecordRepository.Update(mappedMedicalRecord);
        await unitOfWork.MedicalRecordRepository.SaveAsync();

        var result = mapper.Map<MedicalRecordResultDTO>(updateMedicalRecord);

        return new Responce<MedicalRecordResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<MedicalRecordResultDTO>>> GetAllAsync()
    {
        var medicalRecords = unitOfWork.MedicalRecordRepository.GetAll();

        List<MedicalRecordResultDTO> result = new List<MedicalRecordResultDTO>();

        foreach (var medicalRecord in medicalRecords)
        {
            result.Add(mapper.Map<MedicalRecordResultDTO>(medicalRecord));
        }

        return new Responce<IEnumerable<MedicalRecordResultDTO>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<MedicalRecordResultDTO>> GetByIdAsync(long id)
    {
        var existMedicalRecord = await unitOfWork.MedicalRecordRepository.GetByIdAsync(id);

        if (existMedicalRecord is null)
            return new Responce<MedicalRecordResultDTO>
            {
                StatusCode = 404,
                Message = "This medicalRecord not found!",
            };

        var result = mapper.Map<MedicalRecordResultDTO>(existMedicalRecord);

        return new Responce<MedicalRecordResultDTO>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<MedicalRecordResultDTO>>> GetByPatientId(long id)
    {
        var existMedicalRecord = unitOfWork.MedicalRecordRepository.GetByPatientId(id);

        if (existMedicalRecord is null)
            return new Responce<IEnumerable<MedicalRecordResultDTO>>
            {
                StatusCode = 404,
                Message = "Those medicalRecords not found!",
            };

        var result = new List<MedicalRecordResultDTO>();

        foreach(var item in existMedicalRecord)
        {
            result.Add(mapper.Map<MedicalRecordResultDTO>(item));
        }

        return new Responce<IEnumerable<MedicalRecordResultDTO>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
