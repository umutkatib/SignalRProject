using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.FeatureDto;
using SignalR.DTOLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
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

        [HttpPost]
        public IActionResult ProductCreate(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                ProductDescription = createProductDto.ProductDescription,
                ProductImageURL = createProductDto.ProductImageURL,
                ProductName = createProductDto.ProductName,
                ProductPrice = createProductDto.ProductPrice,
                ProductStatus = true
            });
            return Ok("Ürün Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public IActionResult ProductDelete(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult ProductUpdate(UpdateProductDto updateProductDto)
        {
            _productService.TAdd(new Product()
            {
                ProductDescription = updateProductDto.ProductDescription,
                ProductImageURL = updateProductDto.ProductImageURL,
                ProductName = updateProductDto.ProductName,
                ProductPrice = updateProductDto.ProductPrice,
                ProductID = updateProductDto.ProductID,
                ProductStatus = updateProductDto.ProductStatus 
            });
            return Ok("Ürün Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetProduct")]
        public IActionResult ProductGet(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(value);
        }
    }
}
