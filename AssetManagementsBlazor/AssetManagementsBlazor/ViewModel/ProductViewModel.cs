namespace AssetManagementsBlazor.ViewModel
{
    public class ProductViewModel
    {
        public Guid ProductOid { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryOid { get; set; }
    }
}
