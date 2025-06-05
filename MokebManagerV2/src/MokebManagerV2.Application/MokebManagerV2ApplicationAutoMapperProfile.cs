using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using MokebManagerV2.Dtos;
using MokebManagerV2.Models;

namespace MokebManagerV2;

public class MokebManagerV2ApplicationAutoMapperProfile : Profile
{
    public MokebManagerV2ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */


        CreateMap<CreateUpdateMokebDto, Mokeb>()
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
            .ForMember(dest => dest.Capacity, act => act.MapFrom(src => src.Capacity))
            .ForMember(dest => dest.Sex, act => act.MapFrom(src => src.Sex))
            .MapExtraProperties()
            .ReverseMap();

        CreateMap<CreateUpdateMokebDto, MokebDto>()
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
            .ForMember(dest => dest.Capacity, act => act.MapFrom(src => src.Capacity))
            .ForMember(dest => dest.Sex, act => act.MapFrom(src => src.Sex))
            .ForMember(dest => dest.TenantId, act => act.MapFrom(src => src.TenantId))
            .MapExtraProperties()
            .ReverseMap();


        CreateMap<MokebDto, Mokeb>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
            .ForMember(dest => dest.Capacity, act => act.MapFrom(src => src.Capacity))
            .ForMember(dest => dest.Sex, act => act.MapFrom(src => src.Sex))
            .ForMember(dest => dest.Pilgrims, act => act.Ignore())
            .MapExtraProperties()
            .ReverseMap();

    }
}
