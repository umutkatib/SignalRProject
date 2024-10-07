using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.FeatureDto;
using SignalR.DTOLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
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
                SocialMediaURL = createSocialMediaDto.SocialMediaURL,
            });
            return Ok("Sosyal Medya Bilgisi Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public IActionResult SocialMediaDelete(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya Bilgisi Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult SocialMediaUpdate(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                SocialMediaIcon = updateSocialMediaDto.SocialMediaIcon,
                SocialMediaTitle = updateSocialMediaDto.SocialMediaTitle,
                SocialMediaURL = updateSocialMediaDto.SocialMediaURL,
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
            });
            return Ok("Sosyal Medya Bilgisi Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetSocialMedia")]
        public IActionResult SocialMediaGet(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(value);
        }
    }
}
