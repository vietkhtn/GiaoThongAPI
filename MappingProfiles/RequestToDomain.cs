using AutoMapper;
using HumanResource.Api.DTOS.Requests;
using HumanResource.Api.Helpers;
using HumanResource.ApplicationCore.Entities;
using IThong.DTOS.Requests;
using IThong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResource.Api.MappingProfiles
{
   
    public class RequestToDomain: Profile
    {

        public RequestToDomain()
        {
           // CreateMap<UserRequest, User>()
             //   .ForMember(dest => dest.RoleId, opt =>
               // {
                 //   opt.PreCondition(src => src.RoleId.GetValueOrDefault() == 0);
                   // opt.MapFrom(src => 3);
               // }
                    
                //)
                //;
            CreateMap<CitizenShipProfileCreateRequest, CitizenShipProfile>();
            CreateMap<VehicleCreateRequest, Vehicle>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => false));
                ;
            CreateMap<MarginalSanctionsTableCreate, MarginalSanctionsTable>()
                .ForMember(dest => dest.UserHandleerId, opt => opt.MapFrom(src => 0));
            ;
                
                
            
        }
    }
}
