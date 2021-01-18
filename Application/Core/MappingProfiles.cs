using Application.Activities;
using AutoMapper;
using Domain.Models;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();    //To create a clone of the details
            CreateMap<Activity, ActivityDto>();
        }
    }
}
