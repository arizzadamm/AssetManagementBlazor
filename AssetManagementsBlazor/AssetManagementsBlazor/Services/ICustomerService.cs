using AssetManagementsBlazor.Entities;
using AssetManagementsBlazor.ViewModel;

namespace AssetManagementsBlazor.Services
{
    public interface ICustomerService
    {
        Task<List<Customers>> GetAllCustomer();
        Task<List<CustomerViewModel>> GetAllCustomers();
        Task<CustomerViewModel> GetCustomerbyId(Guid CustomerOid);
        Task<Customers>AddCustomer(Customers customer);
        Task<bool>DeleteCustomer(Guid CustomersOid);
    }
}
