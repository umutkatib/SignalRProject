using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;
		private readonly IMapper _mapper;

		public BookingController(IBookingService bookingService, IMapper mapper)
		{
			_bookingService = bookingService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			//var values = _bookingService.TGetListAll();
			var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult BookingCreate(CreateBookingDto createBookingDto)
		{
			//Booking booking = new Booking()
			//{
			//	BookingMail = createBookingDto.BookingMail,
			//	BookingDate = createBookingDto.BookingDate,
			//	BookingName = createBookingDto.BookingName,
			//	BookingPersonCount = createBookingDto.BookingPersonCount,
			//	BookingPhone = createBookingDto.BookingPhone
			//};
			//_bookingService.TAdd(booking);

			_bookingService.TAdd(new Booking()
			{
				BookingMail = createBookingDto.BookingMail,
				BookingDate = createBookingDto.BookingDate,
				BookingName = createBookingDto.BookingName,
				BookingPersonCount = createBookingDto.BookingPersonCount,
				BookingPhone = createBookingDto.BookingPhone
			});
			return Ok("Rezervasyon Başarılı Bir Şekilde Yapıldı");
		}

		[HttpDelete("{id}")]
		public IActionResult BookingDelete(int id)
		{
			var value = _bookingService.TGetByID(id);
			_bookingService.TDelete(value);
			return Ok("Rezervasyon İptal Edildi");
		}

		[HttpPut]
		public IActionResult BookingUpdate(UpdateBookingDto updateBookingDto)
		{
			//Booking booking = new Booking()
			//{
			//	BookingMail = updateBookingDto.BookingMail,
			//	BookingDate = updateBookingDto.BookingDate,
			//	BookingName = updateBookingDto.BookingName,
			//	BookingPersonCount = updateBookingDto.BookingPersonCount,
			//	BookingPhone = updateBookingDto.BookingPhone
			//};
			//_bookingService.TUpdate(booking);

			_bookingService.TUpdate(new Booking()
			{
				BookingMail = updateBookingDto.BookingMail,
				BookingDate = updateBookingDto.BookingDate,
				BookingName = updateBookingDto.BookingName,
				BookingPersonCount = updateBookingDto.BookingPersonCount,
				BookingPhone = updateBookingDto.BookingPhone,
				BookingID = updateBookingDto.BookingID
			});
			return Ok("Rezervasyon Başarılı Bir Şekilde Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult BookingGet(int id)
		{
			var value = _bookingService.TGetByID(id);
			return Ok(value);
		}
	}
}
