using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTruyen.Model;


namespace WebsiteTruyen.Controllers
{
    public class ChitietTruyenController : Controller
    {
        private WebsiteTruyenContext data = new WebsiteTruyenContext();

        // GET: ChitietTruyen
        public ActionResult Index()
        {
            var thongtin = data.ChitetTruyen.ToList();
            return View(thongtin);
        }
        public ActionResult Viewcreate() 
        {
            return View();
        }
        public ActionResult Create(HttpPostedFileBase getanhchitiettruyen,int getdanhgia,string getmotatruyen, DateTime getthoigiantao, DateTime getthoigiansua, DateTime getthoigianxoa) 
        {
            ChitetTruyen item = new ChitetTruyen();
            item.AnhMoTaChitietTruyen = Getimgchitiettruyen(getanhchitiettruyen);
            item.DanhGia = getdanhgia;
            item.MoTaTruyen = getmotatruyen;
            item.TimeCreated = getthoigiantao;
            item.TimeUpdated = getthoigiansua;
            item.TimeDeleted = getthoigianxoa;
            data.ChitetTruyen.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        public string Getimgchitiettruyen(HttpPostedFileBase file)
        {
            var filename = file.FileName;
            var getfile = "../Getanhchitiettruyen/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
    }
}