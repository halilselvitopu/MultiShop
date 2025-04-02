using AutoMapper;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Mappings.CargoMappings
{
    public class CargoCustomerMapping : Profile
    {
        public CargoCustomerMapping()
        {
            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();
        }
    }
}
