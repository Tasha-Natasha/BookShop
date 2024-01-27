using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class Order
    {
        public int Id { get; }

        public OrderItemCollection Items { get; }        

        public string CellPhone { get; set; }

        public OrderDelivery Delivery { get; set; }

        public OrderPayment Payment { get; set; }

        public int TotalCount    // =>  items.Sum(item => item.Count);
        {
            get { return Items.Sum(item => item.Count); }
        }

        public decimal TotalPrice   // => items.Sum(item => item.Price * item.Count);
        {
            get { return Items.Sum(item => (item.Price * item.Count) 
                    + (Delivery?.Amount ?? 0m)); }
        }

        public Order(int id, IEnumerable<OrderItem> items)
        {
            Id = id;
            Items = new OrderItemCollection(items);
        }
       
    }
}
