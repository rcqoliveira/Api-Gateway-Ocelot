using System;
using System.Collections.Generic;

namespace RC.OrdersApi
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreateDate { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }


        public Order(int id, Customer customer, DateTime createDate, IEnumerable<OrderItem> orderItem)
        {
            this.Id = id;
            this.Customer = customer;
            this.CreateDate = createDate;
            this.OrderItems = orderItem;
        }
    }
}