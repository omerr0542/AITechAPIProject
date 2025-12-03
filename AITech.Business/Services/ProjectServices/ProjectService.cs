using AITech.DataAccess.Repositories.ProjectRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.ProjectDtos;
using AITech.Entity.Entities;
using Mapster;

namespace AITech.Business.Services.ProjectServices
{
    public class ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork) : IProjectService
    {
        public async Task TCreateAsync(CreateProjectDto createDto)
        {
            var project = createDto.Adapt<Project>();
            await projectRepository.CreateAsync(project);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var project = await projectRepository.GetByIdAsync(id);

            if (project is null)
                throw new Exception("Silinecek Proje Bulunamadı");

            projectRepository.Delete(project);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultProjectDto>> TGetAllAsync()
        {
            var projects = await projectRepository.GetAllAsync();
            return projects.Adapt<List<ResultProjectDto>>();
        }

        public async Task<ResultProjectDto> TGetByIdAsync(int id)
        {
            var project = await projectRepository.GetByIdAsync(id);
            return project.Adapt<ResultProjectDto>();
        }

        public async Task<List<ResultProjectDto>> TGetProjectsWithCategoriesAsync()
        {
            var projects = await projectRepository.GetProjectsWithCategoriesAsync();
            return projects.Adapt<List<ResultProjectDto>>();
        }

        public Task TUpdateAsync(UpdateProjectDto updateDto)
        {
            var project = updateDto.Adapt<Project>();
            projectRepository.Update(project);
            return unitOfWork.SaveChangesAsync();
        }
    }
}
