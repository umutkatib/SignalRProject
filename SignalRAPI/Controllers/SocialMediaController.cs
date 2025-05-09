using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SocialMediaList()
		{
			var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult SocialMediaCreate(CreateSocialMediaDto createSocialMediaDto)
		{
			_socialMediaService.TAdd(new SocialMedia()
			{
				SocialMediaIcon = createSocialMediaDto.SocialMediaIcon,
				SocialMediaTitle = createSocialMediaDto.SocialMediaTitle,
				SocialMediaUrl = createSocialMediaDto.SocialMediaUrl
			});
			return Ok("Sosyal Medya Bilgisi Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult SocialMediaDelete(int id)
		{
			var value = _socialMediaService.TGetByID(id);
			_socialMediaService.TDelete(value);
			return Ok("Sosyal Medya Bilgisi Kaldırıldı");
		}

		[HttpPut]
		public IActionResult SocialMediaUpdate(UpdateSocialMediaDto updateSocialMediaDto)
		{
			_socialMediaService.TUpdate(new SocialMedia()
			{
				SocialMediaIcon = updateSocialMediaDto.SocialMediaIcon,
				SocialMediaTitle = updateSocialMediaDto.SocialMediaTitle,
				SocialMediaUrl = updateSocialMediaDto.SocialMediaUrl,
				SocialMediaID = updateSocialMediaDto.SocialMediaID
			});
			return Ok("Sosyal Medya Bilgisi Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult SocialMediaGet(int id)
		{
			var value = _socialMediaService.TGetByID(id);
			return Ok(value);
		}
	}
}
