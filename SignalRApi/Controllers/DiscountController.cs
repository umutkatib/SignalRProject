using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.ContactDto;
using SignalR.DTOLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult DiscountCreate(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
                DiscountAmount = createDiscountDto.DiscountAmount,
                DiscountDescription = createDiscountDto.DiscountDescription,
                DiscountImageURL = createDiscountDto.DiscountImageURL,
                DiscountTitle = createDiscountDto.DiscountTitle
            });
            return Ok("İndirim Bilgisi Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public IActionResult DiscountDelete(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("İndirim Bilgisi Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult DiscountUpdate(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountAmount = updateDiscountDto.DiscountAmount,
                DiscountDescription = updateDiscountDto.DiscountDescription,
                DiscountImageURL = updateDiscountDto.DiscountImageURL,
                DiscountTitle = updateDiscountDto.DiscountTitle,
                DiscountID = updateDiscountDto.DiscountID
            });
            return Ok("İndirim Bilgisi Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetDiscount")]
        public IActionResult DiscountGet(int id)
        {
            var value = _discountService.TGetByID(id);
            return Ok(value);
        }
    }
}
