﻿using AutoMapper;
using Economic.Data.Entities;
using Economic.Models;

namespace Economic.Data.Mapping
{
    public class TimeReportProfile : Profile
    {
        public TimeReportProfile()
        {
            CreateMap<TimeReport, TimeReportViewModel>().ReverseMap();

            CreateMap<TimeReportsOverviewViewModel, TimeReport>().
                ForMember( dest => dest.Id, opt => opt.Ignore()).
                ForMember(dest => dest.ProjectId, opt => opt.Ignore()).
                ForMember(dest => dest.CreationDate, opt => opt.Ignore()).
                ForMember(dest => dest.Submitted, opt => opt.Ignore());
        }
    }
}
