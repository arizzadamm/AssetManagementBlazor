using AssetManagementsBlazor.Entities;

namespace AssetManagementsBlazor.Services
{
    public interface ICustomerService
    {
        Task<List<Customers>> GetAllCustomer();
        Task<Customers>AddCustomer(Customers customer);
    }
}
