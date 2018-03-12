using System.Collections.Generic;
using Store.Logic.Base.Services;
using Store.Models.Products;

namespace Store.Logic
{
    public interface IProductService : ICrudAppService<ProductDto, CreateProductDto, ProductDto>
    {
        IEnumerable<ProductDto> GetAllActive(GetActiveProductInput input);
        IEnumerable<ProductDto> GetAll(GetAllProductsInput input);
        ProductDetailsDto GetWithDetails(int id);
    }
}