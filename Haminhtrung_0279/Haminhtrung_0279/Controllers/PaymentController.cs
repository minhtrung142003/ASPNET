using Haminhtrung_0279.Context;
using Haminhtrung_0279.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Haminhtrung_0279.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        DTDDEntities1 dtb = new DTDDEntities1();
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                // lấy thông tin từ giỏ hàng từ session
                var lstCart = (List<CartModel>)Session["cart"];
                // gán dữ liệu cho order
                Order objOrder = new Order();
                objOrder.name = "Donhang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                // Lấy userId từ đối tượng User trong Session
                var userFromSession = (User)Session["User"];
                objOrder.userId = userFromSession.id; // Sử dụng thuộc tính ID của User
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.status = 1;
                dtb.Orders.Add(objOrder);

                // Lưu thông tin vào order
                dtb.SaveChanges();

                // lấy orderid vừa tạo để lưu vào orderdetail
                int intOrderId = objOrder.id;
                List<OrderDetail> lstDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.quantity = item.Quantity;
                    obj.orderId = intOrderId;
                    obj.productId = item.product.id;
                    lstDetail.Add(obj);
                }
                try
                {
                    // Lưu thông tin vào order
                    dtb.OrderDetails.AddRange(lstDetail);
                    dtb.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // In ra inner exception để xem chi tiết lỗi
                    Console.WriteLine(ex.InnerException?.Message);

                    // Xử lý lỗi tùy thuộc vào nhu cầu của bạn
                }
            }
            return View();
        }
    }
}