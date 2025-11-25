namespace AITech.DTO.CategoryDtos
{
    public record ResultCategoryDto(int Id, string? Name);
    // Bu şekilde tanımlayarak immutable (değiştirilemez) bir DTO oluşturmuş oluruz.
    // Bu, veri bütünlüğünü korumak ve yanlışlıkla değişiklik yapılmasını önlemek için faydalıdır.
}
