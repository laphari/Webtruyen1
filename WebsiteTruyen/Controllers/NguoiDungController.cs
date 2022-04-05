using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebsiteTruyen.MahoaMD5;
using WebsiteTruyen.Model;


namespace WebsiteTruyen.Controllers
{
    public class NguoiDungController : Controller
    {
        private WebsiteTruyenContext data = new WebsiteTruyenContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(NguoiDung account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            account.MatKhauNguoiDung = Mahoapass.Mahoa(account.MatKhauNguoiDung);
            data.NguoiDung.Add(account);
            data.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(NguoiDung account)
        {
            var checkpass = Mahoapass.Mahoa(account.MatKhauNguoiDung);
            var rel = data.NguoiDung.Where(x => x.MailNguoiDung == account.MailNguoiDung && x.MatKhauNguoiDung == checkpass).Count();
            if (rel == 1)
            {
                FormsAuthentication.SetAuthCookie(account.MailNguoiDung, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("FailLogin", "Sai");
                return View(account);
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","NguoiDung");
        }
        [HttpGet]
        public ActionResult Resetpass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Resetpass(string Email)
        {
            var reset = "12345";
            var itemresetpass = data.NguoiDung.Where(x => x.MailNguoiDung == Email).FirstOrDefault();
            itemresetpass.MatKhauNguoiDung = Mahoapass.Mahoa(reset);
            //data.Entry(itemresetpass).State = EntityState.Modified.Up;
            data.NguoiDung.Update(itemresetpass);
            data.SaveChanges();
            var demo = new Maihepler();
            demo.SendMail(Email, "Demoo", "Password is" + reset.ToString());
            return View();
        }
        public ActionResult UpdatePass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdatePass(string Email , string newpass,string matkhaucu)
        {
            var itemresetpass = data.NguoiDung.Where(x => x.MailNguoiDung == Email).FirstOrDefault();
            itemresetpass.MatKhauNguoiDung = Mahoapass.Mahoa(newpass);
            var mahoamatkhaucu = Mahoapass.Mahoa(matkhaucu);

            var checkpass = data.NguoiDung.Where(x => x.MatKhauNguoiDung == mahoamatkhaucu).FirstOrDefault();
            if(checkpass == null) 
            {
                ModelState.AddModelError("Matkhausai", "Sai");
                return View();
            }
            else
            {
                itemresetpass.MatKhauNguoiDung = Mahoapass.Mahoa(newpass);
                data.NguoiDung.Update(itemresetpass);
                data.SaveChanges();
                return View();
            }
            //data.Entry(itemresetpass).State = EntityState.Modified.Up;
        }
    }
}