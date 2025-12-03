using AITech.WebUI.DTOs.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

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

        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            var jsonContent = JsonConvert.SerializeObject(categoryDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("Categories", content);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"Categories/{id}");
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

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync("Categories/"+ id);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Kategori verisi alınamadı.");
            }

            var jsonContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonContent);
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var jsonContent = JsonConvert.SerializeObject(categoryDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("Categories", content);
        }
    }
}
