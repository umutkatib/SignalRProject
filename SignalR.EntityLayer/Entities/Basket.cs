using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Basket
    {
        public int BasketID { get; set; }
        public decimal BasketPrice { get; set; }
        public int BasketCount { get; set; }
        public decimal BasketTotalPrice { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }
    }
}
