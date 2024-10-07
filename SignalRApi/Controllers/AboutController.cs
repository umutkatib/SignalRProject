using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AboutCreate(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                AboutTitle = createAboutDto.AboutTitle,
                AboutDescription = createAboutDto.AboutDescription,
                AboutImageURL = createAboutDto.AboutImageURL,
            };

            _aboutService.TAdd(about);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete]
        public IActionResult AboutDelete(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok("Hakkımda Alanı Başarılı Bir Şekilde Silindi.");
        }

        [HttpPut]
        public IActionResult AboutUpdate(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutID = updateAboutDto.AboutID,
                AboutTitle = updateAboutDto.AboutTitle,
                AboutDescription = updateAboutDto.AboutDescription,
                AboutImageURL = updateAboutDto.AboutImageURL,
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda Kısmı Başarılı Bir Güncellendi Eklendi.");
        }

        [HttpGet("GetAbout")]
        public IActionResult AboutGet(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }
    }
}
