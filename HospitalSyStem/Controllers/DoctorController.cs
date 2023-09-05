using HospitalInformationSystem.Service.DTOs.Doctors;
using HospitalInformationSystem.Service.Helpers;
using HospitalInformationSystem.Service.Interfaces;
using HospitalInformationSystem.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSyStem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;
        public DoctorController(IDoctorService doctorService)
        {

            this.doctorService = doctorService;
        }
        [HttpGet("DoctorGetAll")]
        public async Task<Responce<IEnumerable<DoctorResultDTO>>> DoctorGetAll()
        {

            var GetDoctor = await doctorService.GetAllAsync();
            
            return GetDoctor;
        }
        [HttpPost("CreateDoctor")]
        public async Task<Responce<DoctorResultDTO>> Create([FromForm] DoctorCreationDTO doctorCreationDTO)
        {
            var GetDoctor = await doctorService.CreateAsync(doctorCreationDTO);
            return GetDoctor;
        }
        }
}

