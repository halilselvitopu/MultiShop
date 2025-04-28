using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ShowcaseDtos;
using MultiShop.Catalog.Services.ShowcaseServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ShowcasesController : ControllerBase
    {
        private readonly IShowcaseService _ShowcaseService;

        public ShowcasesController(IShowcaseService showcaseService)
        {
            _ShowcaseService = showcaseService;
        }

        [HttpGet]
        public async Task<IActionResult> ShowcaseList()
        {
            var values = await _ShowcaseService.GetAllShowcasesAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShowcaseById(string id)
        {
            var value = await _ShowcaseService.GetShowcaseByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShowcase(CreateShowcaseDto createShowcaseDto)
        {
            await _ShowcaseService.CreateShowcaseAsync(createShowcaseDto);
            return Ok("Vitrin başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShowcase(UpdateShowcaseDto updateShowcaseDto)
        {
            await _ShowcaseService.UpdateShowcaseAsync(updateShowcaseDto);
            return Ok("Vitrin başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShowcase(string id)
        {
            await _ShowcaseService.DeleteShowcaseAsync(id);
            return Ok("Vitrin başarıyla silindi.");
        }
    }
}
