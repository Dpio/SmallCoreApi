using System;
using AutoMapper;
using Store.Logic.Profiles;
using Xunit;

namespace Store.Tests
{
    public class AutoMapperTests : IDisposable
    {
        public AutoMapperTests()
        {
            Mapper.Initialize(e =>
            {
                e.AddProfile(new TypeMappingProfile());
                e.AddProfile(new ProductMappingProfile());
                e.AddProfile(new CategoryMappingProfile());
                e.AddProfile(new UnitMappingProfile());
                e.Advanced.AllowAdditiveTypeMapCreation = true;
            });
        }

        public void Dispose()
        {
            Mapper.Reset();
        }

        [Fact]
        public void CheckMappings()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}