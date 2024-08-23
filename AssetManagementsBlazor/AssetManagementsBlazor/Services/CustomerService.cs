
using AssetManagementsBlazor.Data;
using AssetManagementsBlazor.Entities;
using AssetManagementsBlazor.ViewModel;
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

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            try
            {
                var customers = await _context.Customers
                    .Select(c => new CustomerViewModel
                    {
                        CustomersOid = c.CustomersOid,
                         FirstName = c.FirstName,
                         LastName = c.LastName,
                         Email = c.Email,
                         PhoneNumber = c.PhoneNumber,
                         City = c.City,
                         Birthday = c.Birthday
                    })
                    .ToListAsync();

                return customers;

            }
            catch (Exception ex)
            {

                throw new ApplicationException("An error occurred while fetching Customers.", ex);
            }
        }

        public async Task<CustomerViewModel> GetCustomerbyId(Guid CustomerOid)
        {
            throw new NotImplementedException();
        }
    }
}
