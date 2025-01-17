using Application.Features.Properties.Commands;
using Application.Features.Properties.Queries;
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
        public async Task<IActionResult> AddNewProperty([FromBody] NewPropertyDto newPropertyDto)
        {
            bool res = await _mediatrSender.Send(new CreatePropertyRequest(newPropertyDto));
            if (res)
                return Ok("Property Created");
            return BadRequest("Faild");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyDto updatePropertyDto)
        {
            bool res = await _mediatrSender.Send(new UpdatePropertyRequest(updatePropertyDto));
            if (res)
                return Ok("Property Updated");
            return NotFound("Property Not Found");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPropertyById(int Id)
        {
            GetPropertyByIdResponse response = await _mediatrSender.Send(new GetPropertyByIdRequest(Id));
            if (response != null)
                return Ok(response);
            return NotFound("Property Not Found");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllProperties()
        {
            List<GetPropertyByIdResponse> responses = await _mediatrSender.Send(new GetAllPropertiesRequest());
            return Ok(responses);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            bool res = await _mediatrSender.Send(new DeletePropertyRequest(Id));
            if (res)
                return Ok("Property Deleted");
            return NotFound("Property Not Found");
        }
    }
}
