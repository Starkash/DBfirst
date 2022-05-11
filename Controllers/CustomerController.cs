using DBfirst.Data;
using DBfirst.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBfirst.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DbFirstCrudContext _context;
        public CustomerController(DbFirstCrudContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;
            int recsCount = _context.Customers.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recskip = (pg - 1) * pageSize;

            List<Customer> customers = _context.Customers.Skip(recskip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            
            return View(customers);
        }

        


    }
}
