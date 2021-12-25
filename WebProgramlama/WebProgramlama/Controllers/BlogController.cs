using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgramlama.Controllers
{
    public class BlogController : Controller
    {
        private readonly IStringLocalizer<BlogController> _localizer;
        BlogManager bm = new BlogManager();
        [AllowAnonymous]

        public ActionResult Index2()
        {
            var bllis = bm.GetAll();
            return View(bllis);
        }
        [AllowAnonymous]

        public ActionResult Index()
        {
            var bllis = bm.GetAll();
            return View(bllis);
            //return View();
        }
        [AllowAnonymous]

        public PartialViewResult BlogList(int page = 1)
        {
            //var bloglist=bm.TerstenBlogList().ToPagedList(page, 9);
            var bloglist = bm.GetAll().OrderByDescending(x => x.BlogID).ToPagedList(page, 9);
            return PartialView(bloglist);
        }
        [AllowAnonymous]
        public ActionResult BlogDetails(int id)
        {
            var balis = bm.GetBlogByID(id);
            return View(balis);
        }
    }

}
