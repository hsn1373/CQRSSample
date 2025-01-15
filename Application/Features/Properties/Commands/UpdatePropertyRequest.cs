using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Properties.Commands
{
    public class UpdatePropertyRequest : IRequest<bool>
    {
        public UpdatePropertyDto UpdatePropertyDto { get; set; }

        public UpdatePropertyRequest(UpdatePropertyDto updatePropertyDto)
        {
            UpdatePropertyDto = updatePropertyDto;
        }
    }

    public class UpdatePropertyRequestHandler : IRequestHandler<UpdatePropertyRequest, bool>
    {
        private readonly IPropertyRepo _propertyRepo;
        private readonly IMapper _mapper;

        public UpdatePropertyRequestHandler(IPropertyRepo propertyRepo,
            IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdatePropertyRequest request, CancellationToken cancellationToken)
        {
            Property property = await _propertyRepo.GetByIdAsync(request.UpdatePropertyDto.Id);
            if (property != null)
            {
                _mapper.Map(request.UpdatePropertyDto, property);
                await _propertyRepo.UpdateAsync(property);
                return true;
            }
            return false;
        }
    }
}
