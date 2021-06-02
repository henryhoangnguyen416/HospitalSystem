using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class LogInController : Controller
    {
        string[] emails = {"example@mail.com","hello@mail.com"};//Preset array of emails
        string[] passwords = { "example", "hello" };//Preset array of passwords
        // GET: LogIn
        public ActionResult Index(string email, string password)
        {
            if (emails.Contains(email) && password.Contains(password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

    }
}