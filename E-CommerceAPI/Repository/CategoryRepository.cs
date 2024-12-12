using E_CommerceAPI.Data;
using E_CommerceAPI.DTO;
using E_CommerceAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_CommerceAPI.Repository
{
    public class CategoryRepository : ICategoryInterface
    {

        private readonly EcommerceDbcontext _context;

        public CategoryRepository(EcommerceDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.eCategory
                .Include(c => c.SubCategories)
                .ToListAsync();

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                SubCategories = c.SubCategories.Select(sc => new SubCategoryDto
                {
                    Id = sc.Id,
                    Name = sc.Name
                }).ToList()
            });
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _context.eCategory
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                SubCategories = category.SubCategories.Select(sc => new SubCategoryDto
                {
                    Id = sc.Id,
                    Name = sc.Name
                }).ToList()
            };
        }

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = new eCategory
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };

            await _context.eCategory.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task AddSubCategoryAsync(int categoryId, SubCategoryDto subCategoryDto)
        {
            var subCategory = new eSubCategory
            {
                Name = subCategoryDto.Name,
                CategoryId = categoryId
            };

            await _context.eSubCategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {
            var category = await _context.eCategory.FindAsync(id);

            if (category == null) throw new Exception("Category not found");

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;

            _context.eCategory.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.eCategory
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) throw new Exception("Category not found");

            _context.eCategory.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
