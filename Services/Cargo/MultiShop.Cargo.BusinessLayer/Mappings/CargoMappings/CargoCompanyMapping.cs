using AutoMapper;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Mappings.CargoMappings
{
    public class CargoCompanyMapping : Profile
    {
        public CargoCompanyMapping()
        {
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();
        }
    }
}
