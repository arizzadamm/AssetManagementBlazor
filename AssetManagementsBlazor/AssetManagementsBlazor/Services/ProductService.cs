using AssetManagementsBlazor.Data;
using AssetManagementsBlazor.Entities;
using AssetManagementsBlazor.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementsBlazor.Services
{
    public class ProductService : IProductService
    {
        private readonly AssetDataContext _context;

        public ProductService(AssetDataContext context)
        {
            _context = context;
        }
        public async Task<Products> AddProduct(ProductViewModel productsViewModel)
        {
            try
            {
                var product = new Products
                {
                    ProductOid = Guid.NewGuid(), // Generate OID baru
                    ProductName = productsViewModel.ProductName,
                    CategoryOid = productsViewModel.CategoryOid,
                    Description = productsViewModel.Description,
                    Price = productsViewModel.Price,
                    StockQuantity = productsViewModel.StockQuantity
                };
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while updating the category.", ex);
            }
        }

        public async Task<bool> DeleteProduct(Guid ProductOid)
        {
            try
            {
                var products = await _context.Products.FindAsync(ProductOid);
                if (products == null)
                {
                    return false;
                }
                _context.Products.Remove(products);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while updating the product.", ex);
            }
        }

        public async Task<List<Products>> GetAllProduct()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return products;
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while fetching categories.", ex);
            }
        }

        public async Task<List<ProductViewModel>> GetAllProductWithCategory()
        {
            var result = from p in _context.Products
                         join c in _context.Category
                         on p.CategoryOid equals c.CategoryOid
                         select new ProductViewModel
                         {
                             ProductOid = p.ProductOid,
                             ProductName = p.ProductName,
                             CategoryName = c.Name,
                             Description = p.Description,
                             Price = p.Price,
                             StockQuantity = p.StockQuantity
                         };

            return await result.ToListAsync();
        }

        public async Task<bool> UpdateProduct(Products products)
        {
            try
            {
                var existingProduct = await _context.Products.FindAsync(products.ProductOid);
                if (existingProduct == null)
                {
                    return false;
                }

                existingProduct.ProductName = products.ProductName;

                _context.Products.Update(existingProduct);
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
