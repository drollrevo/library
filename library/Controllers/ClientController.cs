using Microsoft.AspNetCore.Mvc;
using Library.Domain.DataTransferObject;
using Library.BLL.interfaces;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientServices;

        public ClientController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
        {
            try
            {
                return Ok(await _clientServices.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<ClientDto>>> Get(int Id)
        {
            try
            {
                return Ok(await _clientServices.GetAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> Post([FromBody] ClientDto value)
        {
            try
            {
                return Ok(await _clientServices.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<ClientDto>> Put(int Id, [FromBody] ClientDto value)
        {
            if (Id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _clientServices.UpdateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ClientDto>> DeleteAsync(int Id)
        {
            try
            {
                return Ok(await _clientServices.DeleteAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    } }
