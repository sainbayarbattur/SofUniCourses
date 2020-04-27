using AutoMapper;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Supplier, ImportSupplierDTO>();
            this.CreateMap<ImportSupplierDTO, Supplier>();

            this.CreateMap<Part, ImportPartDTO>();
            this.CreateMap<ImportPartDTO, Part>();

            this.CreateMap<Car, ImportCarDTO>();
            this.CreateMap<ImportCarDTO, Car>();

            this.CreateMap<Customer, ImportCustomerDTO>();
            this.CreateMap<ImportCustomerDTO, Customer>();

            this.CreateMap<Sale, ImportSaleDTO>();
            this.CreateMap<ImportSaleDTO, Sale>();
        }
    }
}
