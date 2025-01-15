using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Queries
{
    public class GetPropertyByIdRequest : IRequest<GetByIdResponse>
    {
        public int PropertyId { get; set; }

        public GetPropertyByIdRequest(int propertyId)
        {
            PropertyId = propertyId;
        }
    }

    public class GetByIdPropertyRequestHandler : IRequestHandler<GetPropertyByIdRequest, GetByIdResponse>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;

        public GetByIdPropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<GetByIdResponse> Handle(GetPropertyByIdRequest request, CancellationToken cancellationToken)
        {
            Property property = await _propertyRepo.GetByIdAsync(request.PropertyId);
            GetByIdResponse response = new();
            if (property != null)
            {
                _mapper.Map(property, response);
                return response;
            }
            return null;
        }
    }
}
