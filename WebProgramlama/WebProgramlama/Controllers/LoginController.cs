using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace WebProgramlama.Controllers
{
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager();
        AuthorManager aum = new AuthorManager();
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AdminLogin(Admin p)
        {
            Context c = new Context();
            var datavalue = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("AddAd", "Admin");

            }
            else
            {
                return View();
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AuthorLogin(Author p)
        {
            Context c = new Context();
            var datavalue = c.Authors.FirstOrDefault(y => y.Mail == p.Mail && y.Password == p.Password);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Mail)
                };
                var useridentity = new ClaimsIdentity(claims, "b");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Author");

            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Blog");
        }
        //public ActionResult AdminLogin(Admin p)
        //{
        //    Context c = new Context();
        //    var datavalue = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
        //    if (datavalue != null)
        //    {
        //        HttpContext.Session.SetString("username", p.UserName);
        //        return RedirectToAction("AddAd", "Admin");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        //    [HttpGet]
        //    public ActionResult AuthorLogin()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult AuthorLogin(Author p)
        //    {
        //        Context c = new Context();
        //        var userinfo = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
        //        if (userinfo != null)
        //        {
        //            FormsAuthentication.SetAuthCookie(userinfo.Mail, false);
        //            Session["Mail"] = userinfo.Mail.ToString();
        //            //Session["Admin"] = userinfo.Admin.ToString();
        //            Session["AuthorID"] = userinfo.AuthorID.ToString();
        //            return RedirectToAction("Index", "User");
        //        }
        //        else
        //        {
        //            return RedirectToAction("AuthorLogin", "Login");
        //        }
        //    }
        //    [HttpGet]
        //    public ActionResult AdminLogin()
        //    {
        //        return View();
        //    }
        //    [HttpPost]
        //    public ActionResult AdminLogin(Admin p)
        //    {
        //        Context c = new Context();
        //        var admininfo = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
        //        if (admininfo != null)
        //        {
        //            FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
        //            Session["UserName"] = admininfo.UserName.ToString();
        //            return RedirectToAction("AdminBlogList", "Blog");
        //        }
        //        else
        //        {
        //            return RedirectToAction("AdminLogin", "Login");
        //        }
        //    }
        //}
    }

}