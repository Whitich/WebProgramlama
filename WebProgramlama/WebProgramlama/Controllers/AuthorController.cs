using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlama.Controllers
{
    public class AuthorController : Controller
    {
        AuthorManager aum = new AuthorManager();

        public ActionResult Index()
        {
            var adbm = aum.GetAll();
            return View(adbm);
        }
        public ActionResult AuthorBlogAdd()
        {
            var adbm = aum.GetAll();
            return View(adbm);
        
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            aum.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            aum.BlogAddBL(b);
            return RedirectToAction("AddAd");
        }
        public ActionResult DeleteBlog(int id)
        {
            aum.DeleteBlogBL(id);
            return RedirectToAction("AddAd");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = aum.FindBlog(id);

            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            aum.UpdateBlog(p);
            return RedirectToAction("AddAd");
        }
        
    }

}
