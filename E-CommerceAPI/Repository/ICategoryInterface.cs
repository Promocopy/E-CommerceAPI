
using E_CommerceAPI.DTO;

namespace E_CommerceAPI.Repository
{
    public interface ICategoryInterface
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryDto categoryDto);
        Task AddSubCategoryAsync(int categoryId, SubCategoryDto subCategoryDto);
        Task UpdateCategoryAsync(int id, CategoryDto categoryDto);
        Task DeleteCategoryAsync(int id);
    }
}
