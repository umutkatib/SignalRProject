using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.SocialMediaDto;
using SignalR.DTOLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult TestimonialCreate(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                TestimonialComment = createTestimonialDto.TestimonialComment,
                TestimonialImageURL = createTestimonialDto.TestimonialImageURL,
                TestimonialName = createTestimonialDto.TestimonialName,
                TestimonialStatus = true,
                TestimonialTitle = createTestimonialDto.TestimonialTitle
            });
            return Ok("Müşteri Yorum Bilgisi Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public IActionResult TestimonialDelete(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("Müşteri Yorum Bilgisi Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                TestimonialComment = updateTestimonialDto.TestimonialComment,
                TestimonialImageURL = updateTestimonialDto.TestimonialImageURL,
                TestimonialName = updateTestimonialDto.TestimonialName,
                TestimonialStatus = updateTestimonialDto.TestimonialStatus,
                TestimonialTitle = updateTestimonialDto.TestimonialTitle,
                TestimonialID = updateTestimonialDto.TestimonialID
            });
            return Ok("Müşteri Yorum Bilgisi Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetTestimonial")]
        public IActionResult TestimonialGet(int id)
        {
            var value = _testimonialService.TGetByID(id);
            return Ok(value);
        }
    }
}
