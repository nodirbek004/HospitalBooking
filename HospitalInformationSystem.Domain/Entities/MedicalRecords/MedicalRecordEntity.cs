using HospitalInformationSystem.Domain.Commons;
using HospitalInformationSystem.Domain.Entities.Patients;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalInformationSystem.Domain.Entities.MedicalRecords;

[Table("MedicalRecords")]
public class MedicalRecordEntity : Auditable
{
    public string MedicalConditions { get; set; }
    public string Medications { get; set; }
    public string TestResults { get; set; }
    public string TreatmentPlans { get; set; }
    public long PatientId { get; set; }
    public PatientEntity Patient { get; set; }
}