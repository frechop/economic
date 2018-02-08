using AutoMapper;

namespace Economic.Data.Mapping
{
    internal static class AutoMapperFactory
    {
        public static IMapper CreateAndConfigure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProjectProfile>();
                cfg.AddProfile<TimeReportProfile>();
                cfg.AddProfile<TaskEntityProfile>();
            });

            config.AssertConfigurationIsValid();

            return new Mapper(config);
        }
    }
}
