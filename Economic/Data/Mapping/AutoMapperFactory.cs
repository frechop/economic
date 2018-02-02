using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data.Mapping
{
    internal static class AutoMapperFactory
    {
        public static IMapper CreateAndConfigure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProjectProfile>();
            });

            config.AssertConfigurationIsValid();

            return new Mapper(config);
        }
    }
}
