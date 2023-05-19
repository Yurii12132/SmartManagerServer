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
    public class OutlayEmployeesController : ControllerBase
    {
        IOutlayEmployeeService service;
        public OutlayEmployeesController(IOutlayEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("objectId={objectId}")]
        public async Task<ActionResult> GetAllByObjectId(int objectId)
        {
            return Ok(await service.GetAllByObjectIdAsync(objectId));
        }

        [HttpGet("getEmployee/employeeId={employeeId}/objectId={objectId}")]
        public async Task<ActionResult> GetByEmployeeId(int employeeId, int objectId)
        {
            return Ok(await service.GetByEmployeeId(employeeId, objectId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(OutlayEMployeeCreateFormModel model)
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
