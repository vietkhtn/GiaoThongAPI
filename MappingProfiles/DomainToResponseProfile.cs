using AutoMapper;
using HumanResource.ApplicationCore.Entities;
using IThong.DTOS.Responses;
using IThong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.MappingProfiles
{
    public class DomainToResponseProfile: Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Role, RoleResponse>();
            CreateMap<VehicleType, VehicleTypeDTO>();
            CreateMap<DriversLicensesType, DriversLicensesTypeDTO>()
                .ForMember(dest=>dest.ListVehicleType,opt=> {
                    opt.MapFrom(src => src.VehicleTypeDriversLicenseTypes.Select(vh => new { vehicleTypeId = vh.VehicleTypeId }));
                });
            CreateMap<RecordProfile, RecordProfileDTO>()
                .ForMember(dest => dest.NumberPlate, opt => opt.MapFrom(src=>src.Vehicle.NumberPlate))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Vehicle.Brand))
                .ForMember(dest => dest.ProductionDate, opt => opt.MapFrom(src => src.Vehicle.ProductionDate))
                .ForMember(dest => dest.FrameNumber, opt => opt.MapFrom(src => src.Vehicle.FrameNumber))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Vehicle.Color))


                .ForMember(dest=>dest.FirstName,opt=>opt.MapFrom(src=>src.VehicleOwner.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.VehicleOwner.LastName))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.VehicleOwner.Addresses))
                .ForMember(dest => dest.IDNo, opt => opt.MapFrom(src => src.VehicleOwner.IDNo))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.VehicleOwner.PhoneNumber))
                ;

            CreateMap<CitizenShipProfile, CitizenShipProfileDTO>();
            CreateMap< Vehicle, VehicleDTO>();
        }
    }
}
