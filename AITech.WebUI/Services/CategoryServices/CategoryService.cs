using AITech.WebUI.DTOs.CategoryDtos;
using Newtonsoft.Json;

namespace AITech.WebUI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7000/api/");
            _httpClient = httpClient;
        }

        public Task CreateAsync(CreateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("Categories");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Kategori verileri alınamadı.");
            }

            var jsonContent = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonContent);

            return categories;
        }

        public Task<UpdateCategoryDto> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
