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
    public class OutlayMaterialsController : ControllerBase
    {
        IOutlayMaterialService service;
        public OutlayMaterialsController(IOutlayMaterialService service)
        {
            this.service = service;
        }

        [HttpGet("objectid={objectId}")]
        public async Task<ActionResult<List<OutlayMaterialModel>>> GetAllByObjectId(int objectId)
        {
            return Ok(await service.GetAllByObjectIdAsync(objectId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(OutlayMaterialModel model)
        {
           
            return Ok(await service.CreateAsync(model));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }
    }
}
