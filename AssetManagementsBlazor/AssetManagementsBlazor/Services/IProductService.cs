using AssetManagementsBlazor.Entities;
using AssetManagementsBlazor.ViewModel;

namespace AssetManagementsBlazor.Services
{
    public interface IProductService
    {
        Task<List<Products>> GetAllProduct();
        Task<List<ProductViewModel>> GetAllProductWithCategory();
        Task<Products> AddProduct(ProductViewModel productsViewModel);
        Task<bool> DeleteProduct(Guid ProductOid);
        Task<bool> UpdateProduct(Products products);
    }
}
