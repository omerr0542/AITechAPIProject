using AITech.Business.Services.CategoryServices;
using AITech.Business.Services.ProjectServices;
using AITech.DTO.ProjectDtos;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService projectService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await projectService.TGetAllAsync();
            return Ok(projects);
        }

        [HttpGet("WithCategories")]
        public async Task<IActionResult> GetAllWithCategories()
        {
            var projects = await projectService.TGetProjectsWithCategoriesAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await projectService.TGetByIdAsync(id);
            if (project is null)
                return BadRequest("Proje Bulunamadı");

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectDto projectDto)
        {
            await projectService.TCreateAsync(projectDto);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto projectDto)
        {
            await projectService.TUpdateAsync(projectDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await projectService.TDeleteAsync(id);
            return NoContent();
        }
    }
}
