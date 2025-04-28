using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ShowcaseDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Showcase")]
    public class ShowcaseController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ShowcaseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Vitrin İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Vitrinler";
            ViewBag.v3 = "Vitrin Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7183/api/Showcases");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultShowcaseDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("CreateShowcase")]
        [HttpGet]
        public async Task<IActionResult> CreateShowcase()
        {
            ViewBag.v0 = "Vitrin İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Vitrinler";
            ViewBag.v3 = "Vitrin Listesi";
            return View();
        }

        [Route("CreateShowcase")]
        [HttpPost]
        public async Task<IActionResult> CreateShowcase(CreateShowcaseDto createShowcaseDto)
        {
            ViewBag.v0 = "Vitrin İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Vitrinler";
            ViewBag.v3 = "Vitrin Listesi";

            createShowcaseDto.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createShowcaseDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7183/api/Showcases", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Showcase", new { area = "Admin" });
            }

            return View();
        }


        [Route("DeleteShowcase/{id}")]
        public async Task<IActionResult> DeleteShowcase(string id)

        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7183/api/Showcases/" + id);

            if (responseMessage.IsSuccessStatusCode)

                return RedirectToAction("Index", "Showcase", new { area = "Admin" });

            return View();

        }

        [Route("UpdateShowcase/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateShowcase(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7183/api/Showcases/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateShowcaseDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("UpdateShowcase/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateShowcase(UpdateShowcaseDto updateShowcaseDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateShowcaseDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7183/api/Showcases/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Showcase", new { area = "Admin" });
            }

            return View();
        }
    }
}
