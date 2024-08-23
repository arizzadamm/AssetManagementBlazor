using AssetManagementsBlazor.Entities;
using AssetManagementsBlazor.ViewModel;

namespace AssetManagementsBlazor.Services
{
    public interface IOrderService
    {
        Task<List<Orders>> GetAllOrder();
        Task<List<OrderViewModel>> GetAllOrders();
        Task<Orders> AddOrder(OrderViewModel orderViewModel);
        Task CreateOrder(Guid CustomerOid, Guid ProductOid, int Price, int Qty);
        Task<bool> DeleteOrder(Guid OrderOid);
        Task<bool> UpdateOrder(Orders orders);
    }
}
