using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult BookingCreate(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
               BookingName = createBookingDto.BookingName,
               BookingDate = createBookingDto.BookingDate,
               BookingMail = createBookingDto.BookingMail,
               BookingPersonCount = createBookingDto.BookingPersonCount,
               BookingPhone = createBookingDto.BookingPhone
            };

            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Başarılı Bir Şekilde Yapıldı.");
        }

        [HttpDelete]
        public IActionResult BookingDelete(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon Başarılı Bir Şekilde İptal Edildi.");
        }

        [HttpPut]
        public IActionResult BookingUpdate(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingName = updateBookingDto.BookingName,
                BookingDate = updateBookingDto.BookingDate,
                BookingMail = updateBookingDto.BookingMail,
                BookingPersonCount = updateBookingDto.BookingPersonCount,
                BookingPhone = updateBookingDto.BookingPhone
            };

            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Başarılı Bir Şekilde Değiştirildi.");
        }

        [HttpGet("GetBooking")]
        public IActionResult BookingGet(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }
    }
}
