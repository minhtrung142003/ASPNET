using Haminhtrung_2121110279_aspNET.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace Haminhtrung_2121110279_aspNET.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        DTDDEntities3 obj = new DTDDEntities3();
        public ActionResult Index()
        {
            var listproduct = obj.products.ToList();
            return View(listproduct);
        }
        public ActionResult Detail(int id)
        {
            var detail = obj.products.Where(n=>n.id == id).FirstOrDefault();
            return View(detail);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(product table, HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    // Lấy tên file
                    var fileName = Path.GetFileName(file.FileName);

                    // Xác định đường dẫn nơi file sẽ được lưu trữ
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);

                    // Lưu file
                    file.SaveAs(path);

                    // Gán đường dẫn hình ảnh vào thuộc tính Image của đối tượng product
                    table.image = fileName;
                }

                obj.products.Add(table);
                obj.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi tại đây, ví dụ: log lỗi, hiển thị thông báo lỗi, vv.
                ModelState.AddModelError("", "Đã xảy ra lỗi khi thêm sản phẩm. Chi tiết lỗi: " + ex.Message);
                return View();
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            // Lấy thông tin sản phẩm cần xóa từ database
            product productToDelete = obj.products.Find(id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }

            return View(productToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Lấy thông tin sản phẩm cần xóa từ database
            product productToDelete = obj.products.Find(id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }

            // Xóa sản phẩm
            obj.products.Remove(productToDelete);
            obj.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Lấy thông tin sản phẩm cần sửa từ database
            product productToEdit = obj.products.Find(id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }

            return View(productToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(product table, HttpPostedFileBase file)
        {
            product productToEdit = null;

            try
            {
                // Lấy thông tin sản phẩm cần sửa từ database
                productToEdit = obj.products.Find(table.id);

                if (productToEdit == null)
                {
                    return HttpNotFound();
                }

                // Nếu người dùng chọn ảnh mới      
                if (file != null && file.ContentLength > 0)
                {
                    // Xóa ảnh cũ nếu tồn tại
                    if (!string.IsNullOrEmpty(productToEdit.image))
                    {
                        var oldImagePath = Path.Combine(Server.MapPath("~/Images"), productToEdit.image);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Lưu ảnh mới
                    var newFileName = Path.GetFileName(file.FileName);
                    var newImagePath = Path.Combine(Server.MapPath("~/Images"), newFileName);
                    file.SaveAs(newImagePath);

                    // Cập nhật đường dẫn ảnh mới
                    productToEdit.image = newFileName;
                }
                else
                {
                    // Nếu không có ảnh mới được chọn, giữ nguyên ảnh cũ
                    productToEdit.image = productToEdit.image;
                }

                // Cập nhật các thuộc tính khác của sản phẩm
                productToEdit.name = table.name;
                productToEdit.price = table.price;

                obj.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi khi chỉnh sửa sản phẩm. Chi tiết lỗi: " + ex.Message);

                // Nếu productToEdit bằng null hoặc có lỗi, bạn có thể quay lại view với một đối tượng mới hoặc là null
                return View(productToEdit ?? new product());
            }
        }



    }
}