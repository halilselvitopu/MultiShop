using AutoMapper;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Mappings.CargoMappings
{
    public class CargoDetailMapping : Profile
    {
        public CargoDetailMapping()
        {
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();
        }
    }
}
