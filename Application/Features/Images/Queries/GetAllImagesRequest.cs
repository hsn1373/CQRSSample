using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Images.Queries
{
    public class GetAllImagesRequest : IRequest<List<GetImageByIdResponse>>
    { }

    public class GetAllImagesRequestHandler : IRequestHandler<GetAllImagesRequest, List<GetImageByIdResponse>>
    {
        private readonly IImageRepo _imageRepo;
        private readonly IMapper _mapper;

        public GetAllImagesRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }

        public async Task<List<GetImageByIdResponse>> Handle(GetAllImagesRequest request, CancellationToken cancellationToken)
        {
            List<Image> images = await _imageRepo.GetAllAsync();
            List<GetImageByIdResponse> responses = new();
            if (images.Any())
            {
                responses = _mapper.Map<List<GetImageByIdResponse>>(images);
                return responses;
            }
            return null;
        }
    }
}
