using AutoMapper;
using Economic.Data.Entities;
using Economic.Models;

namespace Economic.Data.Mapping
{
    public class TaskEntityProfile : Profile
    {
        public TaskEntityProfile()
        {
            CreateMap<TaskEntity, TaskViewModel>().ReverseMap();
        }
    }
}
