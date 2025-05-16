using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class Order
	{
        public int OrderID { get; set; }
        public string OrderTableNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
