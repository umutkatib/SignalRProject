using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7217/api/Category");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CategoryCreate()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CategoryCreate(CreateCategoryDto createCategoryDto)
		{
			createCategoryDto.CategoryStatus = true;

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCategoryDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7217/api/Category", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> CategoryDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7217/api/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
				return RedirectToAction("Index");
            }
			return View();
        }

		[HttpGet]
		public async Task<IActionResult> CategoryUpdate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7217/api/Category/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CategoryUpdate(UpdateCategoryDto updateCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7217/api/Category/", stringContent);	
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}
