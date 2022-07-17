using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms
{
    public class BillDisplayReturn
    {
        public int Index { get; set; }
        public string BarCode { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ProductName { get; set; }
        public string HSNCode { get; set; }
        public string ManufacturingDate { get; set; }
        public double MRP { get; set; }
        public double SellingPrice { get; set; }
        public double Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}
