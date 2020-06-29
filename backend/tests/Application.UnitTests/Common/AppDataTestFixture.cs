using System;
using Application.Common.Mapping;
using AutoMapper;
using Infrastructure;
using Xunit;

namespace Application.UnitTests.Common
{
    public class AppDataTestFixture : IDisposable
    {
        public AppDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public AppDataTestFixture()
        {
            Context = AppContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            AppContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("AppDataCollection")]
    public class AppDataCollection : ICollectionFixture<AppDataTestFixture> { }
}