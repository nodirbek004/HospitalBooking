using HospitalInformationSystem.Domain.Entities.Patients;

namespace HospitalInformationSystem.Service.DTOs.MedicalRecords;

public class MedicalRecordUpdateDTO
{
    public long Id { get; set; }
    public string MedicalConditions { get; set; }
    public string Medications { get; set; }
    public string TestResults { get; set; }
    public string TreatmentPlans { get; set; }
    public long PatientId { get; set; }
    public PatientEntity Patient { get; set; }
}
