using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
			return Ok(values);
		}
		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory()
			{
				ProductDescription = y.ProductDescription,
				ProductImageUrl = y.ProductImageUrl,
				ProductName = y.ProductName,
				ProductPrice = y.ProductPrice,
				ProductStatus = y.ProductStatus,
				ProductID = y.ProductID,
				CategoryName = y.Category.CategoryName
			});
			return Ok(values);
		}

		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_productService.TProductCount());
		}

		[HttpGet("ProductCountByCategoryNameDrink")]
		public IActionResult ProductCountByCategoryNameDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}

		[HttpGet("ProductCountByCategoryNameHamburger")]
		public IActionResult ProductCountByCategoryNameHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}

		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}

		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}

		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}

		[HttpPost]
		public IActionResult ProductCreate(CreateProductDto createProductDto)
		{
			_productService.TAdd(new Product()
			{
				ProductName = createProductDto.ProductName,
				ProductPrice = createProductDto.ProductPrice,
				ProductImageUrl = createProductDto.ProductImageUrl,
				ProductDescription = createProductDto.ProductDescription,
				ProductStatus = createProductDto.ProductStatus,
				CategoryID = createProductDto.CategoryID,
			});
			return Ok("Ürün Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult ProductDelete(int id)
		{
			var value = _productService.TGetByID(id);
			_productService.TDelete(value);
			return Ok("Ürün Silindi");
		}

		[HttpPut]
		public IActionResult ProductUpdate(UpdateProductDto updateProductDto)
		{
			_productService.TUpdate(new Product()
			{
				ProductName = updateProductDto.ProductName,
				ProductPrice = updateProductDto.ProductPrice,
				ProductImageUrl = updateProductDto.ProductImageUrl,
				ProductDescription = updateProductDto.ProductDescription,
				ProductStatus = updateProductDto.ProductStatus,
				ProductID = updateProductDto.ProductID,
				CategoryID = updateProductDto.CategoryID
			});
			return Ok("Ürün Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult ProductGet(int id)
		{
			var value = _productService.TGetByID(id);
			return Ok(value);
		}
	}
}
