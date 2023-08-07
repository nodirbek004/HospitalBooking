using AutoMapper;
using HospitalInformationSystem.Domain.Entities.Appointments;
using HospitalInformationSystem.Domain.Entities.Doctors;
using HospitalInformationSystem.Domain.Entities.MedicalRecords;
using HospitalInformationSystem.Domain.Entities.Patients;
using HospitalInformationSystem.Service.DTOs.Appointments;
using HospitalInformationSystem.Service.DTOs.Doctors;
using HospitalInformationSystem.Service.DTOs.MedicalRecords;
using HospitalInformationSystem.Service.DTOs.Patients;

namespace HospitalInformationSystem.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        // Patient
        CreateMap<PatientEntity, PatientResultDTO>().ReverseMap();
        CreateMap<PatientEntity, PatientCreationDTO>().ReverseMap();
        CreateMap<PatientEntity, PatientUpdateDTO>().ReverseMap();

        // Doctor
        CreateMap<DoctorEntity, DoctorResultDTO>().ReverseMap();    
        CreateMap<DoctorEntity, DoctorCreationDTO>().ReverseMap();
        CreateMap<DoctorEntity, DoctorUpdateDTO>().ReverseMap();

        // Appointment
        CreateMap<AppointmentEntity, AppointmentResultDTO>().ReverseMap();
        CreateMap<AppointmentEntity, AppointmentCreationDTO>().ReverseMap();
        CreateMap<AppointmentEntity, AppointmentUpdateDTO>().ReverseMap();

        // MedicalRecord
        CreateMap<MedicalRecordEntity, MedicalRecordResultDTO>().ReverseMap();
        CreateMap<MedicalRecordEntity, MedicalRecordCreationDTO>().ReverseMap();
        CreateMap<MedicalRecordEntity, MedicalRecordUpdateDTO>().ReverseMap();
    }
}
