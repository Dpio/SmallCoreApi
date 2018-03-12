using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AutoFixture;
using Store.DataAccess.Entities;
using Store.Models.Products;
using Store.Tests.Utils;
using Xunit;
using Type = Store.DataAccess.Entities.Type;

namespace Store.Tests.Controllers
{
    public class ProductController_GetAllTests : BaseTestController
    {
        [Fact]
        public async Task ShouldGetProducts_ByType()
        {
            string typeCode = "001";
            string unitCode = String.Empty;
            string categoryCode = String.Empty;
            var products = Fixture.Build<Product>().With(p => p.IsAvailable, true).CreateMany(5).OrderBy(p => p.Id).ToList();
            var type = Fixture.Build<Type>().With(t => t.Code, typeCode).Create();
            var unit = Fixture.Build<Unit>().With(t => t.Code, "001").Create();
            var category = Fixture.Build<Category>().With(t => t.Code, "001").Create();
            var productWithType = Fixture.Build<Product>()
                                    .With(p => p.Id, 100)
                                    .With(p => p.Type, type)
                                    .With(p => p.Unit, unit)
                                    .With(p => p.ProductCategory, new List<ProductCategory>())
                                    .Create();
            var pc = new ProductCategory()
            {
                Category = category,
                Product = productWithType
            };
            productWithType.ProductCategory.Add(pc);
            Context.Products.Add(productWithType);
            Context.Products.AddRange(products);
            Context.SaveChanges();

            // Act
            var requestUri = $"api/Product/getAll?TypeCode={typeCode}&UnitCode={unitCode}&CategoryCode={categoryCode}&MaxResultCount=10&SkipCount=0";
            var response = await Client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonResult).ToList();
            Assert.True(actual.All(dto => dto.TypeId == type.Id));
            Assert.Equal(actual.Count, actual: 1);
        }

        [Fact]
        public async Task ShouldGetProducts_ByUnit()
        {
            string typeCode = String.Empty;
            string unitCode = "001";
            string categoryCode = String.Empty;
            var products = Fixture.Build<Product>().With(p => p.IsAvailable, true).CreateMany(5).OrderBy(p => p.Id).ToList();
            var type = Fixture.Build<Type>().With(t => t.Code, "001").Create();
            var unit = Fixture.Build<Unit>().With(t => t.Code, unitCode).Create();
            var category = Fixture.Build<Category>().With(t => t.Code, "001").Create();
            var productWithType = Fixture.Build<Product>()
                                    .With(p => p.Id, 100)
                                    .With(p => p.Type, type)
                                    .With(p => p.Unit, unit)
                                    .With(p => p.ProductCategory, new List<ProductCategory>())
                                    .Create();
            var pc = new ProductCategory()
            {
                Category = category,
                Product = productWithType
            };
            productWithType.ProductCategory.Add(pc);
            Context.Products.Add(productWithType);
            Context.Products.AddRange(products);
            Context.SaveChanges();

            // Act
            var requestUri = $"api/Product/getAll?TypeCode={typeCode}&UnitCode={unitCode}&CategoryCode={categoryCode}&MaxResultCount=10&SkipCount=0";
            var response = await Client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonResult).ToList();
            Assert.True(actual.All(dto => dto.UnitId == unit.Id));
            Assert.Equal(actual.Count, actual: 1);
        }

        [Fact]
        public async Task ShouldGetProducts_ByCategory()
        {
            string typeCode = String.Empty;
            string unitCode = String.Empty;
            string categoryCode = "001";
            var products = Fixture.Build<Product>().With(p => p.IsAvailable, true).CreateMany(5).OrderBy(p => p.Id).ToList();
            var productWithType = new ProductBuilder().Build();
            Context.Products.Add(productWithType);
            Context.Products.AddRange(products);
            Context.SaveChanges();

            // Act
            var requestUri = $"api/Product/getAll?TypeCode={typeCode}&UnitCode={unitCode}&CategoryCode={categoryCode}&MaxResultCount=10&SkipCount=0";
            var response = await Client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            string jsonResult = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(jsonResult).ToList();
            Assert.Equal(actual.Count, actual: 1);
        }
    }
}