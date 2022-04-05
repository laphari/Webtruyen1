using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTruyen.DAL.ModelMapper;
using WebsiteTruyen.Model;


namespace WebsiteTruyen.Controllers
{
    public class TruyenController : Controller
    {
        private WebsiteTruyenContext data = new WebsiteTruyenContext();
        // GET: Truyen
        public ActionResult Index()
        {
            var query = from tr in data.Truyen
                        join ng in data.NguoiDung
                        on tr.IdtacGia equals ng.IdNguoidung
                        select new Gettruyenvatheloaics
                        {
                            Truyen = tr,
                            IdNguoidung=ng.IdNguoidung,
                            TenNguoiDung=ng.TenNguoiDung,
                        };
            Session.Add("Username", "Nguyen Van A");
            var thongtin = query.ToList();
            return View(thongtin);
        }
        public ActionResult Viewcreate() 
        {
            ViewData["demo"] = data.TheLoai.ToList();
            ViewData["demosesion"] = Session["Username"];
            return View();
        }
        public ActionResult Create(int getid,string gettentruyen,bool gettrangthai,HttpPostedFileBase getanhtruyen,DateTime getthoigiantao,DateTime getthoigiansua,DateTime getthoigianxoa) 
        {
            Truyen item = new Truyen();
            item.Idtruyen = getid;
            item.TenTruyen = gettentruyen;
            item.Trangthai = gettrangthai;
            item.AnhMoTaTruyen = Getimgtruyen(getanhtruyen);
            item.TimeCreated = getthoigiantao;
            item.TimeDeteted = getthoigianxoa;
            item.TimeUpdated = getthoigiansua;
            item.IdtacGia = 0;
            data.Truyen.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public string Getimgtruyen(HttpPostedFileBase file)
        {
            var filename = file.FileName;
            var getfile = "../Gettruyen/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        public ActionResult Delete(int id) 
        {
            var item = data.Truyen.Find(id);
            data.Truyen.Remove(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}