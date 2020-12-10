using AutoMapper;
using Permissions.BL.Dto;
using Permissions.DAL.Entities;

namespace Permissions.BL.Mappers
{
    public class PermitProfile : Profile
    {
        public PermitProfile()
        {
            CreateMap<PermitType, PermitTypeDto>()
                .ReverseMap();

            CreateMap<Permit, PermitDto>()
            .ReverseMap();
        }
    }
}
