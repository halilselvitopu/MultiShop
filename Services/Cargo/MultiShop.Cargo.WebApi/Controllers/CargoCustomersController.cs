using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoCustomerList()
        {
            var values = await _cargoCustomerService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCustomerById(int id)
        {
            var values = await _cargoCustomerService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var value = _mapper.Map<CargoCustomer>(createCargoCustomerDto);
            await _cargoCustomerService.TCreateAsync(value);
            return Ok("Başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var value = _mapper.Map<CargoCustomer>(updateCargoCustomerDto);
            await _cargoCustomerService.TUpdateAsync(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCargoCustomer(int id)
        {
            await _cargoCustomerService.TRemoveAsync(id);
            return Ok("Başarıyla silindi.");
        }
    }
}
