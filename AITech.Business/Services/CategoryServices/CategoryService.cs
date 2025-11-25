using AITech.DataAccess.Repositories.CategoryRepositories;
using AITech.DataAccess.UnitOfWorks;
using AITech.DTO.CategoryDtos;
using AITech.Entity.Entities;
using Mapster;

namespace AITech.Business.Services.CategoryServices
{
    public class CategoryService(
                                 ICategoryRepository categoryRepository,
                                 IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task TCreateAsync(CreateCategoryDto createDto)
        {
            var category = createDto.Adapt<Category>();
            await categoryRepository.CreateAsync(category);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task TDeleteAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);

            if (category == null)
                throw new Exception("Silinecek Kategori Bulunamadı");

            categoryRepository.Delete(category);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ResultCategoryDto>> TGetAllAsync()
        {
            var categories = await categoryRepository.GetAllAsync();
            return categories.Adapt<List<ResultCategoryDto>>();
        }

        public async Task<ResultCategoryDto> TGetByIdAsync(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new Exception("Kategori Bulunamadı");

            return category.Adapt<ResultCategoryDto>();
        }

        public async Task TUpdateAsync(UpdateCategoryDto updateDto)
        {
            var category = updateDto.Adapt<Category>();
            categoryRepository.Update(category);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
