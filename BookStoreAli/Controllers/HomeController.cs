using BookStoreAli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreAli.Controllers
{
    public class HomeController : Controller
    {
        DataManagement db = new DataManagement();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            string errormessage = string.Empty;
            try
            {

                //if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password))
                //    errormessage = "Enter User Name and Password";
                if (ModelState.IsValid)
                {

                    if (db.CheckIfUserExists(user))
                        return RedirectToAction( nameof(BookController.BookDetails),"Book");
                    else
                        ViewBag.incorrect = "User Name or Password is incorrect . Try Again";
                }
                //if (!string.IsNullOrEmpty(errormessage))
                //    return Content($"<script language='javascript' type='text/javascript'>alert('{errormessage}');</script>");





            }
            catch (Exception ex)
            {
                errormessage = "Something Went Wrong Try Again Later";
            }

            return View(user);
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUser user)
        {
            string errormessage = string.Empty;
            try
            {

                   if (ModelState.IsValid)
                {

                    if (db.Register(user))
                        return RedirectToAction(nameof(Login));
                    else
                        errormessage = "User Name Already exists. Try with Other Username";

                }
           
            }
            catch (Exception ex)
            {
                errormessage = "Something Went Wrong Try Again Later";
            }
            ViewBag.errormsg=errormessage;
            return View(user);
        }
    }
}