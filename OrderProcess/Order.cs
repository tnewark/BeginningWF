using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }

    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        public decimal TotalWeight { get; set; }
        public string ShippingMethod { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();


    }

    public class ItemInfo
    {
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class OutOfStockException : Exception
    {
        public OutOfStockException() : base()
        {
            
        }

        public OutOfStockException(string message) : base(message)
        {
            
        }
    }
}
