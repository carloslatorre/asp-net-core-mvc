﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerservice;

        public SellersController (SellerService sellerService) {
            _sellerservice = sellerService;

        }


        public IActionResult Index()
        {
            var list = _sellerservice.FindAll();
            return View(list);
        }


        public IActionResult Create() {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller sell) {
            _sellerservice.Insert(sell);
            return RedirectToAction(nameof(Index));
        }



    }
}