using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objContext = controllerContext.HttpContext;
            string custCode = objContext.Request.Form["txtCustomerCode"];
            string custName = objContext.Request.Form["txtCustomerName"];
            Customer obj = new Customer()
            {
                CustomerCode = custCode,
                CustomerName = custName

            };
            return obj;
        }
    }

    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        public ActionResult Load()
        {
            Customer objCustomer = new Customer { 
                CustomerCode = "1001",
                CustomerName = "Azhaan"
            };
            
            return View("Customer",objCustomer);
        }

        public ActionResult Enter()
        {
            return View("EnterCustomer");        
        }

        public ActionResult Submit([ModelBinder(typeof(CustomerBinder))] Customer obj)
        {
            //Customer obj = new Customer();
            //obj.CustomerCode = Request.Form["CustomerCode"];
            //obj.CustomerName = Request.Form["CustomerName"];
            return View("Customer",obj);       
        }
	}


}