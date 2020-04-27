using AutoMapper;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, ImportCategoryDTO>();
            this.CreateMap<ImportCategoryDTO, Product>();

            this.CreateMap<User, ImportUserDTO>();
            this.CreateMap<ImportUserDTO, User>().ForMember(x => x.FirstName, y => y.MapFrom(x => x.FirtsName));

            this.CreateMap<Category, ImportCategoryDTO>();
            this.CreateMap<ImportCategoryDTO, Category>();
        }
    }
}
