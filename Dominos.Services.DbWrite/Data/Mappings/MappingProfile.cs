using AutoMapper;
using Dominos.Services.DbWrite.Data.Dtos;
using Dominos.Services.DbWrite.Entities;

namespace Dominos.Services.DbWrite.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}
