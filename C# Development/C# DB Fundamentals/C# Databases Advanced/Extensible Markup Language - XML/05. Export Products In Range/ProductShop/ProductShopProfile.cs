using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ImportCategoryProductDTO>();
            this.CreateMap<ImportCategoryProductDTO, Product>();

            this.CreateMap<User, ImportUserDTO>();
            this.CreateMap<ImportUserDTO, User>()
                .ForMember(x => x.FirstName, y => y.MapFrom(x => x.FirtsName));

            this.CreateMap<Category, ImportCategoryProductDTO>();
            this.CreateMap<ImportCategoryProductDTO, Category>();

            this.CreateMap<CategoryProduct, ImportCategoryProductDTO>();

            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();
        }
    }
}
