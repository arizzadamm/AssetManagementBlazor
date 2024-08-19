using AssetManagementsBlazor.Entities;
using AssetManagementsBlazor.ViewModel;


namespace AssetManagementsBlazor.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<Category> AddCategory(Category category);
        Task<bool> DeleteCategory(Guid CategoryOid);
        Task<bool>UpdateCategory(Category category);
    }
}
