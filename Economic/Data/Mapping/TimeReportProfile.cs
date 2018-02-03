using AutoMapper;
using Economic.Data.Entities;
using Economic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data.Mapping
{
    public class TimeReportProfile : Profile
    {
        public TimeReportProfile()
        {
            CreateMap<TimeReport, TimeReportViewModel>().ReverseMap();
        }
    }
}
