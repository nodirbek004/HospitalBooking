using HospitalInformationSystem.Data.DbContexts;
using HospitalInformationSystem.Data.IRepositories.Commons;
using HospitalInformationSystem.Data.Repositories.Commons;
using HospitalInformationSystem.Domain.Entities.Doctors;
using HospitalInformationSystem.Service.Interfaces;
using HospitalInformationSystem.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("PostgresqlConnection")
    ));

builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IRepository<DoctorEntity>, Repository<DoctorEntity>>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IMedicalRecordService, MedicalRecordService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
//comment