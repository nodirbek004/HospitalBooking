//using HospitalInformationSystem.Data.Constants;
using HospitalInformationSystem.Domain.Entities.Appointments;
using HospitalInformationSystem.Domain.Entities.Doctors;
using HospitalInformationSystem.Domain.Entities.MedicalRecords;
using HospitalInformationSystem.Domain.Entities.Patients;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Data.DbContexts;

public class AppDbContext : DbContext
{


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);

    //    optionsBuilder.UseSqlServer(DatabasePath.ConnectionString);
    //}

    public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
    {
        
    }

    public DbSet<PatientEntity> Patients { get; set; }
    public DbSet<DoctorEntity> Doctors { get; set; }
    public DbSet<MedicalRecordEntity> MedicalRecords { get; set; }
    public DbSet<AppointmentEntity> Appointments { get; set; }
}

