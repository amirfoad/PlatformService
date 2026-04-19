using AutoMapper;
using PlatformService.Models;

namespace PlatformService.Dtos.Profiles
{
    public class PlatformProfile:Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformReadDto>()
                .ConstructUsing(src => new PlatformReadDto(src.Id,
                src.Name,
                src.Publisher,
                src.Cost))
                .ReverseMap();

            CreateMap<Platform, PlatformCreateDto>()
                .ConstructUsing(src => new PlatformCreateDto(src.Name,
                src.Publisher,
                src.Cost))
                .ReverseMap();
        }
    }
}
