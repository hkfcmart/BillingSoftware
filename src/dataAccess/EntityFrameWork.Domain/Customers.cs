using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork.Domain
{
    public class Customers
    {
        [Key, Column(Order = 0)]
        [Required]
        public string MobileNo { get; set; }
        [Key, Column(Order = 1)]
        public int BillNo { get; set; }
        public string CustomerName { get; set; }        
        public string Place { get; set; }
    }
}
