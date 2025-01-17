using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Commands
{
    public class UpdateImageRequest : IRequest<bool>
    {
        public UpdateImageDto UpdateImageDto { get; set; }

        public UpdateImageRequest(UpdateImageDto updateImageDto)
        {
            UpdateImageDto = updateImageDto;
        }
    }

    public class UpdateImageRequestHandler : IRequestHandler<UpdateImageRequest, bool>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public UpdateImageRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateImageRequest request, CancellationToken cancellationToken)
        {
            Image image = await _imageRepo.GetByIdAsync(request.UpdateImageDto.Id);
            if (image != null)
            {
                _mapper.Map(request.UpdateImageDto, image);
                await _imageRepo.UpdateAsync(image);
                return true;
            }
            return false;
        }
    }
}
