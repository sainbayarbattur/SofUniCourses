using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<User, ExportUsersAndProducts>();

            this.CreateMap<ExportUsersAndProducts, UserDTO>();

            this.CreateMap<UserDTO, ExportSoldProductsDTO>();

            this.CreateMap<ExportSoldProductsDTO, ProductDTO>();
        }
    }
}
