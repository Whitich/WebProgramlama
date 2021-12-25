using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlama.Controllers
{
    public class RController : Controller
    {
        RManager rm = new RManager();
       
        public ActionResult Index()
        {
            var abcd = rm.GetAll();

            return View(abcd);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AdAuthor()
        {
            rm.GetAll();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AdAuthor(Author b)
        {
            rm.AuthorAddBL(b);
            return RedirectToAction("AdAuthor");
        }
    }
}
