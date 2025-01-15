
using Application.Models;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<NewPropertyDto, Property>();
            CreateMap<UpdatePropertyDto, Property>();
            CreateMap<Property, GetByIdResponse>();
        }
    }
}
