using HospitalInformationSystem.Service.DTOs.Appointments;
using HospitalInformationSystem.Service.Helpers;
using HospitalInformationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSyStem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
        [HttpPost("AppointmentCreate")]
        public async Task<Responce<AppointmentResultDTO>> CreateAsync([FromBody]AppointmentCreationDTO appointmentCreationDTO)
        {
            var Result = await appointmentService.CreateAsync(appointmentCreationDTO);
            return Result;
        }
        [HttpPost("AppointmentUpdate")]
        public async Task<Responce<AppointmentResultDTO>> UpdateAsync(AppointmentUpdateDTO appointmentUpdateDTO)
        {
            var Result = await appointmentService.UpdateAsync(appointmentUpdateDTO);
            return Result;
        }
        [HttpDelete("DeleteAppointment")]
        public async Task<Responce<bool>> DeleteAsync(long id)
        {
            var Result = await appointmentService.DeleteAsync(id);
            return Result;
        }
        [HttpGet("GetAllAppointment")]
        public async Task<Responce<IEnumerable<AppointmentResultDTO>>> GetAllAsync()
        {
            var Result = await appointmentService.GetAllAsync();
            return Result;
        }
        [HttpGet("GetByIdAppointment")]
        public async Task<Responce<AppointmentResultDTO>> GetByIdAsync(long id)
        {
            var Result = await appointmentService.GetByIdAsync(id);
            return Result;
        }
        [HttpGet("GetBySpecifyingDate")]
        public async Task<Responce<IEnumerable<AppointmentResultDTO>>> GetBySpecifyingDateAsync(DateTime dateTime)
        {
            var Result = await appointmentService.GetBySpecifyingDate(dateTime);
            return Result;
        }
    }
}
