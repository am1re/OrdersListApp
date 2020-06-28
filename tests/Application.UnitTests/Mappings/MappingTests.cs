using Application.OrderItems.Queries;
using Application.Orders.Queries;
using Application.Products.Queries;
using Application.Statuses.Queries;
using AutoMapper;
using Domain.Entities;
using Xunit;
using Shouldly;

namespace Application.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapProductToProductDto()
        {
            var entity = new Product();

            var result = _mapper.Map<ProductDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ProductDto>();
        }
        
        [Fact]
        public void ShouldMapStatusToStatusDto()
        {
            var entity = new Status();

            var result = _mapper.Map<StatusDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<StatusDto>();
        }
        
        [Fact]
        public void ShouldMapOrderToOrderDto()
        {
            var entity = new Order();

            var result = _mapper.Map<OrderDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<OrderDto>();
        }
        
        [Fact]
        public void ShouldMapOrderItemToOrderItemDto()
        {
            var entity = new OrderItem();

            var result = _mapper.Map<OrderItemDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<OrderItemDto>();
        }
    }
}
