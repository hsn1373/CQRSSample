
using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands
{
    public class CreatePropertyRequest : IRequest<bool>
    {
        public NewPropertyDto NewPropertyDto { get; set; }

        public CreatePropertyRequest(NewPropertyDto newPropertyDto)
        {
            NewPropertyDto = newPropertyDto;
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
            Property property = _mapper.Map<Property>(request.NewPropertyDto);
            property.ListDate = DateTime.Now;
            await _propertyRepo.AddNewAsync(property);
            return true;
        }
    }
}
