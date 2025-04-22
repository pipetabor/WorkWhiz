using AutoMapper;
using WorkWhiz.Core.DTOs;
using WorkWhiz.Core.Models;

namespace WorkWhiz.Core.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Poster, PosterDto>();
            CreateMap<Poster, PosterNameDto>();
            CreateMap<Job, JobDto>().ReverseMap();
            CreateMap<Job, JobCreateDto>().ReverseMap();
            CreateMap<Job, JobTop10Dto>();
            CreateMap<Job, JobTopActiveDto>().ReverseMap();
            CreateMap<Bid, BidDto>().ReverseMap();
        }
    }
}
