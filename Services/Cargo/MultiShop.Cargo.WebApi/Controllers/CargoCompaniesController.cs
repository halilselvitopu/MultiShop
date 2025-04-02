using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService, IMapper mapper)
        {
            _cargoCompanyService = cargoCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCompanyById(int id)
        {
            var values = await _cargoCompanyService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var value = _mapper.Map<CargoCompany>(createCargoCompanyDto);
            await _cargoCompanyService.TCreateAsync(value);
            return Ok("Başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var value = _mapper.Map<CargoCompany>(updateCargoCompanyDto);
            await _cargoCompanyService.TUpdateAsync(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCargoCompany(int id)
        {
            await _cargoCompanyService.TRemoveAsync(id);
            return Ok("Başarıyla silindi.");
        }
    }
}
