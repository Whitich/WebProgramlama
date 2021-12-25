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
    //[Authorize=]
    public class AdminController : Controller
    {
        AdminManager am = new AdminManager();

        public ActionResult Index()
        {
            var adbm = am.GetAll();
            return View(adbm);
        }
        public ActionResult AddAd()
        {
            var adbm = am.GetAll();
            return View(adbm);
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            am.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            am.BlogAddBL(b);
            return RedirectToAction("AddAd");
        }
        public ActionResult DeleteBlog(int id)
        {
            am.DeleteBlogBL(id);
            return RedirectToAction("AddAd");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = am.FindBlog(id);
            
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            am.UpdateBlog(p);
            return RedirectToAction("AddAd");
        }
        public ActionResult AuthorList()
        {
            var authorlist = am.GetAlla();
            return View(authorlist);
        }

    }
}
