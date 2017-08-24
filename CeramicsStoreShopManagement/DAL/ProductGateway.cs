using CeramicsStoreShopManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CeramicsStoreManagementWebApps.Gateway
{
    public class ProductGateway : CommonGateway
    {
        public List<ProductViewModel> GetAllProduct()
        {
            Query = "SELECT * FROM ProductViewModel";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ProductViewModel> allProduct = new List<ProductViewModel>();
            while (Reader.Read())
            {
                ProductViewModel aProduct = new ProductViewModel();
                aProduct.ProductID = (int)Reader["ProductID"];
                aProduct.ProductName = Reader["ProductName"].ToString();
                aProduct.BrandName = Reader["BrandName"].ToString();
                aProduct.CountryName = Reader["CountryName"].ToString();
                aProduct.PurchaesPrice = Convert.ToDouble(Reader["PurchaesPrice"]);
                aProduct.MinSellingPrice = Convert.ToDouble(Reader["MinSellingPrice"]);
                aProduct.MaxSellingPrice = Convert.ToDouble(Reader["MaxSellingPrice"]);
                aProduct.Quentity = Convert.ToInt32(Reader["Quentity"]);
                allProduct.Add(aProduct);
            }
            Reader.Close();
            Connection.Close();
            return allProduct;
        }

        //public List<ProductDisplay> GetAllProduct()
        //{
        //    Query = "select * from GetAllProduct";

        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<ProductDisplay> aCampaignist = new List<ProductDisplay>();
        //    while (Reader.Read())
        //    {
        //        ProductDisplay aCampaign = new ProductDisplay();
        //        aCampaign.ProductID = (int)Reader["ProductID"];
        //        aCampaign.Name = Reader["Name"].ToString();
        //        aCampaign.Brand = Reader["Brand"].ToString();
        //        aCampaign.ManufacturingCountry = Reader["ManufacturingCountry"].ToString();
        //        aCampaign.PurchasePrice = Convert.ToDouble(Reader["PurchasePrice"]);
        //        aCampaign.MinSellingPrice = Convert.ToDouble(Reader["MinSelling"]);
        //        aCampaign.MaxSellingPrice = Convert.ToDouble(Reader["MaxSelling"]);
        //        aCampaign.Quentity = Convert.ToInt32(Reader["Quentity"]);

        //        aCampaignist.Add(aCampaign);
        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return aCampaignist;
        //}

        //public ProductDisplay GetAllProductByID(int id)
        //{
        //    Query = "select * from GetAllProduct where ID=" + id;

        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    ProductDisplay aCampaign = null;
        //    while (Reader.Read())
        //    {
        //        aCampaign = new ProductDisplay();
        //        aCampaign.ProductID = (int)Reader["ID"];
        //        aCampaign.Name = Reader["Name"].ToString();
        //        aCampaign.Brand = Reader["Brand"].ToString();
        //        aCampaign.ManufacturingCountry = Reader["ManufacturingCountry"].ToString();
        //        aCampaign.PurchasePrice = Convert.ToDouble(Reader["PurchasePrice"]);
        //        aCampaign.MinSellingPrice = Convert.ToDouble(Reader["MinSelling"]);
        //        aCampaign.MaxSellingPrice = Convert.ToDouble(Reader["MaxSelling"]);
        //        aCampaign.Quentity = Convert.ToInt32(Reader["Quentity"]);
        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return aCampaign;
        //}

        //public void PriceUpdate(Price aPrice)
        //{
        //    Query = "update Prices Set Purches=" + aPrice.Purches + ", MinSelling=" + aPrice.MinSelling + ", MaxSelling=" + aPrice.MaxSelling + "  WHERE  ProductID= " + aPrice.ProductID;
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Command.ExecuteNonQuery();
        //    Connection.Close();
        //}

        //public void UpdateStore(Store aStore)
        //{
        //    Query = "update Stores Set Quentity=" + aStore.Quentity + "  WHERE  ProductID= " + aStore.ProductID;
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Command.ExecuteNonQuery();
        //    Connection.Close();
        //}

        //public ProductDisplay FindOneProductByID(int? id)
        //{
        //    Query = "SELECT * FROM GetAllProduct WHERE ID=" + id;
        //    Command = new SqlCommand(Query, Connection);

        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    ProductDisplay aCity = null;
        //    if (Reader.HasRows)
        //    {
        //        Reader.Read();
        //        aCity = new ProductDisplay();
        //        aCity.ProductID = Convert.ToInt32(Reader["ID"]);
        //        aCity.Name = Reader["Name"].ToString();
        //        aCity.Brand = Reader["Brand"].ToString();
        //        aCity.ManufacturingCountry = Reader["ManufacturingCountry"].ToString();
        //        aCity.PurchasePrice = Convert.ToInt32(Reader["PurchasePrice"]);
        //        aCity.MinSellingPrice = Convert.ToInt32(Reader["MinSelling"]);
        //        aCity.MaxSellingPrice = Convert.ToInt32(Reader["MaxSelling"]);
        //        aCity.Quentity = Convert.ToInt32(Reader["Quentity"]);

        //    }

        //    Reader.Close();
        //    Connection.Close();
        //    return aCity;
        //}

        public int Delete(int id)
        {
            Query = "DELETE FROM Products WHERE ID=" + id;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int row = Command.ExecuteNonQuery();
            Connection.Close();
            return row;
        }

        public ProductViewModel GetAllProductByID(int productId)
        {
            Query = "select * from ProductViewModel where ProductID=" + productId;

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            ProductViewModel aProduct = null;
            while (Reader.Read())
            {
                aProduct = new ProductViewModel();
                aProduct.ProductID = (int)Reader["ProductID"];
                aProduct.ProductName = Reader["ProductName"].ToString();
                aProduct.BrandName = Reader["BrandName"].ToString();
                aProduct.CountryName = Reader["CountryName"].ToString();
                aProduct.PurchaesPrice = Convert.ToDouble(Reader["PurchaesPrice"]);
                aProduct.MinSellingPrice = Convert.ToDouble(Reader["MinSellingPrice"]);
                aProduct.MaxSellingPrice = Convert.ToDouble(Reader["MaxSellingPrice"]);
                aProduct.Quentity = Convert.ToInt32(Reader["Quentity"]);
            }
            Reader.Close();
            Connection.Close();
            return aProduct;
        }
    }

}