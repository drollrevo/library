using Microsoft.AspNetCore.Mvc;
using Library.Domain.DataTransferObject;
using Library.BLL.Interfaces;
using Library.BLL.interfaces;

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientServices
    }
}
