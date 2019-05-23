﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services.Exceptions;
using System.Diagnostics;

namespace SalesWebMvc.Controllers {
    public class SellersController : Controller {
        private readonly SellerService _sellerservice;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService deptserv) {
            _sellerservice = sellerService;
            _departmentService = deptserv;
        }


        public async Task<IActionResult> Index() {
            var list = await _sellerservice.FindAllAsync();
            return View(list);
        }


        public async Task<IActionResult> Create() {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Seller seller) {
            if (!ModelState.IsValid) {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            await _sellerservice.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "No Id" });
            }

            var obj = await _sellerservice.FindByIdAsync(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id) {
            try {
                await _sellerservice.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            } catch (IntegrityException e) {

                    return RedirectToAction(nameof(Error), new { message = e.Message });
                }
            }

            public async Task<IActionResult> Details(int? id) {
                if (id == null) {
                    return RedirectToAction(nameof(Error), new { message = "Id not provided" });
                }

                var obj = await _sellerservice.FindByIdAsync(id.Value);
                if (obj == null) {
                    return RedirectToAction(nameof(Error), new { message = "Id not found" });
                }

                return View(obj);

            }

            public async Task<IActionResult> Edit(int? id) {
                if (id == null) {
                    return RedirectToAction(nameof(Error), new { message = "No Id" });
                }
                var obj = await _sellerservice.FindByIdAsync(id.Value);
                if (obj == null) {
                    return RedirectToAction(nameof(Error), new { message = "Id not found" });
                }
                List<Department> departments = await _departmentService.FindAllAsync();
                SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
                return View(viewModel);
            }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Seller seller) {
            if (!ModelState.IsValid) {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if (id != seller.Id) {
                return RedirectToAction(nameof(Error), new { message = "Id missmatch" });
            }
            try {
                await _sellerservice.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string msg) {
            var viewModel = new ErrorViewModel {
                Message = msg,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}