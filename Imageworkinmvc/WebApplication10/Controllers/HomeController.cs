using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var db = new MVC_WorkEntities();
            var query = from d in db.MyProduct select d;
            return View(query.ToList());
        }

        public ActionResult AddImage()
        {
            MyProduct p = new MyProduct();
            return View(p);
        }
        [HttpPost]
        public ActionResult AddImage(MyProduct model, HttpPostedFileBase image1)
        {
            var db = new MVC_WorkEntities();
            if (image1 != null)
            {
                model.prod_image = new byte[image1.ContentLength];
                image1.InputStream.Read(model.prod_image, 0, image1.ContentLength);
            }
            db.MyProduct.Add(model);
            db.SaveChanges();
          //  Response.Write("<script>alert(" + image1 + ");</script>");
            return View(model);
        }
    }
}