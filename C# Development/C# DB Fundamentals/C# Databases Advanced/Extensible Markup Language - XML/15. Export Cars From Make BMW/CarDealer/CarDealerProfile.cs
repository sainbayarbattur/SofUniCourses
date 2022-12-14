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

            this.CreateMap<CarsFromMakeBMWDTO, Car>();
        }
    }
}
