using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailsController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoDetailService = cargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoDetailList()
        {
            var values = await _cargoDetailService.TGetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetailById(int id)
        {
            var values = await _cargoDetailService.TGetByIdAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            var value = _mapper.Map<CargoDetail>(createCargoDetailDto);
            await _cargoDetailService.TCreateAsync(value);
            return Ok("Başarıyla oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var value = _mapper.Map<CargoDetail>(updateCargoDetailDto);
            await _cargoDetailService.TUpdateAsync(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCargoDetail(int id)
        {
            await _cargoDetailService.TRemoveAsync(id);
            return Ok("Başarıyla silindi.");
        }
    }
}
