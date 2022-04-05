using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteTruyen.Model;


namespace WebsiteTruyen.Controllers
{
    public class AnhBiaController : Controller
    {
        private WebsiteTruyenContext data = new WebsiteTruyenContext();
        // GET: AnhBia
        public ActionResult Index()
        {
            var getanhbia = data.AnhBia.ToList();
            return View(getanhbia);
        }
        public string Getanhbia(HttpPostedFileBase file) 
        {
            var filename = file.FileName;
            var getfile = "../Uploadanhbia/" + filename;
            file.SaveAs(Server.MapPath(getfile));
            return getfile;
        }
        public ActionResult Viewcreate() 
        {
            return View();
        }
        public ActionResult Create(HttpPostedFileBase getanhbia) 
        {
            AnhBia item = new AnhBia();
            item.AnhBia1 = Getanhbia(getanhbia);
            data.AnhBia.Add(item);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}