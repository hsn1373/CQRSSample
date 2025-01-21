using Application.Models;
using Application.PipelineBehaviours.Contracts;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Queries
{
    public class GetAllPropertiesRequest : IRequest<List<GetPropertyByIdResponse>>, ICacheable
    {
        public string CacheKey { get; set; }
        public bool BypassCache { get; set; }
        public TimeSpan SlidingExpiration { get; set; }

        public GetAllPropertiesRequest()
        {
            CacheKey = "GetAllProperties";
        }
    }

    public class GetAllPropertiesRequestHandler : IRequestHandler<GetAllPropertiesRequest, List<GetPropertyByIdResponse>>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;

        public GetAllPropertiesRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<List<GetPropertyByIdResponse>> Handle(GetAllPropertiesRequest request, CancellationToken cancellationToken)
        {
            List<Property> properties = await _propertyRepo.GetAllAsync();
            List<GetPropertyByIdResponse> responses = new();
            if (properties.Any())
            {
                responses = _mapper.Map<List<GetPropertyByIdResponse>>(properties);
                return responses;
            }
            return null;
        }
    }
}
