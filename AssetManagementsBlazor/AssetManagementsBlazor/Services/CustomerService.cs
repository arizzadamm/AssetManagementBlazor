
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

        public async Task<Customers> AddCustomer(Customers customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> DeleteCustomer(Guid CustomersOid)
        {
            var customer = await _context.Customers.FindAsync(CustomersOid);
            if (customer == null)
            {
                return false;
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Customers>> GetAllCustomer()
        {
            await Task.Delay(1000);
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }
    }
}
