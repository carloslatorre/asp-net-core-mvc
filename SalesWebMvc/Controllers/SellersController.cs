using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerservice;
        private readonly DepartmentService _departmentService;
       
        public SellersController (SellerService sellerService, DepartmentService deptserv) {
            _sellerservice = sellerService;
            _departmentService = deptserv;
        }


        public IActionResult Index()
        {
            var list = _sellerservice.FindAll();
            return View(list);
        }


        public IActionResult Create() {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Seller seller) {
            _sellerservice.Insert(seller);
            return RedirectToAction(nameof(Index));
        }



    }
}