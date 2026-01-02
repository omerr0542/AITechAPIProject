using AITech.DataAccess.Repositories.BannerRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.BannerDtos;
using AITech.Entity.Entities;
using Mapster;

namespace AITech.Business.Services.BannerServices
{
    public class BannerService(IBannerRepository bannerRepository, IUnitOfWork unitOfWork) : IBannerService
    {
        public async Task TCreateAsync(CreateBannerDto createDto)
        {
            var banner = createDto.Adapt<Banner>();
            await bannerRepository.CreateAsync(banner);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var banner = await bannerRepository.GetByIdAsync(id);
            bannerRepository.Delete(banner);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultBannerDto>> TGetAllAsync()
        {
            var banners = await bannerRepository.GetAllAsync();
            return banners.Adapt<List<ResultBannerDto>>();
        }

        public async Task<ResultBannerDto> TGetByIdAsync(int id)
        {
            var banner = await bannerRepository.GetByIdAsync(id);
            return banner.Adapt<ResultBannerDto>();
        }

        public async Task TMakeActiveAsync(int id)
        {
            var banner = await bannerRepository.GetByIdAsync(id);
            await bannerRepository.MakeActiveAsync(banner);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task TMakePassiveAsync(int id)
        {
            var banner = await bannerRepository.GetByIdAsync(id);
            await bannerRepository.MakePassiveAsync(banner);
            await unitOfWork.SaveChangesAsync();
        }

        public Task TUpdateAsync(UpdateBannerDto updateDto)
        {
            var banner = updateDto.Adapt<Banner>();
            bannerRepository.Update(banner);
            return unitOfWork.SaveChangesAsync();
        }
    }
}
