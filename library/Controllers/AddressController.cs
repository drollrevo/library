using Microsoft.AspNetCore.Mvc;
using Library.Domain.DataTransferObject;
using Library.BLL.interfaces;


namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    { 
        private readonly IAddressServices _addressServices;

        public AddressController(IAddressServices addressServices)
        {
            _addressServices = addressServices;
        }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressDto>>> Get()
    {
        try
        {
            return Ok(await _addressServices.GetAsync());
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<IEnumerable<AddressDto>>> Get(int Id)
    {
        try
        {
            return Ok(await _addressServices.GetAsync(Id));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<ActionResult<AddressDto>> Post([FromBody] AddressDto value)
    {
        try
        {
            return Ok(await _addressServices.CreateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
    [HttpPut("{Id}")]
    public async Task<ActionResult<AddressDto>> Put(int Id, [FromBody] AddressDto value)
    {
        if (Id != value.Id)
            return BadRequest();

        try
        {
            return Ok(await _addressServices.UpdateAsync(value));
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<AddressDto>> DeleteAsync(int Id)
        {
            try
            {
                return Ok(await _addressServices.DeleteAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

       
}
}
