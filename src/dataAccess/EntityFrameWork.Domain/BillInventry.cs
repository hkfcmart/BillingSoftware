using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.Domain
{
    public class BillInventry
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public int HSNCode { get; set; }
        public Double GST { get; set; }
        public string BrandName { get; set; }
        public string Categories { get; set; }
        public string Vendor { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime PurchasedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ShelfNo { get; set; }        
        public Double MRP { get; set; }
        public Double PurchasePrice { get; set; }
        public Double SellingPrice { get; set; }
        public Double Discount { get; set; }
        public int Quantity { get; set; }
        public int BatchNo { get; set; }
    }
}
