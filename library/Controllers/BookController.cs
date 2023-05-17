using Microsoft.AspNetCore.Mvc;
using Library.Domain.DataTransferObject;
using Library.BLL.interfaces;
using System;
using Microsoft.AspNetCore.Http.HttpResults;

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;

        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> Get()
    {
        try
        {
            return Ok(await _bookServices.GetAsync());
        }
        catch (Exception ex)
        {
            return BadRequestObjectResult();
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<IEnumerable<BookDto>>> Get(int Id)
    {
        try
        {
            return Ok(await _bookServices.GetAsync(Id));
        }
        catch (Exception ex)
        {
            return BadRequestObjectResult();
        }
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> Post([FromBody])
    {
        try
        {
            return Ok(await _bookServices.CreateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpPut("{Id}")]
    public async Task<ActionResult<BookDto>> Put(int Id, [FromBody] BookDto value)
    {
        if (Id != value.Id)
            return BadRequest();

        try
        {
            return Ok(await _bookServices.UpdateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpDelete("{Id}")]
    public async Task<ActionResult<BookDto>> DeleteAsync(int Id)
    {
        try
        {
            return Ok(await _bookServices.DeleteAsync(Id));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpPost("AddTo")]
    public async Task<ActionResult<BookDto>> AddTo(AuthorToAddress value)
    {
        try
        {
            return Ok(await _bookServices.UpdateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
}
}
