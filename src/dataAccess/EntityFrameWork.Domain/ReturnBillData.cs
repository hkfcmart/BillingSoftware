using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.Domain
{
    public class ReturnBillData
    {
        public int Id { get; set; }
        public bool IsCancelled { get; set; }
        [Required]
        public int BillNo { get; set; }
        public string BarCode { get; set; }
        [Required]
        public string ProductName { get; set; }
        public DateTime ReturnDate  { get; set; }
        public string HSNCode { get; set; }
        public double GST { get; set; }
        public string BrandName { get; set; }
        public string Categories { get; set; }
        public string Vendor { get; set; }
        public int ShelfNo { get; set; }
        public double MRP { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }
        public double Discount { get; set; }
        public double Quantity { get; set; }
        public int BatchNo { get; set; }
        public string ManufacturingDate { get; set; }
        public string PurchasingDate { get; set; }
        public string ExpiryDate { get; set; }
    }
}
