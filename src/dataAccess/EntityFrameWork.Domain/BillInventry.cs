using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.Domain
{
    public class BillInventry
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        [Required]
        public string ProductName { get; set; }
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
        public int Quantity { get; set; }
        public int BatchNo { get; set; }
    }
}
