using Haminhtrung_0279.Context;
using Haminhtrung_0279.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Haminhtrung_0279.Controllers
{
    public class HomeController : Controller
    {
        DTDDEntities1 dtb = new DTDDEntities1();
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();

            model.ListProduct = dtb.products.ToList();
            model.ListCategory = dtb.categories.ToList();
            return View(model);



        }
        // Detail
        public ActionResult Detail(int id)
        {
            var detail = dtb.products.Where(n => n.id == id).FirstOrDefault();
            return View(detail);
        }

        // GET register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User userid)
        {
            dtb.Users.Add(userid);
            dtb.SaveChanges();
            return RedirectToAction("Login");
        }

        // GET LOGIN
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST LOGIN
        [HttpPost]

        public ActionResult Login(User userid)
        {
            var taikhoan = userid.Username;
            var matkhau = userid.Password;
            var userCheck = dtb.Users.SingleOrDefault(x => x.Username.Equals(taikhoan) && x.Password.Equals(matkhau));
            if (userCheck != null)
            {
                Session["User"] = userCheck;
                return RedirectToAction("Index", "Home");
            }
            else
            {

            }
            {
                ViewBag.LoginFail = "Đăng nhập thất bại";
            }
            return View("Login");
        }


        // POST LOGOUT 
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}