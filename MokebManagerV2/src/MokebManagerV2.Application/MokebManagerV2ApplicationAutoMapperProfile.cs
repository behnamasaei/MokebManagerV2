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
            .ReverseMap();
        CreateMap<MokebDto, Mokeb>()
            .ReverseMap();

    }
}
