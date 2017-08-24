using CeramicsStoreManagementWebApps.Gateway;
using CeramicsStoreShopManagement.Models.ViewModel;

namespace CeramicsStoreShopManagement.BLL
{
    public class ProductManager
    {
        ProductGateway aProductGateway = new ProductGateway();
        public ProductViewModel GetAllProductByID(int productId)
        {
            return aProductGateway.GetAllProductByID(productId);
        }
    }
}