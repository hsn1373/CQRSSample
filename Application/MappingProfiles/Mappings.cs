using Application.Models;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            #region Property
            CreateMap<NewPropertyDto, Property>();
            CreateMap<UpdatePropertyDto, Property>();
            CreateMap<Property, GetPropertyByIdResponse>();
            #endregion
            #region Image
            CreateMap<NewImageDto, Image>();
            CreateMap<UpdateImageDto, Image>();
            CreateMap<Image, GetImageByIdResponse>();
            #endregion
        }
    }
}
