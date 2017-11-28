using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLabs_V3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //ViewBag.Mytext = "Лабораторная работа №2";

            SelectList Colors = new SelectList(Enum.GetValues(typeof(System.Drawing.KnownColor)));
            ViewBag.Colors = Colors;
            ViewBag.MyText = Request.QueryString["Colors"] ?? "Лабораторная работа №2";

            return View();
        }
    }
}