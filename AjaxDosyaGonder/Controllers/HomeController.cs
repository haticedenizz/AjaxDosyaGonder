using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxDosyaGonder.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult DosyaGonder(HttpPostedFileBase file)
        {
            if (file!=null)
            {
                if (Directory.Exists(Server.MapPath("~/dosyalar")) == false)
                    Directory.CreateDirectory(Server.MapPath("~/dosyalar"));

                file.SaveAs(Server.MapPath("~/dosyalar") + file.FileName);
                return Json(new { mesaj = "Dosya Yüklendi" });
            }
            return Json(new { mesaj = "Dosya Seçilmedi" });
        }
    }
}