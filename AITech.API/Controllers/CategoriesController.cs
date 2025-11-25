using AITech.Business.Services.CategoryServices;
using AITech.DTO.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        //localhost:7000/api/categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await categoryService.TGetAllAsync();
            return Ok(categories);
        }

        //localhost:7000/api/categories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await categoryService.TGetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            await categoryService.TCreateAsync(categoryDto);
            return Ok("Kategori Oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {
            await categoryService.TUpdateAsync(categoryDto);
            return Ok("Kategori Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.TDeleteAsync(id);
            return Ok("Kategori Silindi");
        }
    }
}
