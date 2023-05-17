using Microsoft.AspNetCore.Mvc;
using Library.Domain.DataTransferObject;
using Library.BLL.interfaces;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Library.Domain.Entities;

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
    {
        try
        {
            return Ok(await _employeeServices.GetAsync());
        }
        catch (Exception ex)
        {
            return BadRequestObjectResult();
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get(int Id)
    {
        try
        {
            return Ok(await _employeeServices.GetAsync(Id));
        }
        catch (Exception ex)
        {
            return BadRequestObjectResult();
        }
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Post([FromBody])
    {
        try
        {
            return Ok(await _employeeServices.CreateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpPut("{Id}")]
    public async Task<ActionResult<EmployeeDto>> Put(int Id, [FromBody] EmployeeDto value)
    {
        if (Id != value.Id)
            return BadRequest();

        try
        {
            return Ok(await _employeeServices.UpdateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpDelete("{Id}")]
    public async Task<ActionResult<EmployeeDto>> DeleteAsync(int Id)
    {
        try
        {
            return Ok(await _employeeServices.DeleteAsync(Id));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpPost("AddTo")]
    public async Task<ActionResult<EmployeeDto>> AddTo(AuthorToAddress value)
    {
        try
        {
            return Ok(await _employeeServices.UpdateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
}
