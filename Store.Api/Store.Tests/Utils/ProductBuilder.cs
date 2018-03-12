using System.Collections.Generic;
using AutoFixture;
using Store.DataAccess.Entities;

namespace Store.Tests.Utils
{
    public class ProductBuilder
    {
        public Product Build()
        {
            var fixture = new Fixture().WithStandardCustomization();
            var type = fixture.Build<Type>().With(t => t.Code, "001").With(t => t.Description, "Des").Create();
            var unit = fixture.Build<Unit>().With(t => t.Code, "001").With(t => t.Description, "Des").Create();
            var category = fixture.Build<Category>().With(t => t.Code, "001").With(t => t.Description, "Des").Create();
            var productWithType = fixture.Build<Product>()
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
            return productWithType;
        }
    }
}