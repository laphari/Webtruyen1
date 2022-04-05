using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTruyen.Model;

namespace WebsiteTruyen.Controllers
{
    public class TheloaiController : Controller
    {
        private WebsiteTruyenContext data = new WebsiteTruyenContext();

        // GET: Theloai
        public ActionResult Index()
        {
            var gettheloai = data.TheLoai.ToList();
            return View(gettheloai);
        }
        public ActionResult Viewcreate()
        {
            return View();
        }
        public ActionResult Create(string gettentheloai,DateTime getthoigiantao,DateTime getthoigianxoa,DateTime getthoigiansua,int getnguoitao)
        {
            TheLoai item = new TheLoai();
            item.TenTheLoai = gettentheloai;
            item.TimeCreated = getthoigiantao;
            item.TimeDeleted = getthoigianxoa;
            item.TimeUpdated = getthoigiansua;
            item.UserCreated = getnguoitao;
            data.TheLoai.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}