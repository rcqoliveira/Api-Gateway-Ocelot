using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RC.Customers.Controllers
{
    [ApiController]
    [Route("v1/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly List<Customer> ListOfCustomers;

        public CustomersController()
        {
            this.ListOfCustomers = new List<Customer>
            {
                new Customer(1, "Bill Gates", "Gates"),
                new Customer(2, "Paul Allen", "Allen"),
                new Customer(3, "Steve Jobs", "Jobs")
            };
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Customer> Get()
        {
            return this.ListOfCustomers;
        }

        [HttpGet]
        [Route("{currencyId:int}")]
        public Customer GetById(int currencyId)
        {
            return this.ListOfCustomers.FirstOrDefault(x => x.Id == currencyId);
        }
    }
}
