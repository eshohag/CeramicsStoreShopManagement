using System.ComponentModel.DataAnnotations;

namespace CeramicsStoreShopManagement.Models.CoreModel
{
    public class Brand
    {
        public int BrandID { get; set; }
        [Display(Name = "Brand Name")]
        public string Title { get; set; }
    }
}