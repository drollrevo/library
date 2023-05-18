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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorServices _authorServices;

        public AuthorController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            try
            {
                return Ok(await _authorServices.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get(int Id)
        {
            try
            {
                return Ok(await _authorServices.GetAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post([FromBody] AuthorDto value)
        {
            try
            {
                return Ok(await _authorServices.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<ClientDto>> Put(int Id, [FromBody] AuthorDto value)
        {
            if (Id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _authorServices.UpdateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<AuthorDto>> DeleteAsync(int Id)
        {
            try
            {
                return Ok(await _authorServices.DeleteAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        
    }
}
