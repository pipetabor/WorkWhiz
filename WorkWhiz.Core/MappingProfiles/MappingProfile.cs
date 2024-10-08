﻿using AutoMapper;
using WorkWhiz.Core.DTOs;
using WorkWhiz.Core.Models;

namespace WorkWhiz.Core.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define mappings between models and DTOs
            CreateMap<Poster, PosterDto>();
            CreateMap<Poster, PosterNameDto>();
            CreateMap<Job, JobDto>();
            CreateMap<Job, JobTop10Dto>();
        }
    }
}
