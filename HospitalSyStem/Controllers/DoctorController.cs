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
        [HttpPut("UpdateDoctor")]
        public async Task<Responce<DoctorResultDTO>> Update([FromForm] DoctorUpdateDTO doctorUpdateDTO)
        {
            var GetDoctor=await doctorService.UpdateAsync(doctorUpdateDTO);
            return GetDoctor;

        }
        [HttpDelete("DoctorDelete")]
        public async Task<Responce<bool>> Delete([FromForm] long id)
        {
            var GetDoctor=await doctorService.DeleteAsync(id);
            return GetDoctor;
        }
        [HttpGet("GetByIdDoctor")]
        public async Task<Responce<DoctorResultDTO>> GetById([FromForm] long id)
        {
            var GetDoctor =await doctorService.GetByIdAsync(id);
            return GetDoctor;
        }

    }
}

