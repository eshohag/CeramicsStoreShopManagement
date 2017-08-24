using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CeramicsStoreShopManagement.Models.CoreModel
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Enter your Product Name!")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Product Color")]
        public string Color { get; set; }

        [Display(Name = "Product Size")]
        public string Size { get; set; }

        public string Description { get; set; }

        public int BrandID { get; set; }
        public virtual List<Brand> Brand { get; set; }

        public int CountryID { get; set; }
        public virtual List<Country> Country { get; set; }

        public int PriceID { get; set; }
        public virtual Price Price { get; set; }
    }
}