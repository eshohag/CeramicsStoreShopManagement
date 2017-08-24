using System.ComponentModel.DataAnnotations;

namespace CeramicsStoreShopManagement.Models.CoreModel
{
    public class Country
    {
        public int CountryID { get; set; }
        [Display(Name = "Manufacturing Country")]
        public string Title { get; set; }
    }
}