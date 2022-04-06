using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tmdt.Models; // khai báo sử dụng models

namespace tmdt.Areas.admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: admin/Default
        //Khai bao dbcontext ( Một lớp đối tượng của entity)
        csdlbh db = new csdlbh();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtTen,string txtMk)
        {
            var nd = db.nguoidungs.Where(s => s.tendangnhap.Equals(txtTen) && s.matkhau.Equals(txtMk)).FirstOrDefault();
            if(nd!=null)
            {
                Session["nd"] = nd;
                return RedirectToAction("Index");

            }
            ViewBag.ms = "Tên đăng nhập hoặc mật khẩu sai";
            return View();
        }
       
    }
}