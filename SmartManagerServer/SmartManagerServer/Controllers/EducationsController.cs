using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartManagerServer.Domain.Contracts.Services;
using System.Threading.Tasks;

namespace SmartManagerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationService service;
        public EducationsController(IEducationService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllAsync());
        }
    }
}
