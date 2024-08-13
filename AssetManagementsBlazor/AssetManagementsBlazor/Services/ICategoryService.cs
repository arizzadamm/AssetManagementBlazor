using AssetManagementsBlazor.Entities;


namespace AssetManagementsBlazor.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();
        Task<Category> AddCategory(Category category);
        Task<bool> DeleteCategory(Guid CategoryOid);
        Task<bool>UpdateCategory(Category category);
    }
}
