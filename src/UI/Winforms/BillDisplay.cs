using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms
{
    public class BillDisplay
    {
        public int Index { get; set; }
        public string ProductName { get; set; }
        public int HSNCode { get; set; }
        public Decimal MRP { get; set; }
        public Decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public Decimal SubTotal { get; set; }
    }
}
