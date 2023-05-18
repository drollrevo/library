using Microsoft.AspNetCore.Mvc;
using Library.Domain.DataTransferObject;
using Library.BLL.interfaces;
using System;
using Microsoft.AspNetCore.Http.HttpResults;


namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookOrderController : ControllerBase
    {
        private readonly IBookOrderServices _bookOrderServices;

        public BookOrderController(IBookOrderServices bookOrderServices)
        {
            _bookOrderServices = bookOrderServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookOrderDto>>> Get()
        {
            try
            {
                return Ok(await _bookOrderServices.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<BookOrderDto>>> Get(int Id)
        {
            try
            {
                return Ok(await _bookOrderServices.GetAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookOrderDto>> Post([FromBody] BookOrderDto value)
        {
            try
            {
                return Ok(await _bookOrderServices.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<BookOrderDto>> Put(int Id, [FromBody] BookOrderDto value)
        {
            if (Id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _bookOrderServices.UpdateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<BookOrderDto>> DeleteAsync(int Id)
        {
            try
            {
                return Ok(await _bookOrderServices.DeleteAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    } }
