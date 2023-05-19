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
    public class PayoutsController : ControllerBase
    {
        IPayoutService service;
        public PayoutsController(IPayoutService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Create(PayoutModel model)
        {
            return Ok(await service.CreateAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetAsync(id));
        }

        [HttpGet("objectId={objectId}")]
        public async Task<ActionResult<List<PayoutModel>>> GetAllByObjectId(int objectId)
        {
            return Ok(await service.GetAllByObjectIdAsync(objectId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }
    }
}
