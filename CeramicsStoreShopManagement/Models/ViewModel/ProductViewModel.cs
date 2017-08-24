using System.ComponentModel.DataAnnotations;

namespace CeramicsStoreShopManagement.Models.ViewModel
{
    public class ProductViewModel
    {
        public int ProductViewModelID { get; set; }
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Enter your Product Name!")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Color")]
        public string Color { get; set; }

        [Display(Name = "Product Size")]
        public string Size { get; set; }

        public string Description { get; set; }

        public int BrandID { get; set; }
        public string BrandName { get; set; }

        public int CountryID { get; set; }
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Enter your Product Purches Price!")]
        [Display(Name = "Purchase Price")]
        public double PurchaesPrice { get; set; }

        [Required(ErrorMessage = "Enter your Product Minimum Selling Price!")]
        [Display(Name = "Min Selling Price")]
        public double MinSellingPrice { get; set; }

        [Required(ErrorMessage = "Enter your Product Maximum Selling Price!")]
        [Display(Name = "MAX Selling Price")]
        public double MaxSellingPrice { get; set; }

        [Required(ErrorMessage = "Enter your Product Quentity!")]
        public int Quentity { get; set; }

        public double TotalCost { get; set; }
    }
}