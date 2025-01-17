using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Queries
{
    public class GetImageByIdRequest : IRequest<GetImageByIdResponse>
    {
        public int ImageId { get; set; }

        public GetImageByIdRequest(int imageId)
        {
            ImageId = imageId;
        }
    }

    public class GetImageByIdRequestHandler : IRequestHandler<GetImageByIdRequest, GetImageByIdResponse>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public GetImageByIdRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }

        public async Task<GetImageByIdResponse> Handle(GetImageByIdRequest request, CancellationToken cancellationToken)
        {
            Image image = await _imageRepo.GetByIdAsync(request.ImageId);
            GetImageByIdResponse response = new();
            if (image != null)
            {
                _mapper.Map(image, response);
                return response;
            }
            return null;
        }
    }
}
