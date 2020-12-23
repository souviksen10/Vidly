using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Caching;

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
        // GET: Customers
        public ActionResult Index()
        {
            //var customerList = _context.Customers.Include(m => m.MembershipType).ToList();
            //return View(customerList);

            //if(MemoryCache.Default["MembershipType"] == null)
            //{
            //    var memList = _context.MembershipTypes.ToList();
            //    MemoryCache.Default["MembershipType"] = _context.MembershipTypes.ToList();
            //}
            //var membershipType = (List<MembershipType>)MemoryCache.Default["MembershipType"];
            return View();
        }
        // GET: Customers/Details/1
        public ActionResult Details(int? id)
        {           
            var Id = id ?? 1;
            var customer = _context.Customers.Include(a => a.MembershipType).ToList().Find(cust => cust.Id == Id);
            if (customer == null)
                return HttpNotFound();
            else
                return View(customer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new ViewModels.CustomerFormViewModel()
            {
                //Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ViewModels.CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;                
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.Id == Id);            
            var membershipTypes = _context.MembershipTypes.ToList();
            if (customer == null)
                return HttpNotFound();
            var viewModel = new ViewModels.CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };
            
            return View("CustomerForm",viewModel);
        }

    }
}