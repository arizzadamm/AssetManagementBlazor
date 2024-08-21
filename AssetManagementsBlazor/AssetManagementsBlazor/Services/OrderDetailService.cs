using AssetManagementsBlazor.Data;
using AssetManagementsBlazor.Entities;
using AssetManagementsBlazor.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementsBlazor.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly AssetDataContext _context;

        public OrderDetailService(AssetDataContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDetail>> GetAllOrderDetail()
        {
            try
            {
                var orderdetail = await _context.OrderDetails.ToListAsync();
                return orderdetail;
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while fetching categories.", ex);
            }
        }

        public async Task<List<OrderdetailViewModel>> GetOrderDetailbyOrder(Guid OrderOid)
        {
            var result = await (from od in _context.OrderDetails
                                join o in _context.Orders on od.OrderOid equals o.OrderOid
                                join p in _context.Products on od.ProductOid equals p.ProductOid
                                where od.OrderOid == o.OrderOid
                                select new OrderdetailViewModel
                                {
                                    OrderDetailOid = od.OrderDetailOid,
                                    OrderOid = od.OrderOid,
                                    ProductName = p.ProductName,
                                    Qty = od.Qty,
                                    Price = od.Price,
                                    OrderDate = o.OrderDate
                                   
                                }).ToListAsync();

            return result;
        }
        public async Task DeleteOrder(Guid orderOid)
        {
            try
            {
                // Retrieve the order and associated order details
                var orderDetails = await _context.OrderDetails
                                         .Where(od => od.OrderOid == orderOid)
                                         .ToListAsync();

                if (orderDetails == null)
                    throw new ApplicationException("Order not found.");

                var productIds = orderDetails.Select(od => od.ProductOid).Distinct();

                var productsToUpdate = await _context.Products
                                                     .Where(p => productIds.Contains(p.ProductOid))
                                                     .ToListAsync();
                foreach (var product in productsToUpdate)
                {
                    var totalQtyToReturn = orderDetails
                        .Where(od => od.ProductOid == product.ProductOid)
                        .Sum(od => od.Qty);

                    product.StockQuantity += totalQtyToReturn;

                }
                await _context.SaveChangesAsync();
                // Delete the order details using LINQ
                _context.OrderDetails.RemoveRange(orderDetails);

                // Delete the order
                var orderToDelete = await _context.Orders.FirstOrDefaultAsync(o => o.OrderOid == orderOid);
                if (orderToDelete != null)
                {
                    _context.Orders.Remove(orderToDelete);
                }

                // Save changes for deletion
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Logging or handling the error
                throw new ApplicationException("An error occurred while deleting the order.", ex);
            }
        }
        //public async Task<Orders> AddOrder(OrderViewModel orderViewModel)
        //{
        //    using var transaction = await _context.Database.BeginTransactionAsync();
        //    try
        //    {
        //        // Buat entitas Order baru
        //        var order = new Orders
        //        {
        //            OrderOid = Guid.NewGuid(),
        //            CustomerOid = orderViewModel.CustomerOid,
        //            OrderDate = orderViewModel.OrderDate
        //        };

        //        // Tambahkan order ke context
        //        _context.Orders.Add(order);
        //        await _context.SaveChangesAsync();

        //        // Loop melalui OrderDetails di ViewModel
        //        foreach (var item in orderViewModel.OrderDetails)
        //        {
        //            // Buat entitas OrderDetail baru
        //            var orderDetail = new OrderDetail
        //            {
        //                OrderDetailOid = Guid.NewGuid(),
        //                OrderOid = order.OrderOid,
        //                ProductOid = item.ProductOid,
        //                Qty = item.Qty,
        //                Price = item.Price
        //            };

        //            // Kurangi stok produk
        //            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductOid == item.ProductOid);
        //            if (product == null)
        //            {
        //                throw new ApplicationException("Product not found.");
        //            }
        //            if (product.StockQuantity < item.Qty)
        //            {
        //                throw new ApplicationException($"Insufficient stock for product {product.ProductName}.");
        //            }

        //            product.StockQuantity -= item.Qty;

        //            // Tambahkan orderDetail ke context
        //            _context.OrderDetails.Add(orderDetail);
        //        }

        //        // Simpan perubahan ke database
        //        await _context.SaveChangesAsync();
        //        await transaction.CommitAsync();

        //        return order;
        //    }
        //    catch (Exception ex)
        //    {
        //        await transaction.RollbackAsync();
        //        // Logging or handling the error
        //        throw new ApplicationException("An error occurred while placing the order.", ex);
        //    }

        //}
    }
}
