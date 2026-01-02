using AITech.WebUI.DTOs.BannerDtos;
using AITech.WebUI.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController(IBannerService bannerService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var banners = await bannerService.GetAllAsync();
            return View(banners);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto bannerDto)
        {
            await bannerService.CreateAsync(bannerDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var banner = await bannerService.GetByIdAsync(id);
            return View(banner);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto bannerDto)
        {
            await bannerService.UpdateAsync(bannerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBanner(int id)
        {
            await bannerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MakeActiveBanner(int id)
        {
            await bannerService.MakeActiveAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MakePassiveBanner(int id)
        {
            await bannerService.MakePassiveAsync(id);
            return RedirectToAction("Index");
        }

    }
}
