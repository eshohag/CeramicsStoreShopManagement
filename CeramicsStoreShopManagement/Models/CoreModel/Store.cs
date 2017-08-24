namespace CeramicsStoreShopManagement.Models.CoreModel
{
    public class Store
    {
        public int StoreID { get; set; }
        public int Quentity { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}