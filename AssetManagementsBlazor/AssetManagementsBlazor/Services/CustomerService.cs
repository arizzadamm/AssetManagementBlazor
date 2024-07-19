
using AssetManagementsBlazor.Data;
using AssetManagementsBlazor.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementsBlazor.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AssetDataContext _context;

        public CustomerService(AssetDataContext context)
        {
            _context = context;
        }
        public async Task<List<Customers>> GetAllCustomer()
        {
            await Task.Delay(1000);
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

    }
}
