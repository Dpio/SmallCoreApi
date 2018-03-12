using System.Collections.Generic;
using AutoMapper;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories;
using Store.Logic.Base.Services;
using Store.Models.Products;

namespace Store.Logic.Impl
{
    public class ProductService : CrudAppService<Product, ProductDto, GetAllProductsInput, CreateProductDto, ProductDto>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _productRepository = repository;
        }

        public IEnumerable<ProductDto> GetAllActive(GetActiveProductInput input)
        {
            var allActiveProducts = Repository.GetRange(input.SkipCount, input.MaxResultCount, product => product.IsAvailable);
            var result = Mapper.Map<IEnumerable<ProductDto>>(allActiveProducts);
            return result;
        }

        public IEnumerable<ProductDto> GetAll(GetAllProductsInput input)
        {
            var filterInput = Mapper.Map<ProductFilterInput>(input);
            var products = _productRepository.GetAllProducts(filterInput);
            var result = Mapper.Map<IEnumerable<ProductDto>>(products);
            return result;
        }

        public ProductDetailsDto GetWithDetails(int id)
        {
            var product = _productRepository.GetWithAllIncludes(id);
            var result = Mapper.Map<ProductDetailsDto>(product);
            return result;
        }
    }
}