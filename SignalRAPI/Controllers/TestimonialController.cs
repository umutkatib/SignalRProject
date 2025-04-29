using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
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
				TestimonialImageURl = createTestimonialDto.TestimonialImageURl,
				TestimonialName = createTestimonialDto.TestimonialName,
				TestimonialStatus = true,
				TestimonialTitle = createTestimonialDto.TestimonialTitle
			});
			return Ok("Müşteri Yorumu Eklendi");
		}

		[HttpDelete]
		public IActionResult TestimonialDelete(int id)
		{
			var value = _testimonialService.TGetByID(id);
			_testimonialService.TDelete(value);
			return Ok("Müşteri Yorumu Silindi");
		}

		[HttpPut]
		public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
		{
			_testimonialService.TUpdate(new Testimonial()
			{
				TestimonialComment = updateTestimonialDto.TestimonialComment,
				TestimonialImageURl = updateTestimonialDto.TestimonialImageURl,
				TestimonialName = updateTestimonialDto.TestimonialName,
				TestimonialStatus = updateTestimonialDto.TestimonialStatus,
				TestimonialTitle = updateTestimonialDto.TestimonialTitle,
				TestimonialID = updateTestimonialDto.TestimonialID
			});
			return Ok("Müşteri Yorumu Güncellendi");
		}

		[HttpGet("TestimonialGet")]
		public IActionResult TestimonialGet(int id)
		{
			var value = _testimonialService.TGetByID(id);
			return Ok(value);
		}
	}
}
