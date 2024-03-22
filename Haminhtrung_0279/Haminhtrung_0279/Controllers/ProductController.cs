using Haminhtrung_0279.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Haminhtrung_0279.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product


        DTDDEntities1 dtb = new DTDDEntities1();
        public ActionResult Index()
        {
            var listproduct = dtb.products.ToList();
            return View(listproduct);
        }

        public ActionResult Detail(int id)
        {
            var detail = dtb.products.Where(n => n.id == id).FirstOrDefault();
            return View(detail);
        }
    }
}
