﻿using AssetManagementsBlazor.Data;
using AssetManagementsBlazor.Entities;
using Microsoft.EntityFrameworkCore;
using static MudBlazor.Icons;

namespace AssetManagementsBlazor.Services

{
    public class CategoryService : ICategoryService
    {
        private readonly AssetDataContext _context;

        public CategoryService(AssetDataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            try
            {
                var category = await _context.Category.ToListAsync();
                return category;
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while fetching categories.", ex);
            }
        }

        public async Task<Category> AddCategory (Category category)
        {
            try
            {
                _context.Category.Add(category);
                await _context.SaveChangesAsync();

                return category;
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while updating the category.", ex);
            }
        }

        public async Task<bool> DeleteCategory (Guid CategoryOid)
        {
            try
            {
                var category = await _context.Customers.FindAsync(CategoryOid);
                if (category == null)
                {
                    return false;
                }
                _context.Customers.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while updating the category.", ex);
            }
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            try
            {
                var existingCategory = await _context.Category.FindAsync(category.CategoryOid);
                if (existingCategory == null)
                {
                    return false;
                }

                existingCategory.Name = category.Name;

                _context.Category.Update(existingCategory);
                await _context.SaveChangesAsync();
                return true;    
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while updating the category.", ex);
            }
        }
    }
}
