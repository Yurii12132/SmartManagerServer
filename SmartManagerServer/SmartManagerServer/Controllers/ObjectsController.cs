using Microsoft.AspNetCore.Mvc;
using SmartManagerServer.Domain.Contracts.Services;
using SmartManagerServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManagerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectsController : ControllerBase
    {
        IObjectService service;
        public ObjectsController(IObjectService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ObjectModel>>> GetAllActive()
        {
            return Ok(await service.GetAllActiveAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetAsync(id));
        }

        [HttpGet("closed")]
        public async Task<ActionResult<List<ObjectModel>>> GetAllClosed()
        {
            return Ok(await service.GetAllClosedAsync());
        }

        [HttpGet("{id}/informations")]
        public async Task<ActionResult<ObjectInformationModel>> GetInformations(int id)
        {
            return Ok(await service.GetInformationAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(ObjectModel model)
        {
            return Ok(await service.CreateAsync(model));
        }

        [HttpDelete("closed/{id}")]
        public async Task<IActionResult> Clodes(int id)
        {
            await service.ClosedAsync(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ObjectModel objectModel)
        {
            await service.UpdateAsync(objectModel);
            return Ok();
        }

        [HttpPatch("information")]
        public async Task<IActionResult> UpdateInformation(ObjectInformationModel model)
        {
            await service.UpdateInformationAsync(model);
            return Ok();
        }

        [HttpGet("statistic/{id}")]
        public async Task<IActionResult> GetStatistic(int id)
        {
            return Ok(await service.GetStatisticAsync(id));
        }
    }
}
