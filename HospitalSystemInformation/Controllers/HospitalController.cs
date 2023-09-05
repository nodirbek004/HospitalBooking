using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalSystemInformationSystem.I
namespace HospitalSystemInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        public HospitalController(IDoctorService)
        {

        }
        [HttpGet("DoctorGetAll")]
        public async Task<IActionResult> GetAllDoctor()
        {

        }
        
    }
}
