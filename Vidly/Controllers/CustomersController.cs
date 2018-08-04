using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer(){Name = "John Smith", Id = 2},
                new Customer(){Name = "Marry Williams", Id = 3},
                new Customer(){Name = "Brajalal Pal", Id = 1}
            };
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers; //GetCustomers();

            return View(customers);
        }
        public ActionResult Details(int id)
        {
            //var customers = GetCustomers();
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);  //customers.Find(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}