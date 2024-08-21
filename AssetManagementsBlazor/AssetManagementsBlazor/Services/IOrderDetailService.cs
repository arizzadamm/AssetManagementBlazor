using AssetManagementsBlazor.Entities;
using AssetManagementsBlazor.ViewModel;

namespace AssetManagementsBlazor.Services
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetail>> GetAllOrderDetail();
        Task<List<OrderdetailViewModel>> GetOrderDetailbyOrder(Guid OrderOid);
    }
}
