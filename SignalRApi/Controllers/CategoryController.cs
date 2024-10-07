using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CategoryCreate(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                CategoryStatus = true
            });
            return Ok("Kategori Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Kategori Başarılı Bir Şekilde Silindi");
        }

        [HttpPut] 
        public IActionResult CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryName=updateCategoryDto.CategoryName,
                CategoryID = updateCategoryDto.CategoryID,
                CategoryStatus = updateCategoryDto.CategoryStatus
            });
            return Ok("Kategori Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetCategory")]
        public IActionResult CategoryGet(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(value);
        }

    }
}
