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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService service;
        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> Get(int id)
        {
            return Ok(await service.GetAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeModel>>> GetAll()
        {
            return Ok(await service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeModel employeeModel)
        {
            return Ok(await service.CreateAsync(employeeModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeModel model)
        {
            await service.UpdateAsync(model);
            return Ok();
        }
    }
}
