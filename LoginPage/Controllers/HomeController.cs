using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginPage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            DemoEntities Db = new DemoEntities();
            customer model = new customer();
            GetCustomer();
            
           return View();
        }

        public ActionResult GetCustomer()
        {
            int page =0;
            int rows =0;
            DemoEntities db = new DemoEntities();
            var data = db.customers.OrderBy(x=>x.customer_id);
           
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = data.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
            
            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = data
            };
            return Redirect("Edit",data);
        }
        
        public ActionResult Edit(int custmoerid)
        {
            DemoEntities Demo = new DemoEntities();

            var Data = Demo.customers.OrderBy(x => x.customer_id == custmoerid).FirstOrDefault();
            return View(Data);


        }
     
    }
}

