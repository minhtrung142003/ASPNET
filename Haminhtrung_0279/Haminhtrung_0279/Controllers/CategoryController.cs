using Haminhtrung_0279.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haminhtrung_0279.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DTDDEntities1 obj = new DTDDEntities1();
        public ActionResult Index()
        {
            var lstCategory = obj.categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int id)
        {
            var listPro = obj.products.Where(n => n.CategoryId == id).ToList();
            return View(listPro);
        }

    }
}