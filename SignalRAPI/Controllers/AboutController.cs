using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;

		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			//var values = _aboutService.TGetListAll();
			var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult AboutCreate(CreateAboutDto createAboutDto)
		{
			//About about = new About()
			//{
			//	AboutTitle = createAboutDto.AboutTitle,
			//	AboutImageUrl = createAboutDto.AboutImageUrl,
			//	AboutDescription = createAboutDto.AboutDescription,
			//};
			//_aboutService.TAdd(about);

			//with mapping
			_aboutService.TAdd(new About()
			{
				AboutTitle = createAboutDto.AboutTitle,
				AboutDescription = createAboutDto.AboutDescription,
				AboutImageUrl = createAboutDto.AboutImageUrl,
			});
			return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult AboutDelete(int id)
		{
			var value = _aboutService.TGetByID(id);
			_aboutService.TDelete(value);
			return Ok("Hakkımda Kısmı Silindi");
		}

		[HttpPut]
		public IActionResult AboutUpdate(UpdateAboutDto updateAboutDto)
		{
			//About about = new About()
			//{
			//	AboutID = updateAboutDto.AboutID,
			//	AboutTitle = updateAboutDto.AboutTitle,
			//	AboutImageUrl = updateAboutDto.AboutImageUrl,
			//	AboutDescription = updateAboutDto.AboutDescription,
			//};
			//_aboutService.TUpdate(about);

			_aboutService.TUpdate(new About()
			{
				AboutID = updateAboutDto.AboutID,
				AboutTitle = updateAboutDto.AboutTitle,
				AboutImageUrl = updateAboutDto.AboutImageUrl,
				AboutDescription = updateAboutDto.AboutDescription
			});
			return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult AboutGet(int id)
		{
			var value = _aboutService.TGetByID(id);
			return Ok(value);
		}
	}
}
