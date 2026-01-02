using AITech.WebUI.DTOs.BannerDtos;

namespace AITech.WebUI.Services.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly HttpClient _httpClient;

        public BannerService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7000/api/");
            _httpClient = httpClient;
        }

        public async Task CreateAsync(CreateBannerDto bannerDto)
        {
            await _httpClient.PostAsJsonAsync("Banners", bannerDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"Banners/" + id);
        }

        public async Task<List<ResultBannerDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultBannerDto>>("Banners");
        }

        public async Task<UpdateBannerDto> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<UpdateBannerDto>($"Banners/" + id);
        }

        public async Task MakeActiveAsync(int id)
        {
            await _httpClient.PatchAsync("Banners/MakeActive/" + id, null);
        }

        public async Task MakePassiveAsync(int id)
        {
            await _httpClient.PatchAsync("Banners/MakePassive/" + id, null);
        }

        public async Task UpdateAsync(UpdateBannerDto bannerDto)
        {
            await _httpClient.PutAsJsonAsync("Banners", bannerDto);
        }
    }
}
