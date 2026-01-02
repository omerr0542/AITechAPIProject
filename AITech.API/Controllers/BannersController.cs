using AITech.Business.Services.BannerServices;
using AITech.DTO.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IBannerService bannerService) : ControllerBase
    {
        //localhost:7000/api/banners
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await bannerService.TGetAllAsync();
            return Ok(categories);
        }

        //localhost:7000/api/banners/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var banner = await bannerService.TGetByIdAsync(id);
            return Ok(banner);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto bannerDto)
        {
            await bannerService.TCreateAsync(bannerDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto bannerDto)
        {
            await bannerService.TUpdateAsync(bannerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await bannerService.TDeleteAsync(id);
            return NoContent();
        }


        [HttpPatch("makeActive/{id}")]
        public async Task<IActionResult> MakeActive(int id)
        {
            await bannerService.TMakeActiveAsync(id);
            return NoContent();
        }

        // httpPatch, verinin tamamını değil, sadece bir kısmını güncellemek için kullanılır.
        [HttpPatch("makePassive/{id}")]
        public async Task<IActionResult> MakePassive(int id)
        {
            await bannerService.TMakePassiveAsync(id);
            return NoContent();
        }
    }
}
