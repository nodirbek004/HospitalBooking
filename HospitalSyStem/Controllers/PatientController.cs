using HospitalInformationSystem.Service.DTOs.Patients;
using HospitalInformationSystem.Service.Helpers;
using HospitalInformationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace HospitalSyStem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }
        [HttpPost("CreatePatient")]
        public async Task<Responce<PatientResultDTO>> CreateAsync([FromForm] PatientCreationDTO patientCreationDTO)
        {
            var GetPatient = await patientService.CreateAsync(patientCreationDTO);
            return GetPatient;
        }
        [HttpPut("UpdatePatient")]
        public async Task<Responce<PatientResultDTO>> UpdateAsync([FromForm] PatientUpdateDTO patientUpdateDTO)
        {
            var Temp = await patientService.UpdateAsync(patientUpdateDTO);
            return Temp;
        }
        [HttpDelete("DeletePatient")]
        public async Task<Responce<bool>> DeleteAsync([FromForm] long id)
        {
            var Result = await patientService.DeleteAsync(id);
            return Result;
        }
        [HttpGet("GetAllPatient")]
        public async Task<Responce<IEnumerable<PatientResultDTO>>> GetAllAsync()
        {
            var Temp = await patientService.GetAllAsync();
            return Temp;
        }
        [HttpGet("GetByIdPatient")]
        public async Task<Responce<PatientResultDTO>> DetByIdAsync([FromForm]long id)
        {
            var Temp=await patientService.GetByIdAsync(id);
            return Temp;
        }
        [HttpGet("GetByNamePatient")]
        public async Task<Responce<IEnumerable<PatientResultDTO>>> GetByNameAsync([FromForm]string name)
        {
            var Temp=await patientService.SearchByName(name);
            return Temp;
        }
        [HttpGet("GetByTelNumberPatient")]
        public async Task<Responce<PatientResultDTO>> GetByNumberAsync([FromForm] string telNumber)
        {
            var Result=await patientService.GetByTelNumberAsync(telNumber);
            return Result;
        }
    }
}
