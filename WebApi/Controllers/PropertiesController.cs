
using Application.Features.Properties.Commands;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        public PropertiesController(ISender mediatrSender)
        {
            _mediatrSender = mediatrSender;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewProperty([FromBody] NewPropertyRequest newPropertyRequest)
        {
            bool res = await _mediatrSender.Send(new CreatePropertyRequest(newPropertyRequest));
            if (res)
                return Ok("Property Created");
            return BadRequest("Faild");
        }
    }
}
