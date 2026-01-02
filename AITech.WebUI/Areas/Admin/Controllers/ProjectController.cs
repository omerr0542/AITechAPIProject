using AITech.WebUI.DTOs.ProjectDtos;
using AITech.WebUI.Services.CategoryServices;
using AITech.WebUI.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AITech.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController(IProjectService projectService, ICategoryService categoryService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var projects = await projectService.GetAllAsync();
            return View(projects);
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await categoryService.GetAllAsync();
            ViewBag.Categories = (from category in categories
                                  select new SelectListItem
                                      {
                                          Text = category.Name,
                                          Value = category.Id.ToString()
                                      }
                                  );
        }


        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            await LoadCategoriesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategoriesAsync();
                return View(projectDto);
            }

            await projectService.CreateAsync(projectDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProject(int id)
        {
            var projectDto = await projectService.GetByIdAsync(id);
            return View(projectDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto projectDto)
        {
            await projectService.UpdateAsync(projectDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteProject(int id)
        {
            await projectService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
