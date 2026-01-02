using AITech.Business.Services.GenericServices;
using AITech.DTO.BannerDtos;
using AITech.Entity.Entities;

namespace AITech.Business.Services.BannerServices;

public interface IBannerService : IGenericService<ResultBannerDto, CreateBannerDto, UpdateBannerDto>
{
    // Burada ID kullanılmasının sebebi, servis katmanında sadece ID'ye ihtiyaç duyulmasıdır.
    // UpdateBannerDto kullanılmamasının sebebi, sadece ID ile işlemin yapılabilmesidir.
    Task TMakeActiveAsync(int id);
    Task TMakePassiveAsync(int id);
}
