﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to our Hospital System!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our Contact Info Below";

            return View();
        }
    }
}