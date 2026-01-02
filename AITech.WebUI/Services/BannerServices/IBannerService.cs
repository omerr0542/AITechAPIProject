using AITech.WebUI.DTOs.BannerDtos;

namespace AITech.WebUI.Services.BannerServices
{
    public interface IBannerService
    {
        Task<List<ResultBannerDto>> GetAllAsync();
        Task<UpdateBannerDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBannerDto bannerDto);
        Task UpdateAsync(UpdateBannerDto bannerDto);
        Task DeleteAsync(int id);
        Task MakeActiveAsync(int id);
        Task MakePassiveAsync(int id);
    }
}
