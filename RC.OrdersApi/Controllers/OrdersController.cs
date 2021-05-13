using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RC.OrdersApi.Controllers
{
    [ApiController]
    [Route("v1/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly List<Order> ListOfOrdens;

        public OrdersController()
        {
            this.ListOfOrdens = new List<Order>
            {
                new Order(1, new Customer(1, "Bill Gates"), DateTime.Now,
                new List<OrderItem>
                {
                    new OrderItem(1, new Product(1, "Mouse")),
                    new OrderItem(2, new Product(2, "Keyboard")),
                    new OrderItem(3, new Product(3, "Monitor")),

                }),

                new Order(2, new Customer(1, "Steve Jobs"), DateTime.Now,
                new List<OrderItem>
                {
                    new OrderItem(1, new Product(1, "Mouse")),

                })
            };
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Order> Get()
        {
            return this.ListOfOrdens;
        }

        [HttpGet]
        [Route("{orderId:int}")]
        public Order GetById(int orderId)
        {
            return this.ListOfOrdens.FirstOrDefault(x => x.Id == orderId);
        }
    }
}