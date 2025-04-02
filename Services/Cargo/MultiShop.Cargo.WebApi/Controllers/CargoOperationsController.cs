using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationsController(ICargoOperationService cargoOperationService, IMapper mapper)
        {
            _cargoOperationService = cargoOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoOperationList()
        {
            var values = await _cargoOperationService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperationById(int id)
        {
            var values = await _cargoOperationService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            var value = _mapper.Map<CargoOperation>(createCargoOperationDto);
            await _cargoOperationService.TCreateAsync(value);
            return Ok("Başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var value = _mapper.Map<CargoOperation>(updateCargoOperationDto);
            await _cargoOperationService.TUpdateAsync(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCargoOperation(int id)
        {
            await _cargoOperationService.TRemoveAsync(id);
            return Ok("Başarıyla silindi.");
        }
    }
}
