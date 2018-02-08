using Economic.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Economic.Web.Tests
{
    public class MapperProfileTest
    {
        [Fact]
        public void MapperProfiles_Valid()
        {
            AutoMapper.Mapper.Initialize(m => m.AddProfile<TimeReportProfile>());
            AutoMapper.Mapper.Initialize(m => m.AddProfile<ProjectProfile>());
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
