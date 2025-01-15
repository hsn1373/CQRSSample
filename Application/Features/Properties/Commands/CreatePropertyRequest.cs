
using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands
{
    public class CreatePropertyRequest : IRequest<bool>
    {
        public NewPropertyRequest PropertyRequest { get; set; }

        public CreatePropertyRequest(NewPropertyRequest newPropertyRequest)
        {
            PropertyRequest = newPropertyRequest;
        }
    }

    public class CreatePropertyRequestHandler : IRequestHandler<CreatePropertyRequest, bool>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;

        public CreatePropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreatePropertyRequest request, CancellationToken cancellationToken)
        {
            Property property = _mapper.Map<Property>(request.PropertyRequest);
            property.ListDate = DateTime.Now;
            await _propertyRepo.AddNewAsync(property);
            return true;
        }
    }
}
