using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Sử dụng modell
using tmdt.Models;

namespace tmdt.Controllers
{
    public class GioHangsController : Controller
    {
        // GET: GioHangs
        //Khai báo db context
        csdlbh db = new csdlbh();
        //Khai báo hàng lưu trữ tên của giỏ hàng
        const string dsgh = "dsgh";

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Xoa(int ma)
        {
            // lấy giỏ hàng về
            List<GioHang> danhsachgh = (List<GioHang>)Session[dsgh];
            // tìm sản phẩm theo mã
            var spham = danhsachgh.Where(s => s.Spham.ma == ma).FirstOrDefault();
            //xóa sản phẩm khỏi dah sách giỏ hàng
            danhsachgh.Remove(spham);
            //cập nhập lại sesion giỏ hàng
            Session[dsgh] = danhsachgh;
            //trở về
            return RedirectToAction("XemGiohang");
        }
        public ActionResult GiamSL(int ma)
        {
            // lấy giỏ hàng về
            List<GioHang> danhsachgh = (List<GioHang>)Session[dsgh];
            // tìm sản phẩm theo mã
            var spham = danhsachgh.Where(s => s.Spham.ma == ma).FirstOrDefault();
            //tăng số lượng
            if (spham.SoLuong > 1)
            {
                //giảm
                spham.SoLuong -= 1;
                //cập nhập lại ss giỏ hàng
                Session[dsgh] = danhsachgh;
            }

            //trở về
            return RedirectToAction("XemGiohang");
        }
        public ActionResult TangSL(int ma)
        {
            // lấy giỏ hàng về
            List<GioHang> danhsachgh = (List<GioHang>)Session[dsgh];
            // tìm sản phẩm theo mã
            var spham = danhsachgh.Where(s => s.Spham.ma == ma).FirstOrDefault();
            //tăng số lượng


            spham.SoLuong += 1;
            //cập nhập lại ss giỏ hàng
            Session[dsgh] = danhsachgh;

            //trở về
            return RedirectToAction("XemGiohang");
        }
        //Xem giỏ hàng
        public ActionResult XemGioHang()
        {
            //Lấy giỏ hàng về từ biến session
            List<GioHang> danhsachgh = (List<GioHang>)Session[dsgh];
            if (danhsachgh == null)
            {
                //Trả về trang hiện hành
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                ViewBag.dsgh = danhsachgh;
            }
            return View();
        }

        //Thêm một sản phẩm mới vào giỏ hàng
        public ActionResult ThemGioHang(int ma, int soluong)
        {
            //Lấy sản phẩm về
            var spham = db.sps.Find(ma);
            //Lấy giỏ hàng từ biến  session giỏ hàng
            List<GioHang> danhsachgiohang = (List<GioHang>)Session[dsgh];
            //Kiểm tra xem giỏ hàng có rỗng ko
            if (danhsachgiohang == null)
            {
                //Khởi tạo 1 danh sách mới
                danhsachgiohang = new List<GioHang>();
                //Khởi tạo 1 sản phẩm mới từ giỏ hàng(1 sphẩm)
                GioHang gh = new GioHang(spham, soluong);
                //Thêm phần tử mới vào giỏ hàng
                danhsachgiohang.Add(gh);

            }
            else
            {
                //Kiểm tra xem sản phẩm có trong đơn hàng chưa 
                if (danhsachgiohang.Exists(s => s.Spham.ma == ma))
                {
                    //tìm đến sản phẩm
                    var sanphammoi = danhsachgiohang.Where(s => s.Spham.ma == ma).FirstOrDefault();
                    //Cập nhật số lượng
                    sanphammoi.SoLuong += soluong;
                }
                else
                {
                    //Sản phẩm chưa có trong giỏ hàng
                    GioHang gh = new GioHang(spham, soluong);
                    //Thêm phần tử mới vào giỏ hàng
                    danhsachgiohang.Add(gh);
                }
            }
            //Cập nhật thông tin giỏ hàng
            Session[dsgh] = danhsachgiohang;
            //Trả lại trang hiện hành

            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Payment()
        {
            List<GioHang> danhsachgh = (List<GioHang>)Session[dsgh];
            if (danhsachgh == null)
            {
                //Trả về trang hiện hành
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                ViewBag.dsgh = danhsachgh;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Payment(string shipname,string mobile,string address,string mail)
        {
            khachhang kh = (khachhang)Session["kh"];
            var order = new donhang();
            order.ngaydat = DateTime.Now;
            order.tennguoinhan = kh.ten;
            order.dienthoai = kh.dienthoai;
            order.diachi = kh.diachi;
            order.email = kh.email;

            var ma = new orderdao().Insert(order);
            var cart = (List<GioHang>)Session[dsgh];
            foreach (var item in cart)
            {
                var ctdhtt = new chitietdh();
                ctdhtt.masp = item.Spham.ma;
                ctdhtt.madh = item.Spham.ma;
                ctdhtt.dongia = item.SoLuong;


            }
            Session[dsgh] = null;
            return Redirect("/hoanthanh");
        }
        public ActionResult Sucess()
        {
            return View();
        }
        public ActionResult dathanhtoan()
        {
            return View();
        }
    }
}