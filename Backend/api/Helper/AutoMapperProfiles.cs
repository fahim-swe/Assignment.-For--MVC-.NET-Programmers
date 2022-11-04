

using api.Dto;
using AutoMapper;
using core.Entities;

namespace api.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CustomerDto, Customer>();
        }
    }
}