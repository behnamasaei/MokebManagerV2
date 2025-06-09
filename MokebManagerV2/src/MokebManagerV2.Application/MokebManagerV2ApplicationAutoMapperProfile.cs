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

        CreateMap<Pilgrim, PilgrimDto>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.Barcode, act => act.MapFrom(src => src.Barcode))
            .ForMember(dest => dest.Bed, act => act.MapFrom(src => src.Bed))
            .ForMember(dest => dest.BedId, act => act.MapFrom(src => src.BedId))
            .ForMember(dest => dest.EntryDate, act => act.MapFrom(src => src.EntryDate))
            .ForMember(dest => dest.ExitDate, act => act.MapFrom(src => src.ExitDate))
            .ForMember(dest => dest.ForceExitDate, act => act.MapFrom(src => src.ForceExitDate))
            .ForMember(dest => dest.Traffic, act => act.MapFrom(src => src.Traffic))
            .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.FullName))
            .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.NationalCode, act => act.MapFrom(src => src.NationalCode))
            .ForMember(dest => dest.PassportNo, act => act.MapFrom(src => src.PassportNo))
            .ForMember(dest => dest.Sex, act => act.MapFrom(src => src.Sex))
            .ForMember(dest => dest.Mokeb, act => act.MapFrom(src => src.Mokeb))
            .ForMember(dest => dest.MokebId, act => act.MapFrom(src => src.MokebId))
            .ForMember(dest => dest.Image, act => act.MapFrom(src => src.Image))
            .ForMember(dest => dest.TenantId, act => act.MapFrom(src => src.TenantId))
            .ForMember(dest => dest.BedNumber, act => act.MapFrom(src => src.BedNumber))
            .ReverseMap()
            .MapExtraProperties();


        CreateMap<CreateUpdatePilgrimDto, PilgrimDto>()
            .ForMember(dest => dest.Barcode, act => act.MapFrom(src => src.Barcode))
            .ForMember(dest => dest.EntryDate, act => act.MapFrom(src => src.EntryDate))
            .ForMember(dest => dest.ExitDate, act => act.MapFrom(src => src.ExitDate))
            .ForMember(dest => dest.ForceExitDate, act => act.MapFrom(src => src.ForceExitDate))
            .ForMember(dest => dest.Traffic, act => act.MapFrom(src => src.Traffic))
            .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.FullName))
            .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.NationalCode, act => act.MapFrom(src => src.NationalCode))
            .ForMember(dest => dest.PassportNo, act => act.MapFrom(src => src.PassportNo))
            .ForMember(dest => dest.Sex, act => act.MapFrom(src => src.Sex))
            .ForMember(dest => dest.BedId, act => act.MapFrom(src => src.BedId))
            .ForMember(dest => dest.MokebId, act => act.MapFrom(src => src.MokebId))
            .ForMember(dest => dest.Image, act => act.MapFrom(src => src.Image))
            .ForMember(dest => dest.TenantId, act => act.MapFrom(src => src.TenantId))
            .ForMember(dest => dest.BedNumber, act => act.MapFrom(src => src.BedNumber))
            .ReverseMap()
            .MapExtraProperties();


        CreateMap<Pilgrim, CreateUpdatePilgrimDto>()
            .ForMember(dest => dest.Barcode, act => act.MapFrom(src => src.Barcode))
            .ForMember(dest => dest.EntryDate, act => act.MapFrom(src => src.EntryDate))
            .ForMember(dest => dest.ExitDate, act => act.MapFrom(src => src.ExitDate))
            .ForMember(dest => dest.ForceExitDate, act => act.MapFrom(src => src.ForceExitDate))
            .ForMember(dest => dest.Traffic, act => act.MapFrom(src => src.Traffic))
            .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.FullName))
            .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.NationalCode, act => act.MapFrom(src => src.NationalCode))
            .ForMember(dest => dest.PassportNo, act => act.MapFrom(src => src.PassportNo))
            .ForMember(dest => dest.Sex, act => act.MapFrom(src => src.Sex))
            .ForMember(dest => dest.BedId, act => act.MapFrom(src => src.BedId))
            .ForMember(dest => dest.MokebId, act => act.MapFrom(src => src.MokebId))
            .ForMember(dest => dest.Image, act => act.MapFrom(src => src.Image))
            .ForMember(dest => dest.TenantId, act => act.MapFrom(src => src.TenantId))
            .ForMember(dest => dest.BedNumber, act => act.MapFrom(src => src.BedNumber))
            .ReverseMap()
            .MapExtraProperties();


        CreateMap<Bed, BedDto>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.PilgrimId, act => act.MapFrom(src => src.PilgrimId))
            .ForMember(dest => dest.TenantId, act => act.MapFrom(src => src.TenantId))
            .ForMember(dest => dest.Mokeb, act => act.MapFrom(src => src.Mokeb))
            .ForMember(dest => dest.MokebId, act => act.MapFrom(src => src.MokebId))
            .ForMember(dest => dest.Pilgrim, act => act.MapFrom(src => src.Pilgrim))
            .ForMember(dest => dest.BedNumber, act => act.MapFrom(src => src.BedNumber))
            .ForMember(dest => dest.IsDeleted, act => act.MapFrom(src => src.IsDeleted))
            .ReverseMap()
            .MapExtraProperties();

        CreateMap<CreateUpdateBedDto, BedDto>()
            .ForMember(dest => dest.PilgrimId, act => act.MapFrom(src => src.PilgrimId))
            .ForMember(dest => dest.TenantId, act => act.MapFrom(src => src.TenantId))
            .ForMember(dest => dest.MokebId, act => act.MapFrom(src => src.MokebId))
            .ForMember(dest => dest.BedNumber, act => act.MapFrom(src => src.BedNumber))
            .ForMember(dest => dest.IsDeleted, act => act.MapFrom(src => src.IsDeleted))
            .ReverseMap();

        CreateMap<Bed, CreateUpdateBedDto>()
            .ForMember(dest => dest.PilgrimId, act => act.MapFrom(src => src.PilgrimId))
            .ForMember(dest => dest.TenantId, act => act.MapFrom(src => src.TenantId))
            .ForMember(dest => dest.MokebId, act => act.MapFrom(src => src.MokebId))
            .ForMember(dest => dest.BedNumber, act => act.MapFrom(src => src.BedNumber))
            .ForMember(dest => dest.IsDeleted, act => act.MapFrom(src => src.IsDeleted))
            .ReverseMap();
    }
}
