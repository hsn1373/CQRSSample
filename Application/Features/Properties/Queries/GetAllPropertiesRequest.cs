using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Queries
{
    public class GetAllPropertiesRequest : IRequest<List<GetByIdResponse>>
    { }

    public class GetAllPropertiesRequestHandler : IRequestHandler<GetAllPropertiesRequest, List<GetByIdResponse>>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;

        public GetAllPropertiesRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<List<GetByIdResponse>> Handle(GetAllPropertiesRequest request, CancellationToken cancellationToken)
        {
            List<Property> properties = await _propertyRepo.GetAllAsync();
            List<GetByIdResponse> responses = new();
            if (properties.Any())
            {
                responses = _mapper.Map<List<GetByIdResponse>>(properties);
                return responses;
            }
            return null;
        }
    }
}
