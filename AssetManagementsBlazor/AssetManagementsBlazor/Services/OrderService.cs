using AssetManagementsBlazor.Data;
using AssetManagementsBlazor.Entities;
using AssetManagementsBlazor.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementsBlazor.Services
{
    public class OrderService : IOrderService
    {
        private readonly AssetDataContext _context;

        public OrderService(AssetDataContext context)
        {
            _context = context;
        }
        public async Task<Orders> AddOrder(OrderViewModel orderViewModel)
        {
            try
            {
                var order = new Orders
                {
                    OrderOid = Guid.NewGuid(), // Generate OID baru
                    CustomerOid  = orderViewModel.CustomerOid,
                    OrderDate = orderViewModel.OrderDate
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return order;
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while updating the category.", ex);
            }
        }
        public async Task CreateOrder([FromRoute]  Guid CustomerOid, Guid ProductOid,
            int Price,int Qty)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC usp_Order_CreateOrder  @CustomerOid,@ProductOid,@Price,@Qty",
                new SqlParameter("@CustomerOid", CustomerOid),
                new SqlParameter("@ProductOid", ProductOid),
                new SqlParameter("@Price", Price),
                new SqlParameter("@Qty", Qty));
        }


        public async Task<bool> DeleteOrder(Guid OrderOid)
        {
            try
            {
                var order = await _context.Orders.FindAsync(OrderOid);
                if (order == null)
                {
                    return false;
                }
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the product.", ex);
            }
        }

        public async Task<List<Orders>> GetAllOrder()
        {
            try
            {
                var order = await _context.Orders.ToListAsync();
                return order;
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while fetching categories.", ex);
            }
        }

        public async Task<List<OrderViewModel>> GetAllOrders()
        {
            var result = from o in _context.Orders
                         join c in _context.Customers
                         on o.CustomerOid equals c.CustomersOid
                         select new OrderViewModel
                         {
                             OrderOid = o.OrderOid,
                             CustomerOid = o.CustomerOid,
                             CustomerName = c.FirstName,
                             OrderDate = o.OrderDate,
                             OrderNumber = o.OrderNumber
                         };

            return await result.ToListAsync();
        }

        public async Task<bool> UpdateOrder(Orders orders)
        {
            try
            {
                var existingOrder = await _context.Orders.FindAsync(orders.OrderOid);
                if (existingOrder == null)
                {
                    return false;
                }
                {
                    existingOrder.CustomerOid = orders.CustomerOid;
                    existingOrder.OrderDate = orders.OrderDate; 
                }
                _context.Orders.Update(existingOrder);
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
