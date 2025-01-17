using Application.Features.Images.Commands;
using Application.Features.Images.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        public ImagesController(ISender mediatrSender)
        {
            _mediatrSender = mediatrSender;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewImage([FromBody] NewImageDto newImageDto)
        {
            bool res = await _mediatrSender.Send(new CreateImageRequest(newImageDto));
            if (res)
                return Ok("Image Created");
            return BadRequest("Faild");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateImage([FromBody] UpdateImageDto updateImageDto)
        {
            bool res = await _mediatrSender.Send(new UpdateImageRequest(updateImageDto));
            if (res)
                return Ok("Image Updated");
            return NotFound("Image Not Found");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetImageById(int Id)
        {
            GetImageByIdResponse response = await _mediatrSender.Send(new GetImageByIdRequest(Id));
            if (response != null)
                return Ok(response);
            return NotFound("Image Not Found");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllImages()
        {
            List<GetImageByIdResponse> responses = await _mediatrSender.Send(new GetAllImagesRequest());
            return Ok(responses);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            bool res = await _mediatrSender.Send(new DeleteImageRequest(Id));
            if (res)
                return Ok("Image Deleted");
            return NotFound("Image Not Found");
        }
    }
}
