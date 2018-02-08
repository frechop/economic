using AutoMapper;
using Economic.Data.Entities;
using Economic.Models;

namespace Economic.Data.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectViewModel>();

            CreateMap<ProjectViewModel, Project>().ForMember(dest => dest.UserGUID, opt => opt.Ignore());

        }
    }
}
