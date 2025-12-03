using AITech.Business.Services.GenericServices;
using AITech.DTO.ProjectDtos;
using System.Formats.Asn1;

namespace AITech.Business.Services.ProjectServices;

public interface IProjectService : IGenericService<ResultProjectDto, CreateProjectDto, UpdateProjectDto>
{
    Task<List<ResultProjectDto>> TGetProjectsWithCategoriesAsync();
}
