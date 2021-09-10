using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms
{
    public class BillDisplay
    {
        public int Index { get; set; }
        public string ProductName { get; set; }
        public string HSNCode { get; set; }
        public double MRP { get; set; }
        public double SellingPrice { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
    }
}
