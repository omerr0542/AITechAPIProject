using AITech.WebUI.DTOs.ProjectDtos;

namespace AITech.WebUI.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7243/api/");
            _httpClient = httpClient;
        }

        public async Task CreateAsync(CreateProjectDto projectDto)
        {
            await _httpClient.PostAsJsonAsync("Projects", projectDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"Projects/" + id);
        }

        public async Task<List<ResultProjectDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProjectDto>>("Projects/WithCategories");
        }

        public Task<UpdateProjectDto> GetByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<UpdateProjectDto>($"Projects/" + id);
        }

        public async Task UpdateAsync(UpdateProjectDto projectDto)
        {
            await _httpClient.PutAsJsonAsync("Projects", projectDto);
        }
    }
}
