﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product
        {
            ProductID = 1,
            Name = "Kajak",
            Description = "Jednoosobowa łódka",
            Category = "Sporty wodne",
            Price = 275M
        };
        // GET: Home
        public ActionResult Index()
        {
            return View(myProduct);
        }
        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }
        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;
            return View(myProduct);
        }
        public ActionResult DemoArray()
        {
            Product[] array =
            {
                new Product {Name = "Kajak", Price = 275M },
                new Product {Name = "Kamizelka ratunkowa", Price = 48.95M },
                new Product {Name = "Piłka nożna", Price = 19.50M },
                new Product {Name = "Flaga narożna", Price = 34.95M }

            };
            return View(array);
        }
    }
}