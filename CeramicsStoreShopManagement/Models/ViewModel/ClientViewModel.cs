using System.ComponentModel.DataAnnotations;

namespace CeramicsStoreShopManagement.Models.ViewModel
{
    public class ClientViewModel
    {
        public int ClientViewModelID { get; set; }
        [Required(ErrorMessage = "Enter a Client Name!")]
        [Display(Name = "Client Name")]
        public string NameClient { get; set; }
        [Required(ErrorMessage = "Enter a Client Mobile No!")]
        [Display(Name = "Client Contact No")]
        public string ContactNoClient { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter a Client Address!")]
        [Display(Name = "Client Address")]
        public string AddressClient { get; set; }

        [Display(Name = "Reference Name")]
        public string NameRefe { get; set; }

        [Display(Name = "Reference Contact No")]
        public string ContactRefe { get; set; }
        [Display(Name = "Address Reference")]
        public string AddressRefe { get; set; }
        [Display(Name = "Product")]
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        [Display(Name = "Total Cost")]
        public double TotalCost { get; set; }
        [Required(ErrorMessage = "Enter a Amount!")]
        [Display(Name = "Total Pyable Taka")]
        public double TotalPayableCost { get; set; }


    }
}