using CeramicsStoreManagementWebApps.Gateway;
using CeramicsStoreShopManagement.BLL;
using CeramicsStoreShopManagement.Models;
using CeramicsStoreShopManagement.Models.CoreModel;
using CeramicsStoreShopManagement.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CeramicsStoreShopManagement.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        ProductManager aProductManager = new ProductManager();
        ProductGateway aProductGateway = new ProductGateway();

        // GET: Product
        public ActionResult Index()
        {
            List<ProductViewModel> allProduct = aProductGateway.GetAllProduct();
            return View(allProduct);
        }


        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Brands = new SelectList(db.Brands, "BrandID", "Title");
            ViewBag.Country = new SelectList(db.Countries, "CountryID", "Title");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ApplicationDbContext())
                {
                    Price aPrice = new Price()
                    {
                        PurchaesPrice = product.PurchaesPrice,
                        MinSellingPrice = product.MinSellingPrice,
                        MaxSellingPrice = product.MaxSellingPrice,
                    };
                    context.Prices.Add(aPrice);
                    context.SaveChanges();

                    var priceID = (from i in context.Prices
                                   select i.PriceID).Max();



                    Product aProduct = new Product()
                    {
                        Name = product.ProductName,
                        Color = product.Color,
                        Size = product.Size,
                        Description = product.Description,
                        BrandID = product.BrandID,
                        CountryID = product.CountryID,
                        PriceID = priceID,
                    };
                    context.Products.Add(aProduct);
                    context.SaveChanges();

                    var productID = (from i in context.Products
                                     select i.ProductID).Max();



                    Store aStore = new Store()
                    {
                        Quentity = product.Quentity,
                        ProductID = productID,
                    };

                    context.Stores.Add(aStore);
                    context.SaveChanges();

                    ModelState.Clear();
                }
                return RedirectToAction("Index");

            }
            ViewBag.Brands = new SelectList(db.Brands, "BrandID", "Title");
            ViewBag.Country = new SelectList(db.Countries, "CountryID", "Title");
            return View();
        }


        [HttpGet]
        public ActionResult Selling()
        {
            List<ProductViewModel> allProduct = aProductGateway.GetAllProduct();
            ViewBag.all = new SelectList(allProduct, "ProductID", "ProductName");
            var proID = TempData["productID"];
            if (proID != null)
            {
                int productIDClient = (int)proID;
                ProductViewModel Selectedproduct = aProductManager.GetAllProductByID(productIDClient);
                ViewBag.Product = Selectedproduct;
            }
            return View();
        }



        [HttpPost]
        public JsonResult GetProductByID(int productID)
        {
            if (TempData["productID"] != null)
            {
                TempData.Remove("productID");
            }
            else
            {
                TempData["productID"] = productID;
            }


            return Json(new
            {
                redirectUrl = Url.Action("Selling", "Product"),
                isRedirect = true
            });

        }


        [HttpPost]
        public ActionResult Selling(ProductViewModel aProduct)
        {
            if (ModelState.IsValid)
            {
                if (aProduct.Quentity >= 0 || aProduct.MinSellingPrice >= 0)
                {
                    ProductViewModel SellingProduct = new ProductViewModel()
                    {
                        ProductID = aProduct.ProductID,
                        ProductName = aProduct.ProductName,
                        BrandName = aProduct.BrandName,
                        CountryName = aProduct.CountryName,
                        MinSellingPrice = aProduct.MinSellingPrice,
                        Quentity = aProduct.Quentity,
                        TotalCost = aProduct.Quentity * aProduct.MinSellingPrice,
                    };


                    if (Session["SellingProductList"] != null)
                    {
                        List<ProductViewModel> allSelingProduct = (List<ProductViewModel>)Session["SellingProductList"];
                        allSelingProduct.Add(SellingProduct);
                        Session["SellingProductList"] = allSelingProduct;
                        ViewBag.SellItem = Session["SellingProductList"];


                        double totalPrice = 0;
                        int quentities = 0;
                        foreach (ProductViewModel aPrice in allSelingProduct)
                        {
                            totalPrice += aPrice.TotalCost;
                            quentities += aPrice.Quentity;
                        }
                        ViewBag.TotalPrice = totalPrice;
                        Session["TotalPrice"] = totalPrice;
                        ViewBag.Quentities = quentities;

                    }
                    else
                    {
                        List<ProductViewModel> allSeling = new List<ProductViewModel>();
                        allSeling.Add(SellingProduct);
                        Session["SellingProductList"] = allSeling;
                        ViewBag.SellItem = Session["SellingProductList"];



                        double totalPrice = 0;
                        int quentities = 0;
                        foreach (ProductViewModel aPrice in allSeling)
                        {
                            totalPrice += aPrice.TotalCost;
                            quentities += aPrice.Quentity;
                        }
                        ViewBag.TotalPrice = totalPrice;
                        Session["TotalPrice"] = totalPrice;
                        ViewBag.Quentities = quentities;
                    }
                }
            }
            List<ProductViewModel> allProduct = aProductGateway.GetAllProduct();
            ViewBag.all = new SelectList(allProduct, "ProductID", "ProductName");
            return View();
        }





        [HttpGet]
        public ActionResult SelectedProduct()
        {
            ViewBag.Total = Session["TotalPrice"];
            return View();

        }
        [HttpPost]
        public ActionResult SelectedProduct(ClientViewModel aClient)
        {
            List<ProductViewModel> SellingProduct = (List<ProductViewModel>)Session["SellingProductList"];

            if (ModelState.IsValid)
            {
                //Reference aReference = new Reference()
                //{
                //    Name = aClient.NameReference,
                //    ContactNo = aClient.ContactNoReference,
                //    Address = aClient.AddressReference,
                //};
                //db.References.Add(aReference);
                //db.SaveChanges();

                //var id = (from cl in db.References
                //          select cl.ID).Max();

                //Client aClients = new Client
                //{
                //    Name = aClient.Name,
                //    ContactNo = aClient.ContactNo,
                //    Email = aClient.Email,
                //    Address = aClient.Address,
                //    ReferenceID = id,
                //};

                //db.Clients.Add(aClients);
                //db.SaveChanges();



                //Payment aPayment = new Payment()
                //{
                //    TotalCost = aClient.TotalTaka,
                //    PayAmount = aClient.TotalPayable,
                //    TotalDue = aClient.TotalTaka - aClient.TotalPayable,
                //};
                //db.Payments.Add(aPayment);
                //db.SaveChanges();

                //foreach (var aProduct in SellingProduct)
                //{


                //    var clientID = (from client in db.Clients
                //                    select client.ID).Max();
                //    var productID = aProduct.ProductID;
                //    var paymentID = (from pay in db.Payments
                //                     select pay.ID).Max();

                //    var quentity = (from q in db.Stores
                //                    where q.ProductID == aProduct.ID
                //                    select q.Quentity);
                //    Billing aBilling = new Billing()
                //    {
                //        ClientID = clientID,
                //        Quentity = aProduct.Quentity,
                //        ProductID = productID,
                //        PaymentID = paymentID,
                //    };
                //    db.Billings.Add(aBilling);
                //    db.SaveChanges();


                //}


            }
            return View();
        }



        [HttpPost]
        public ActionResult CancelSelectedProduct()
        {
            Session.Clear();
            return RedirectToAction("Selling");

        }


    }
}
