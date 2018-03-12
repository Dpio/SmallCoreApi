using Microsoft.Extensions.DependencyInjection;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories;
using Store.Logic;
using Store.Logic.Impl;

namespace Store.Api
{
    public class IocModule
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            InitAutomapper(services);
            RegisterServices(services);
            RegisterRepos(services);
        }

        private static void InitAutomapper(IServiceCollection services)
        {
            var mapperConfiguration = AutoMapperConfig.Get();
            services.AddSingleton(x => mapperConfiguration.CreateMapper());
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUnitService, UnitService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }

        private static void RegisterRepos(IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<Type>, TypeRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IGenericRepository<Category>, CategoryRepository>();
            services.AddTransient<IGenericRepository<Unit>, UnitRepository>();
        }
    }
}