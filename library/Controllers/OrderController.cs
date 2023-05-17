using Library.BLL.interfaces;
using Library.Domain.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
    {
        try
        {
            return Ok(await _orderServices.GetAsync());
        }
        catch (Exception ex)
        {
            return BadRequestObjectResult();
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> Get(int Id)
    {
        try
        {
            return Ok(await _orderServices.GetAsync(Id));
        }
        catch (Exception ex)
        {
            return BadRequestObjectResult();
        }
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> Post([FromBody])
    {
        try
        {
            return Ok(await _orderServices.CreateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpPut("{Id}")]
    public async Task<ActionResult<OrderDto>> Put(int Id, [FromBody] OrderDto value)
    {
        if (Id != value.Id)
            return BadRequest();

        try
        {
            return Ok(await _orderServices.UpdateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpDelete("{Id}")]
    public async Task<ActionResult<OrderDto>> DeleteAsync(int Id)
    {
        try
        {
            return Ok(await _orderServices.DeleteAsync(Id));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpPost("AddTo")]
    public async Task<ActionResult<OrderDto>> AddTo(AuthorToAddress value)
    {
        try
        {
            return Ok(await _orderServices.UpdateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
}
