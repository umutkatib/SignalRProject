using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRAPI.Models;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")] 
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id)
                .Select(z => new ResultBasketListWithProduct
                {
                    BasketID = z.BasketID,
                    BasketCount = z.BasketCount,
                    BasketPrice = z.BasketPrice,
                    BasketTotalPrice = z.BasketTotalPrice,
                    ProductID = z.ProductID,
                    MenuTableID = z.MenuTableID,
                    BasketProductName = z.Product.ProductName,
                }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult BasketCreate(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                BasketCount = 1,
                MenuTableID = 2,
                BasketPrice = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.ProductPrice).FirstOrDefault(),
                BasketTotalPrice = 0,
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult BasketDelete(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Öğe Silindi");
        }
    }
}
