using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ShowcaseDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultCaraouselViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultCaraouselViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7183/api/Showcases");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultShowcaseDto>>(jsonData);
                ViewBag.SliderCount = values.Count;
                return View(values);
            }

            return View();

        }
    }
}
