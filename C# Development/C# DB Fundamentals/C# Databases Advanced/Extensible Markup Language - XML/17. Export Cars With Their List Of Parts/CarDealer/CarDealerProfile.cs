using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //this.CreateMap<Car, CarsFromMakeBMWDTO>();

            //this.CreateMap<Car, ExportLocalSuppliersDTO>().ForMember(x => x.PartsCount, y => y.MapFrom(x => x.PartCars.Count));
        }
    }
}
